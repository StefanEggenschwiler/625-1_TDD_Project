using ImageConversion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using ImageConversion.DAL;


namespace ImageConversion
{
    public partial class FormMain : Form
    {
        #region Attributes
        FilterController controller;
        FileAccessHandler fileAccessHandler;
        Bitmap map;
        Point SelectedPixel;
        List<Point> points = new List<Point>();
        #endregion

        public FormMain()
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            controller = new FilterController();
            fileAccessHandler = new FileAccessHandler();
            initializeColorPanel();

            cmbEdgeDetection.Items.AddRange(controller.FilterNames.ToArray());
            cmbEdgeDetection.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            controller.Origin = pictureBox1.Image;
            Bitmap temp = new Bitmap(pictureBox1.Image);
            pictureBox1.Image = temp;
            pictureBox1.Size = pictureBox1.Image.Size;
            map = new Bitmap(controller.Origin);
        }

        #region Behaviours
        public Boolean OnPictureBox1Click(int x, int y)
        {
            if (x >= 0 || y >= 0)
            {
                label1.Text = map.GetPixel(x, y).ToString();
                PaintColor(map.GetPixel(x, y));
                SelectedPixel = new Point(x, y);

                txtR.Text = map.GetPixel(x, y).R.ToString();
                txtG.Text = map.GetPixel(x, y).G.ToString();
                txtB.Text = map.GetPixel(x, y).B.ToString();

                controller.Red = map.GetPixel(x, y).R;
                controller.Green = map.GetPixel(x, y).G;
                controller.Blue = map.GetPixel(x, y).B;
                controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);
                if (!controller.Color.IsEmpty)
                {
                    return true;
                }
                
            }
            return false;

        }

        private void PaintColor(Color c)
        {
            panel1.BackColor = c;
        }

        public void OnButton2Click_ChangePixelColor()
        {
            if (!string.IsNullOrEmpty(txtB.Text)
                && !string.IsNullOrEmpty(txtR.Text)
                && !string.IsNullOrEmpty(txtG.Text)
                && Convert.ToInt32(txtR.Text) >= 0
                && Convert.ToInt32(txtG.Text) >= 0
                && Convert.ToInt32(txtB.Text) >= 0
                && Convert.ToInt32(txtR.Text) <= 255
                && Convert.ToInt32(txtG.Text) <= 255
                && Convert.ToInt32(txtB.Text) <= 255
                )
            {
                map.SetPixel(SelectedPixel.X, SelectedPixel.Y, Color.FromArgb(Convert.ToInt32(txtR.Text)
              , Convert.ToInt32(txtG.Text)
              , Convert.ToInt32(txtB.Text)));
                pictureBox1.Image = map;
                panel1.BackColor = Color.FromArgb(Convert.ToInt32(txtR.Text)
              , Convert.ToInt32(txtG.Text)
              , Convert.ToInt32(txtB.Text));
                controller.Red = Convert.ToInt32(txtR.Text);
                controller.Green = Convert.ToInt32(txtG.Text);
                controller.Blue = Convert.ToInt32(txtB.Text);
                controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);
            }
            else
            {
                controller.Red = 0;
                controller.Green = 0;
                controller.Blue = 0;
                controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);
            }
        }

        public void OnMouseUpOnPictureBox1()
        {
            Point[] pointsArray = new Point[points.Count];
            Bitmap MagicSel = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            if (!string.IsNullOrEmpty(txtB.Text)
                && !string.IsNullOrEmpty(txtR.Text)
                && !string.IsNullOrEmpty(txtG.Text)
                && Convert.ToInt32(txtR.Text) >= 0
                && Convert.ToInt32(txtG.Text) >= 0
                && Convert.ToInt32(txtB.Text) >= 0
                && Convert.ToInt32(txtR.Text) <= 255
                && Convert.ToInt32(txtG.Text) <= 255
                && Convert.ToInt32(txtB.Text) <= 255
                )
            {
                foreach (Point p in points)
                {
                    map.SetPixel(p.X, p.Y, Color.FromArgb(
                      Convert.ToInt32(txtR.Text)
                    , Convert.ToInt32(txtG.Text)
                    , Convert.ToInt32(txtB.Text)));
                }

                pictureBox1.Image = map;
                panel1.BackColor = Color.FromArgb(Convert.ToInt32(txtR.Text)
              , Convert.ToInt32(txtG.Text)
              , Convert.ToInt32(txtB.Text));
                controller.Red = Convert.ToInt32(txtR.Text);
                controller.Green = Convert.ToInt32(txtG.Text);
                controller.Blue = Convert.ToInt32(txtB.Text);
                controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);
            }
            else
            {
                controller.Red = 0;
                controller.Green = 0;
                controller.Blue = 0;
                controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);
            }
        }

        private void ApplyEdgeDetectionFilter()
        {
            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (controller.Origin != null)
            {
                selectedSource = new Bitmap(controller.Origin);
                pictureBox1.Image = controller.Origin;

                bitmapResult = controller.executeFilter(cmbEdgeDetection.SelectedItem.ToString());
            }
            else
            {
                return;
            }

            if (bitmapResult != null)
            {
                pictureBox1.Image = bitmapResult;
            }
        }
        #endregion

        #region Events
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OnPictureBox1Click(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Origin = fileAccessHandler.LoadImage(pictureBox1, map);
            pictureBox1.Image = controller.Origin;
            map = new Bitmap(controller.Origin);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnButton2Click_ChangePixelColor();
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUpOnPictureBox1();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter a name for your image");
            }
            else
            {
                FolderBrowserDialog fl = new FolderBrowserDialog();
                if (fl.ShowDialog() != DialogResult.Cancel)
                {
                    fileAccessHandler.SaveImage(pictureBox1.Image, textBox1.Text, fl.SelectedPath);
                }
            }
        }
        
        private void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyEdgeDetectionFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            initializeColorPanel();
        }

        private void initializeColorPanel()
        {
            txtR.Text = 1 + "";
            txtG.Text = 1 + "";
            txtB.Text = 1 + "";

            controller.Red = 1;
            controller.Green = 1;
            controller.Blue = 1;
            controller.Color = Color.FromArgb(controller.Red, controller.Green, controller.Blue);

            PaintColor(controller.Color);
        }
        #endregion
    }
}
