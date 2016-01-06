using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class MegaFilterPink : MegaFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            return base.applyFilter(sourceBitmap, red, green, blue, Color.Pink);
        }
    }
}
