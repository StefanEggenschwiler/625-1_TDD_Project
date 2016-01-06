using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConversion.DAL
{
    public interface IFileAccessHandler
    {
        Image LoadImage(PictureBox pictureBox, Bitmap map);
        Boolean SaveImage(Image image, string name);
    }
}
