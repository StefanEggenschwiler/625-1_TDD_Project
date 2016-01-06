using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace ImageConversion.Model
{
    public interface IFilter
    {
        Bitmap applyFilter(Bitmap sourceBitmap, int alpha, int red, int green, int blue, Color color);
    }
}
