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

        public void SaveImage(System.Drawing.Image image, string name)
        {
            if(image == null){
                return;
            }
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() != DialogResult.Cancel)
            {

                image.Save(fl.SelectedPath + @"\" + name + @".png", System.Drawing.Imaging.ImageFormat.Png);
            };
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
