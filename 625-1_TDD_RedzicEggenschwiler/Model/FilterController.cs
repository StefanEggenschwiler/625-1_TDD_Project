using ImageConversion.Model.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace ImageConversion.Model
{
    public class FilterController
    {
        public List<String> FilterNames { get { return _filterNames; } }
        public Image Origin { get { return _origin; } set { _origin = value; } }
        public int Alpha { get { return _alpha; } set { _alpha = value; } }
        public int Red { get { return _red;} set { _red = value; } }
        public int Green { get { return _green;} set { _green = value; } }
        public int Blue { get { return _blue;} set { _blue = value; } }
        public Color Color { get { return _color; } set { _color = value; } }

        private Dictionary<String, IFilter> _filters;
        private List<String> _filterNames = new List<String>();
        private Image _origin;
        private int _alpha = 0;
        private int _red = 0;
        private int _green = 0;
        private int _blue = 0;
        private Color _color = new Color();

        public FilterController()
        {
            initializeFilters();
            _filterNames.AddRange(_filters.Keys);
        }

        private void initializeFilters()
        {
            _filters = new Dictionary<String, IFilter>();
            _filters.Add("None", new ResetFilter());
            _filters.Add("Magic Mosaic", new MagicMosaicFilter());
            _filters.Add("Rainbow Filter", new RainbowFilter());
            _filters.Add("Mega Filter Custom", new MegaFilter());
            _filters.Add("Mega Filter Pink", new MegaFilterPink());
            _filters.Add("Mega Filter Orange", new MegaFilterOrange());
            _filters.Add("Mega Filter Green", new MegaFilterGreen());
            _filters.Add("Mega Filter Blue", new MegaFilterBlue());
            _filters.Add("Black and White", new BlackWhiteFilter());
            _filters.Add("Crazy Filter", new ColorFilterCrazy());
            _filters.Add("Swap Filter", new ColorFilterSwap());
            _filters.Add("Zen Filter", new ColorFilterZen());
            _filters.Add("Miami Filter", new ColorFilterMiami());
            _filters.Add("Hell Filter", new ColorFilterHell());
            _filters.Add("Night Filter", new ColorFilterNight());

            _filters.Add("Laplacian 3x3", new Laplacian3x3Filter(false));
            _filters.Add("Laplacian 3x3 Grayscale", new Laplacian3x3Filter(true));
            _filters.Add("Laplacian 5x5", new Laplacian5x5Filter(false));
            _filters.Add("Laplacian 5x5 Grayscale", new Laplacian5x5Filter(true));
            _filters.Add("Laplacian of Gaussian", new LaplacianOfGaussianFilter());
            _filters.Add("Laplacian 3x3 of Gaussian 3x3", new Laplacian3x3OfGaussian3x3Filter());
            _filters.Add("Laplacian 3x3 of Gaussian 5x5 - 1", new Laplacian3x3OfGaussian5x5Filter1());
            _filters.Add("Laplacian 3x3 of Gaussian 5x5 - 2", new Laplacian3x3OfGaussian5x5Filter2());
            _filters.Add("Laplacian 5x5 of Gaussian 3x3", new Laplacian5x5OfGaussian3x3Filter());
            _filters.Add("Laplacian 5x5 of Gaussian 5x5 - 1", new Laplacian5x5OfGaussian5x5Filter1());
            _filters.Add("Laplacian 5x5 of Gaussian 5x5 - 2", new Laplacian5x5OfGaussian5x5Filter2());
            _filters.Add("Sobel 3x3", new Sobel3x3Filter(false));
            _filters.Add("Sobel 3x3 Grayscale", new Sobel3x3Filter(true));
            _filters.Add("Prewitt", new Prewitt3x3Filter(false));
            _filters.Add("Prewitt Grayscale", new Prewitt3x3Filter(true));
            _filters.Add("Kirsch", new Kirsch3x3Filter(false));
            _filters.Add("Kirsch Grayscale", new Kirsch3x3Filter(true));
        }

        public Bitmap executeFilter(String filterName)
        {
            IFilter temp;
            _filters.TryGetValue(filterName, out temp);
            return temp.applyFilter(new Bitmap(_origin), _alpha, _red, _green, _blue, _color);
        }
    }
}
