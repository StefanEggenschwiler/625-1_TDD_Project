using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class MagicMosaicFilter : IFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
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
