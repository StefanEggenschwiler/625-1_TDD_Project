using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class BlackWhiteFilter : IFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int alpha, int red, int green, int blue, Color color)
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
    }
}
