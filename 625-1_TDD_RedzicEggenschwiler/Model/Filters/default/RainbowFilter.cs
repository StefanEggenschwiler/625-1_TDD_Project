using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class RainbowFilter : IFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
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
    }
}
