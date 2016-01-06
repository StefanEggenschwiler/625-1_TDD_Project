using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageConversion.Model
{
    public interface IFilterController
    {
        List<String> FilterNames { get; }
        Image Origin { get; set; }
        int Alpha { get; set; }
        int Red { get; set; }
        int Green { get; set; }
        int Blue { get; set; }
        Color Color { get; set; }

        Bitmap executeFilter(String filterName);
    }
}
