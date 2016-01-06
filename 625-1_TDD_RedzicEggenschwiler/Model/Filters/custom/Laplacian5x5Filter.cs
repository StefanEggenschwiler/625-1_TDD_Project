using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Laplacian5x5Filter : SingleConvolutionFilter
    {
        public Laplacian5x5Filter(bool grayscale)
        {
            base.grayscale = grayscale;
        }

        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.filterMatrix = Matrix.Laplacian5x5;
            return base.applyFilter(sourceBitmap, red, green, blue, color);
        }
    }
}
