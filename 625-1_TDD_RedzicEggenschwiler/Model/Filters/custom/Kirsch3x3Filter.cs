﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Kirsch3x3Filter : MultiConvolutionFilter
    {
        public Kirsch3x3Filter(bool grayscale)
        {
            base.grayscale = grayscale;
        }

        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.xFilterMatrix = Matrix.Kirsch3x3Horizontal;
            base.yFilterMatrix = Matrix.Kirsch3x3Vertical;
            return base.applyFilter(sourceBitmap, red, green, blue, color);
        }
    }
}