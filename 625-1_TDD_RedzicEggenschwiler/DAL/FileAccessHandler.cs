using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageConversion.DAL
{
    public class FileAccessHandler : IFileAccessHandler
    {

        public Boolean SaveImage(Image image, string name, string path)
        {
            if (image == null || path == null)
            {
                return false;
            }

            image.Save(path + @"\" + name + @".png", System.Drawing.Imaging.ImageFormat.Png);
            return true;
        }

        public System.Drawing.Image LoadImage(PictureBox pictureBox, System.Drawing.Bitmap map)
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                pictureBox.Load(path);
                Bitmap temp = new Bitmap(pictureBox.Image);
                pictureBox.Image = temp;
                pictureBox.Size = pictureBox.Image.Size;
                map = new Bitmap(pictureBox.Image);
                return pictureBox.Image;
            }
            return null;
        }
    }
}
