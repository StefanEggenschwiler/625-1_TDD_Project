using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Laplacian3x3Filter : SingleConvolutionFilter
    {
        public Laplacian3x3Filter(bool grayscale)
        {
            base.grayscale = grayscale;
        }

        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.filterMatrix = Matrix.Laplacian3x3;
            return base.applyFilter(sourceBitmap, red, green, blue, color);
        }
    }
}
