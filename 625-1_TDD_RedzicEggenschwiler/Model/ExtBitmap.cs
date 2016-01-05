/*
 * The Following Code was developed by Dewald Esterhuizen
 * View Documentation at: http://softwarebydefault.com
 * Licensed under Ms-PL 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion
{
    public static class ExtBitmap
    {
        public static Bitmap CopyToSquareCanvas(this Bitmap sourceBitmap, int canvasWidthLenght)
        {
            float ratio = 1.0f;
            int maxSide = sourceBitmap.Width > sourceBitmap.Height ?
                          sourceBitmap.Width : sourceBitmap.Height;

            ratio = (float)maxSide / (float)canvasWidthLenght;

            Bitmap bitmapResult = (sourceBitmap.Width > sourceBitmap.Height ?
                                    new Bitmap(canvasWidthLenght, (int)(sourceBitmap.Height / ratio))
                                    : new Bitmap((int)(sourceBitmap.Width / ratio), canvasWidthLenght));

            using (Graphics graphicsResult = Graphics.FromImage(bitmapResult))
            {
                graphicsResult.CompositingQuality = CompositingQuality.HighQuality;
                graphicsResult.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsResult.PixelOffsetMode = PixelOffsetMode.HighQuality;

                graphicsResult.DrawImage(sourceBitmap,
                                        new Rectangle(0, 0,
                                            bitmapResult.Width, bitmapResult.Height),
                                        new Rectangle(0, 0,
                                            sourceBitmap.Width, sourceBitmap.Height),
                                            GraphicsUnit.Pixel);
                graphicsResult.Flush();
            }

            return bitmapResult;
        }

        private static Bitmap ConvolutionFilter(Bitmap sourceBitmap, 
                                             double[,] filterMatrix, 
                                                  double factor = 1, 
                                                       int bias = 0, 
                                             bool grayscale = false) 
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly, 
                                                 PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;


                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blue = 0.0;
            double green = 0.0;
            double red = 0.0;

            int filterWidth = filterMatrix.GetLength(1);
            int filterHeight = filterMatrix.GetLength(0);

            int filterOffset = (filterWidth-1) / 2;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY < 
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX < 
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blue = 0;
                    green = 0;
                    red = 0;

                    byteOffset = offsetY * 
                                 sourceData.Stride + 
                                 offsetX * 4;

                    for (int filterY = -filterOffset; 
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {

                            calcOffset = byteOffset + 
                                         (filterX * 4) + 
                                         (filterY * sourceData.Stride);

                            blue += (double)(pixelBuffer[calcOffset]) *
                                    filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            green += (double)(pixelBuffer[calcOffset + 1]) *
                                     filterMatrix[filterY + filterOffset, 
                                                        filterX + filterOffset];

                            red += (double)(pixelBuffer[calcOffset + 2]) *
                                   filterMatrix[filterY + filterOffset, 
                                                      filterX + filterOffset];
                        }
                    }

                    blue = factor * blue + bias;
                    green = factor * green + bias;
                    red = factor * red + bias;

                    if (blue > 255)
                    { blue = 255; }
                    else if (blue < 0)
                    { blue = 0; }

                    if (green > 255)
                    { green = 255; }
                    else if (green < 0)
                    { green = 0; }

                    if (red > 255)
                    { red = 255; }
                    else if (red < 0)
                    { red = 0; }

                    resultBuffer[byteOffset] = (byte)(blue);
                    resultBuffer[byteOffset + 1] = (byte)(green);
                    resultBuffer[byteOffset + 2] = (byte)(red);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                 PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap ConvolutionFilter(this Bitmap sourceBitmap,
                                                double[,] xFilterMatrix,
                                                double[,] yFilterMatrix,
                                                      double factor = 1,
                                                           int bias = 0,
                                                 bool grayscale = false)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                     sourceBitmap.Width, sourceBitmap.Height),
                                                       ImageLockMode.ReadOnly,
                                                  PixelFormat.Format32bppArgb);

            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];
            byte[] resultBuffer = new byte[sourceData.Stride * sourceData.Height];

            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);
            sourceBitmap.UnlockBits(sourceData);

            if (grayscale == true)
            {
                float rgb = 0;

                for (int k = 0; k < pixelBuffer.Length; k += 4)
                {
                    rgb = pixelBuffer[k] * 0.11f;
                    rgb += pixelBuffer[k + 1] * 0.59f;
                    rgb += pixelBuffer[k + 2] * 0.3f;

                    pixelBuffer[k] = (byte)rgb;
                    pixelBuffer[k + 1] = pixelBuffer[k];
                    pixelBuffer[k + 2] = pixelBuffer[k];
                    pixelBuffer[k + 3] = 255;
                }
            }

            double blueX = 0.0;
            double greenX = 0.0;
            double redX = 0.0;

            double blueY = 0.0;
            double greenY = 0.0;
            double redY = 0.0;

            double blueTotal = 0.0;
            double greenTotal = 0.0;
            double redTotal = 0.0;

            int filterOffset = 1;
            int calcOffset = 0;

            int byteOffset = 0;

            for (int offsetY = filterOffset; offsetY <
                sourceBitmap.Height - filterOffset; offsetY++)
            {
                for (int offsetX = filterOffset; offsetX <
                    sourceBitmap.Width - filterOffset; offsetX++)
                {
                    blueX = greenX = redX = 0;
                    blueY = greenY = redY = 0;

                    blueTotal = greenTotal = redTotal = 0.0;

                    byteOffset = offsetY *
                                 sourceData.Stride +
                                 offsetX * 4;

                    for (int filterY = -filterOffset;
                        filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset;
                            filterX <= filterOffset; filterX++)
                        {
                            calcOffset = byteOffset +
                                         (filterX * 4) +
                                         (filterY * sourceData.Stride);

                            blueX += (double)(pixelBuffer[calcOffset]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenX += (double)(pixelBuffer[calcOffset + 1]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redX += (double)(pixelBuffer[calcOffset + 2]) *
                                      xFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            blueY += (double)(pixelBuffer[calcOffset]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            greenY += (double)(pixelBuffer[calcOffset + 1]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];

                            redY += (double)(pixelBuffer[calcOffset + 2]) *
                                      yFilterMatrix[filterY + filterOffset,
                                              filterX + filterOffset];
                        }
                    }

                    blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY));
                    greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY));
                    redTotal = Math.Sqrt((redX * redX) + (redY * redY));

                    if (blueTotal > 255)
                    { blueTotal = 255; }
                    else if (blueTotal < 0)
                    { blueTotal = 0; }

                    if (greenTotal > 255)
                    { greenTotal = 255; }
                    else if (greenTotal < 0)
                    { greenTotal = 0; }

                    if (redTotal > 255)
                    { redTotal = 255; }
                    else if (redTotal < 0)
                    { redTotal = 0; }

                    resultBuffer[byteOffset] = (byte)(blueTotal);
                    resultBuffer[byteOffset + 1] = (byte)(greenTotal);
                    resultBuffer[byteOffset + 2] = (byte)(redTotal);
                    resultBuffer[byteOffset + 3] = 255;
                }
            }

            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                     resultBitmap.Width, resultBitmap.Height),
                                                      ImageLockMode.WriteOnly,
                                                  PixelFormat.Format32bppArgb);

            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length);
            resultBitmap.UnlockBits(resultData);

            return resultBitmap;
        }

        public static Bitmap Laplacian3x3Filter(this Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian3x3, 1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap Laplacian5x5Filter(this Bitmap sourceBitmap, 
                                                    bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                    Matrix.Laplacian5x5, 1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap LaplacianOfGaussianFilter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                  Matrix.LaplacianOfGaussian, 1.0, 0, true);

            return resultBitmap;
        }

        public static Bitmap Laplacian3x3OfGaussian3x3Filter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                   Matrix.Gaussian3x3, 1.0 / 16.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Laplacian3x3OfGaussian5x5Filter1(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type1, 1.0 / 159.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Laplacian3x3OfGaussian5x5Filter2(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type2, 1.0 / 256.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian3x3, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Laplacian5x5OfGaussian3x3Filter(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                   Matrix.Gaussian3x3, 1.0 / 16.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap,
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Laplacian5x5OfGaussian5x5Filter1(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                             Matrix.Gaussian5x5Type1, 1.0 / 159.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap,
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Laplacian5x5OfGaussian5x5Filter2(this Bitmap sourceBitmap)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                                   Matrix.Gaussian5x5Type2, 
                                                     1.0 / 256.0, 0, true);

            resultBitmap = ExtBitmap.ConvolutionFilter(resultBitmap, 
                                 Matrix.Laplacian5x5, 1.0, 0, false);

            return resultBitmap;
        }

        public static Bitmap Sobel3x3Filter(this Bitmap sourceBitmap, 
                                                bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                                 Matrix.Sobel3x3Horizontal, 
                                                   Matrix.Sobel3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap PrewittFilter(this Bitmap sourceBitmap, 
                                               bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                               Matrix.Prewitt3x3Horizontal, 
                                                 Matrix.Prewitt3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        public static Bitmap KirschFilter(this Bitmap sourceBitmap, 
                                              bool grayscale = true)
        {
            Bitmap resultBitmap = ExtBitmap.ConvolutionFilter(sourceBitmap, 
                                                Matrix.Kirsch3x3Horizontal, 
                                                  Matrix.Kirsch3x3Vertical, 
                                                        1.0, 0, grayscale);

            return resultBitmap;
        }

        //Rainbow Filter
        public static Bitmap RainbowFilter(this Bitmap sourceBitmap)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);
            int raz = sourceBitmap.Height / 4;
            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {

                    if (i < (raz))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(sourceBitmap.GetPixel(i, x).R / 5, sourceBitmap.GetPixel(i, x).G, sourceBitmap.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 2))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(sourceBitmap.GetPixel(i, x).R, sourceBitmap.GetPixel(i, x).G / 5, sourceBitmap.GetPixel(i, x).B));
                    }
                    else if (i < (raz * 3))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(sourceBitmap.GetPixel(i, x).R, sourceBitmap.GetPixel(i, x).G, sourceBitmap.GetPixel(i, x).B / 5));
                    }
                    else if (i < (raz * 4))
                    {
                        temp.SetPixel(i, x, Color.FromArgb(sourceBitmap.GetPixel(i, x).R / 5, sourceBitmap.GetPixel(i, x).G, sourceBitmap.GetPixel(i, x).B / 5));
                    }
                    else
                    {
                        temp.SetPixel(i, x, Color.FromArgb(sourceBitmap.GetPixel(i, x).R / 5, sourceBitmap.GetPixel(i, x).G / 5, sourceBitmap.GetPixel(i, x).B / 5));
                    }
                }

            }
            return temp;
        }

        //apply color filter at your own taste
        public static Bitmap CustomColorsFilter(this Bitmap sourceBitmap, int alpha, int red, int green, int blue)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //black and white filter
        public static Bitmap BlackWhiteFilter(this Bitmap sourceBitmap)
        {
            int rgb;
            Color c;

            for (int y = 0; y < sourceBitmap.Height; y++)
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    c = sourceBitmap.GetPixel(x, y);
                    rgb = (int)((c.R + c.G + c.B) / 3);
                    sourceBitmap.SetPixel(x, y, Color.FromArgb(rgb, rgb, rgb));
                }
            return sourceBitmap;
        }

        //apply color filter to swap pixel colors
        public static Bitmap SwapPixelColorsFilter(this Bitmap sourceBitmap)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A, c.G, c.B, c.R);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        //apply color filter to swap pixel colors
        public static Bitmap CustomPixelColorsFilter(this Bitmap sourceBitmap, int alpha, int red, int green, int blue)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / alpha, c.G / green, c.B / blue, c.R / red);
                    temp.SetPixel(i, x, cLayer);
                }

            }
            return temp;
        }

        public static Bitmap MegaFilter(this Bitmap sourceBitmap, int max, int min, Color co)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {

                    Color c = sourceBitmap.GetPixel(i, x);
                    if (c.G > min && c.G < max)
                    {
                        Color cLayer = Color.White;
                        temp.SetPixel(i, x, cLayer);
                    }
                    else
                    {
                        temp.SetPixel(i, x, co);
                    }

                }

            }
            return temp;
        }

        //apply magic mosaic
        public static Bitmap MagicMosaicFilter(this Bitmap sourceBitmap)
        {
            int razX = Convert.ToInt32(sourceBitmap.Width / 3);
            int razY = Convert.ToInt32(sourceBitmap.Height / 3);

            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            for (int i = 0; i < sourceBitmap.Width - 1; i++)
            {
                for (int x = 0; x < sourceBitmap.Height - 1; x++)
                {
                    if (i < razX && x < razY)
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(i, x));
                    }
                    else if (i < (razX * 2) && x < (razY))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(x, i));
                    }
                    else if (i < (razX * 3) && x < (razY))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(i, x));
                    }
                    else if (i < (razX) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(x, i));
                    }
                    else if (i < (razX) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(i, x));
                    }
                    else if (i < (razX * 2) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(i, x));
                    }
                    else if (i < (razX * 4) && x < (razY * 1))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(i, x));
                    }
                    else if (i < (razX * 4) && x < (razY * 2))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(x / 2, i / 2));
                    }
                    else if (i < (razX * 4) && x < (razY * 3))
                    {
                        temp.SetPixel(i, x, sourceBitmap.GetPixel(x / 3, i / 3));
                    }

                }

            }
            return temp;
        }
    }  
}
