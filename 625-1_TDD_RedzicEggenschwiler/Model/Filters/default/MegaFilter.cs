using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class MegaFilter : IFilter
    {
        protected int Min = 110;
        protected int Max = 230;

        public virtual Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            Bitmap temp = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);

            for (int i = 0; i < sourceBitmap.Width; i++)
            {
                for (int x = 0; x < sourceBitmap.Height; x++)
                {

                    Color c = sourceBitmap.GetPixel(i, x);
                    if (c.G > Min && c.G < Max)
                    {
                        Color cLayer = Color.White;
                        temp.SetPixel(i, x, cLayer);
                    }
                    else
                    {
                        temp.SetPixel(i, x, color);
                    }

                }

            }
            return temp;
        }
    }
}
