using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Laplacian3x3OfGaussian3x3Filter : SingleConvolutionFilter
    {
        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.factor = 1.0 / 16.0;
            base.grayscale = true;
            base.filterMatrix = Matrix.Gaussian3x3;
            Bitmap tmp = base.applyFilter(sourceBitmap, red, green, blue, color);

            base.factor = 1.0;
            base.grayscale = false;
            base.filterMatrix = Matrix.Laplacian3x3;
            return base.applyFilter(tmp, red, green, blue, color);
        }
    }
}
