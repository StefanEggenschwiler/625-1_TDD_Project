using ImageConversion.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageConversion.Controller
{
    interface IController
    {
        void loadImage();
        void saveImage();

        void applyFilter(IFilter filter);
        void resetFilter();

        void setRGB(int red, int green, int blue);
        void resetRGB();
    }

    public class IncController : IController
    {

        public void loadImage()
        {
            throw new NotImplementedException();
        }

        public void saveImage()
        {
            throw new NotImplementedException();
        }

        public void applyFilter(IFilter filter)
        {
            throw new NotImplementedException();
        }

        public void resetFilter()
        {
            throw new NotImplementedException();
        }

        public void setRGB(int red, int green, int blue)
        {
            throw new NotImplementedException();
        }

        public void resetRGB()
        {
            throw new NotImplementedException();
        }
    }
}
