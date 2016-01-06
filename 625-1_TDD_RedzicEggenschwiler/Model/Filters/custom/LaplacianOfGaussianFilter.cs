﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class LaplacianOfGaussianFilter : SingleConvolutionFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.filterMatrix = Matrix.LaplacianOfGaussian;
            base.grayscale = true;
            return base.applyFilter(sourceBitmap, red, green, blue, color);
        }
    }
}
