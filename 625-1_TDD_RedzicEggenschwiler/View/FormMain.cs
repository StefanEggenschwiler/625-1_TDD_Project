using ImageConversion.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;
using System.Runtime.InteropServices;


namespace ImageConversion
{
    public partial class FormMain : Form
    {
        #region MACHADO_Atributes
        FilterController controller;
        Bitmap map;
        Bitmap mapSecond;
        Boolean Move = false;
        Boolean Selection = false;
        Boolean SelectionSecond = false;
        Point SelectedPixel;
        List<Point> points = new List<Point>();
        List<Point> pointsSecond = new List<Point>();
        Graphics MouseDown;
        Graphics MouseDownSecond;
        System.Drawing.SolidBrush myBrush;
        System.Drawing.SolidBrush myBrush2;
        System.Drawing.Image Origin;
        System.Drawing.Image FirstState;
        System.Drawing.Image FirstStateSecond;
        Color SecondPicBrush;
        int SecondPicBrushWidth;
        private Capture _capture;
        private HaarCascade _face;
        Cross2DF cross;
        Point Current;
        Point[] p = new Point[8];
        private Bitmap originalBitmap = null;
        private Bitmap previewBitmap = null;
        private Bitmap resultBitmap = null;
        private List<String> filterNames = new List<String>();
        #endregion

        public FormMain()
        {
            InitializeComponent();

            controller = new FilterController();
            cmbEdgeDetection.Items.AddRange(controller.FilterNames.ToArray());           

            cmbEdgeDetection.SelectedIndex = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Origin = pictureBox1.Image;
            Bitmap temp = new Bitmap(pictureBox1.Image,
                new Size(pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = temp;
            map = new Bitmap(pictureBox1.Image);
            Move = false;
            MouseDown = pictureBox1.CreateGraphics();
            myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
            myBrush2 = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            SecondPicBrush = Color.Black;
            SecondPicBrushWidth = 3;
        }

        #region MACHADO_FileManagement

        public void SaveImage()
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            FolderBrowserDialog fl = new FolderBrowserDialog();
            if (fl.ShowDialog() != DialogResult.Cancel)
            {

                pictureBox1.Image.Save(fl.SelectedPath + @"\" + textBox1.Text + @".png", System.Drawing.Imaging.ImageFormat.Png);
            };
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        public void LoadImage()
        {
            OpenFileDialog op = new OpenFileDialog();
            DialogResult dr = op.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string path = op.FileName;
                pictureBox1.Load(path);
                Bitmap temp = new Bitmap(pictureBox1.Image,
                   new Size(pictureBox1.Width, pictureBox1.Height));
                pictureBox1.Image = temp;
                map = new Bitmap(pictureBox1.Image);
                Origin = pictureBox1.Image;
            }
        }

        #endregion

        #region MACHADO_Behaviours

        private void OnMouseMove_Draw(int x, int y)
        {
            if (Selection)
            {
                points.Add(new Point(x, y));
                MouseDown.FillRectangle(myBrush, x, y, 1, 1);
            }
        }

        private void OnPictureBox1Click(int x, int y)
        {
            label1.Text = map.GetPixel(x, y).ToString();
            PaintColor(map.GetPixel(x, y));
            SelectedPixel = new Point(x, y);
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
            }
        }

        public void MovePictureBoxPosition(int x, int y)
        {
            if (SelectedPixel != null)
            {
                SelectedPixel = new Point(SelectedPixel.X + x, SelectedPixel.Y + y);
            }
        }

        public void OnMouseDownOnPictureBox1(int x, int y)
        {
            FirstState = pictureBox1.Image;
            Selection = true;
            MouseDown.FillRectangle(myBrush, x, y, 1, 1);
            points.Clear();
            points.Add(new Point(x, y));
        }

        public void OnMouseUpOnPictureBox1()
        {
            Brush br = new System.Drawing.SolidBrush(SecondPicBrush);
            Selection = false;
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
                    map.SetPixel(p.X, p.Y, Color.FromArgb(Convert.ToInt32(txtR.Text)
                    , Convert.ToInt32(txtG.Text)
                    , Convert.ToInt32(txtB.Text)));
                }

                pictureBox1.Image = map;
                panel1.BackColor = Color.FromArgb(Convert.ToInt32(txtR.Text)
              , Convert.ToInt32(txtG.Text)
              , Convert.ToInt32(txtB.Text));


            }
            else
            {
                pictureBox1.Image = FirstState;
            }
        }


        public void OpenColorDialog()
        {
            ColorDialog CD = new ColorDialog();
            CD.ShowDialog();
            Color newC = CD.Color;
            SecondPicBrush = newC;
        }

        public void OnMouseDownOnPictureBox2(int x, int y)
        {
            SelectionSecond = true;
            MouseDownSecond.FillEllipse(myBrush, x, y, 1, 1);

        }

        public void OnMouseUpOnPictureBox2()
        {
            SelectionSecond = false;

        }

        public void OnMouseMoveOnPictureBox2(int x, int y)
        {
            Brush br = new System.Drawing.SolidBrush(SecondPicBrush);
            if (SelectionSecond)
            {
                MouseDownSecond.FillEllipse(br, x, y, SecondPicBrushWidth, SecondPicBrushWidth);
            }
        }

