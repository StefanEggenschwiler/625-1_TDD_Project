using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class ColorFilter : IFilter
    {
        protected bool Swap = false;

        public virtual Bitmap applyFilter(Bitmap sourceBitmap, int alpha, int red, int green, int blue, Color color)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer;
                    if (Swap)
                    {
                        cLayer = Color.FromArgb(c.A / alpha, c.G / green, c.B / blue, c.R / red);
                    }
                    else
                    {
                        cLayer = Color.FromArgb(c.A / alpha, c.R / red, c.G / green, c.B / blue);
                    }
                    temp.SetPixel(i, x, cLayer);
                }
            }
            return temp;
        }
    }
}
