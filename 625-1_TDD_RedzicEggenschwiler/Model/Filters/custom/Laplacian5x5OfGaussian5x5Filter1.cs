﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Laplacian5x5OfGaussian5x5Filter1 : SingleConvolutionFilter
    {
        public override Bitmap applyFilter(Bitmap sourceBitmap, int alpha, int red, int green, int blue, Color color)
        {
            base.factor = 1.0 / 159.0;
            base.grayscale = true;
            base.filterMatrix = Matrix.Gaussian5x5Type1;
            Bitmap tmp = base.applyFilter(sourceBitmap, alpha, red, green, blue, color);

            base.factor = 1.0;
            base.grayscale = false;
            base.filterMatrix = Matrix.Laplacian5x5;
            return base.applyFilter(tmp, alpha, red, green, blue, color);
        }
    }
}