        #endregion

        #region MACHADO_Events

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OnPictureBox1Click(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OnButton2Click_ChangePixelColor();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            MovePictureBoxPosition(1, 0);
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            MovePictureBoxPosition(-1, 0);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MovePictureBoxPosition(0, -1);
        }

        private void btnD_Click(object sender, EventArgs e)
        {
            MovePictureBoxPosition(0, 1);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDownOnPictureBox1(e.X, e.Y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUpOnPictureBox1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenColorDialog();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDownOnPictureBox2(e.X, e.Y);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMoveOnPictureBox2(e.X, e.Y);
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUpOnPictureBox2();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        #endregion

        #region MACHADO_ApplyFilters

        private void button8_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.DivideCrop(new Bitmap(pictureBox1.Image));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 10, 1, 1);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 1, 10, 1);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 1, 1, 25);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = ImageFilters.ApplyFilter(new Bitmap(pictureBox1.Image), 1, 1, 10, 15);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.BlackWhite(new Bitmap(pictureBox1.Image));
        }

        private void button15_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.ApplyFilterSwap(new Bitmap(pictureBox1.Image));
        }

        private void button17_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            System.Drawing.Image te = ImageFilters.ApplyFilterSwapDivide(new Bitmap(pictureBox1.Image), 1, 1, 2, 1);
            pictureBox1.Image = ImageFilters.ApplyFilterSwap(new Bitmap(te));
        }

        private void button18_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            Color c = Color.Green;
            pictureBox1.Image = ImageFilters.ApplyFilterMega(new Bitmap(pictureBox1.Image), 230, 110, c);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            Color c = Color.Blue;
            pictureBox1.Image = ImageFilters.ApplyFilterMega(new Bitmap(pictureBox1.Image), 230, 110, c);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            Color c = Color.Orange;
            pictureBox1.Image = ImageFilters.ApplyFilterMega(new Bitmap(pictureBox1.Image), 230, 110, c);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            Color c = Color.Pink;
            pictureBox1.Image = ImageFilters.ApplyFilterMega(new Bitmap(pictureBox1.Image), 230, 110, c);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.ApplyFilterMega(new Bitmap(pictureBox1.Image), 230, 110, SecondPicBrush);
        }

        private void button19_Click_1(object sender, EventArgs e)
        {
            resetCmbEdgeDetection();
            pictureBox1.Image = Origin;
            pictureBox1.Image = ImageFilters.RainbowFilter(new Bitmap(pictureBox1.Image));
        }

        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cmbEdgeDetection_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyEdgeDetectionFilter();
        }

        private void ApplyEdgeDetectionFilter()
        {

            Bitmap selectedSource = null;
            Bitmap bitmapResult = null;

            if (Origin != null)
            {
                selectedSource = new Bitmap(Origin);
                pictureBox1.Image = Origin;

                if (cmbEdgeDetection.SelectedItem.ToString() == "None")
                {
                    bitmapResult = selectedSource;
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 3x3")
                {
                    bitmapResult = selectedSource.Laplacian3x3Filter(false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 3x3 Grayscale")
                {
                    bitmapResult = selectedSource.Laplacian3x3Filter(true);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 5x5")
                {
                    bitmapResult = selectedSource.Laplacian5x5Filter(false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 5x5 Grayscale")
                {
                    bitmapResult = selectedSource.Laplacian5x5Filter(true);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian of Gaussian")
                {
                    bitmapResult = selectedSource.LaplacianOfGaussianFilter();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 3x3 of Gaussian 3x3")
                {
                    bitmapResult = selectedSource.Laplacian3x3OfGaussian3x3Filter();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 3x3 of Gaussian 5x5 - 1")
                {
                    bitmapResult = selectedSource.Laplacian3x3OfGaussian5x5Filter1();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 3x3 of Gaussian 5x5 - 2")
                {
                    bitmapResult = selectedSource.Laplacian3x3OfGaussian5x5Filter2();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 5x5 of Gaussian 3x3")
                {
                    bitmapResult = selectedSource.Laplacian5x5OfGaussian3x3Filter();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 5x5 of Gaussian 5x5 - 1")
                {
                    bitmapResult = selectedSource.Laplacian5x5OfGaussian5x5Filter1();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Laplacian 5x5 of Gaussian 5x5 - 2")
                {
                    bitmapResult = selectedSource.Laplacian5x5OfGaussian5x5Filter2();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Sobel 3x3")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter(false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Sobel 3x3 Grayscale")
                {
                    bitmapResult = selectedSource.Sobel3x3Filter();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt")
                {
                    bitmapResult = selectedSource.PrewittFilter(false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Prewitt Grayscale")
                {
                    bitmapResult = selectedSource.PrewittFilter();
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch")
                {
                    bitmapResult = selectedSource.KirschFilter(false);
                }
                else if (cmbEdgeDetection.SelectedItem.ToString() == "Kirsch Grayscale")
                {
                    bitmapResult = selectedSource.KirschFilter();
                }
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

        private void resetCmbEdgeDetection()
        {
            cmbEdgeDetection.SelectedIndex = 0;
        }

    }
}
