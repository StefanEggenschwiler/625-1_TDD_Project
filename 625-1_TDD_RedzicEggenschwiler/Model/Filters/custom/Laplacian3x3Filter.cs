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
            base.filterMatrix = Matrix.Laplacian3x3;
        }
    }
}
