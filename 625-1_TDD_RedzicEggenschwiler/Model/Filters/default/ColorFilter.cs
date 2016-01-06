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
        protected int Alpha = 1;

        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {
                    Color c = sourceBitmap.GetPixel(i, x);
                    Color cLayer = Color.FromArgb(c.A / Alpha, c.R / red, c.G / green, c.B / blue);
                    temp.SetPixel(i, x, cLayer);
                }
            }
            return temp;
        }
    }
}
