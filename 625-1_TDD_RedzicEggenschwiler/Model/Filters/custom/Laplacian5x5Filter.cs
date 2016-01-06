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
            base.filterMatrix = Matrix.Laplacian5x5;
        }
    }
}
