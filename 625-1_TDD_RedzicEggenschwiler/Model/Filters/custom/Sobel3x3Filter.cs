using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model.Filters
{
    public class Sobel3x3Filter : MultiConvolutionFilter
    {
        public Sobel3x3Filter(bool grayscale)
        {
            base.grayscale = grayscale;
        }

        public Bitmap applyFilter(Bitmap sourceBitmap, int red, int green, int blue, Color color)
        {
            base.xFilterMatrix = Matrix.Sobel3x3Horizontal;
            base.yFilterMatrix = Matrix.Sobel3x3Vertical;
            return base.applyFilter(sourceBitmap, red, green, blue, color);
        }
    }
}
