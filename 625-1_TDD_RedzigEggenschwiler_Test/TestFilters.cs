using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using NSubstitute;
using ImageConversion.Model;
using ImageConversion.Model.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _625_1_TDD_RedzigEggenschwiler_Test
{
    [TestClass]
    public class TestFilters
    {
        [TestMethod]
        public void TestColorFilterCrazy()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageCrazy")));

            IFilter testFilter = new ColorFilterCrazy();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestColorFilterHell()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageHell")));

            IFilter testFilter = new ColorFilterHell();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestColorFilterMiami()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMiami")));

            IFilter testFilter = new ColorFilterMiami();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestColorFilterNight()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageNight")));

            IFilter testFilter = new ColorFilterNight();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestColorFilterSwap()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageSwap")));

            IFilter testFilter = new ColorFilterSwap();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestColorFilterZen()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageZen")));

            IFilter testFilter = new ColorFilterZen();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestKirsch3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageKirsch3x3")));

            IFilter testFilter = new Kirsch3x3Filter(false);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestPrewitt3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImagePrewitt3x3")));

            IFilter testFilter = new Prewitt3x3Filter(false);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestPrewitt3x3Grayscale()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImagePrewitt3x3Grayscale")));

            IFilter testFilter = new Prewitt3x3Filter(true);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestSobel3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageSobel3x3")));

            IFilter testFilter = new Sobel3x3Filter(false);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestSobel3x3Grayscale()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageSobel3x3Grayscale")));

            IFilter testFilter = new Sobel3x3Filter(true);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestKirsch3x3Grayscale()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageKirsch3x3Grayscale")));

            IFilter testFilter = new Kirsch3x3Filter(true);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian3x3")));

            IFilter testFilter = new Laplacian3x3Filter(false);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian3x3Grayscale()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian3x3Grayscale")));

            IFilter testFilter = new Laplacian3x3Filter(true);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian3x3OfGaussian3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian3x3OfGaussian3x3")));

            IFilter testFilter = new Laplacian3x3OfGaussian3x3Filter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian3x3OfGaussian5x5Filter1()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian3x3OfGaussian5x5Filter1")));

            IFilter testFilter = new Laplacian3x3OfGaussian5x5Filter1();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian3x3OfGaussian5x5Filter2()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian3x3OfGaussian5x5Filter2")));

            IFilter testFilter = new Laplacian3x3OfGaussian5x5Filter2();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian5x5()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian5x5")));

            IFilter testFilter = new Laplacian5x5Filter(false);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian5x5Grayscale()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian5x5Grayscale")));

            IFilter testFilter = new Laplacian5x5Filter(true);
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian5x5OfGaussian3x3()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian5x5OfGaussian3x3")));

            IFilter testFilter = new Laplacian5x5OfGaussian3x3Filter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian5x5OfGaussian5x5Filter1()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian5x5OfGaussian5x5Filter1")));

            IFilter testFilter = new Laplacian5x5OfGaussian5x5Filter1();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacian5x5OfGaussian5x5Filter2()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacian5x5OfGaussian5x5Filter2")));

            IFilter testFilter = new Laplacian5x5OfGaussian5x5Filter2();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestLaplacianOfGaussian()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageLaplacianOfGaussian")));

            IFilter testFilter = new LaplacianOfGaussianFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMegaFilterCustom()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMegaFilterCustom")));

            IFilter testFilter = new MegaFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, Color.Firebrick);

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMegaFilterBlue()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMegaFilterBlue")));

            IFilter testFilter = new MegaFilterBlue();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMegaFilterGreen()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMegaFilterGreen")));

            IFilter testFilter = new MegaFilterGreen();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMegaFilterOrange()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMegaFilterOrange")));

            IFilter testFilter = new MegaFilterOrange();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMegaFilterPink()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMegaFilterPink")));

            IFilter testFilter = new MegaFilterPink();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestBlackWhite()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageBlackWhite")));

            IFilter testFilter = new BlackWhiteFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestMagicMosaic()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageMagicMosaic")));

            IFilter testFilter = new MagicMosaicFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestRainbow()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));
            Bitmap testImageFiltered = ((System.Drawing.Bitmap)(resources.GetObject("testImageRainbow")));

            IFilter testFilter = new RainbowFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageFiltered.Width; x++)
            {
                for (int y = 0; y < testImageFiltered.Height; y++)
                {
                    if (testImageFiltered.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestReset()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImageOrigin = ((System.Drawing.Bitmap)(resources.GetObject("testImageOrigin")));

            IFilter testFilter = new ResetFilter();
            Bitmap tmp = testFilter.applyFilter(testImageOrigin, 0, 0, 0, 0, new Color());

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImageOrigin.Width; x++)
            {
                for (int y = 0; y < testImageOrigin.Height; y++)
                {
                    if (testImageOrigin.GetPixel(x, y) != tmp.GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }
            Assert.IsTrue(equal);
        }
    }
}
