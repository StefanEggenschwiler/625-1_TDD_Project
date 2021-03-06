﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class MegaFilterPink : MegaFilter
    {
        public override Bitmap applyFilter(Bitmap sourceBitmap, int alpha, int red, int green, int blue, Color color)
        {
            return base.applyFilter(sourceBitmap, 1, 1, 1, 1, Color.Pink);
        }
    }
}
