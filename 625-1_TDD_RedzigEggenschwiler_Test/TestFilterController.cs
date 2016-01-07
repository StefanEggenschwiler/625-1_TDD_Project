using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using NSubstitute;
using ImageConversion.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _625_1_TDD_RedzigEggenschwiler_Test
{
    [TestClass]
    public class TestFilterController
    {
        [TestMethod]
        public void TestOrigin()
        {
            // Load image from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImageOrigin")));
            FilterController controller = new FilterController();

            controller.Origin = testImage;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(testImage, controller.Origin);
        }

        [TestMethod]
        public void TestColor()
        {
            Color testColor = Color.BlanchedAlmond;
            FilterController controller = new FilterController();

            controller.Color = testColor;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(testColor, controller.Color);
        }

        [TestMethod]
        public void TestAlpha()
        {
            int alpha = 255;
            FilterController controller = new FilterController();

            controller.Alpha = alpha;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(alpha, controller.Alpha);
        }

        [TestMethod]
        public void TestRed()
        {
            int red = 100;
            FilterController controller = new FilterController();

            controller.Red = red;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(red, controller.Red);
        }

        [TestMethod]
        public void TestGreen()
        {
            int green = 110;
            FilterController controller = new FilterController();

            controller.Green = green;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(green, controller.Green);
        }

        [TestMethod]
        public void TestBlue()
        {
            int blue = 200;
            FilterController controller = new FilterController();

            controller.Blue = blue;

            // We check if the correct value was stored in the controller
            Assert.AreEqual(blue, controller.Blue);
        }

        [TestMethod]
        public void TestFilterNames()
        {
            List<string> filters = new List<string>(new string[] { "None", "Mega Filter Custom", "Laplacian 5x5 of Gaussian 3x3" });
            FilterController controller = new FilterController();

            // We check if the filterlist contains our list of filters
            CollectionAssert.IsSubsetOf(filters, controller.FilterNames);
        }

        [TestMethod]
        public void TestAddFilter()
        {
            FilterController controller = new FilterController();
            var filter = Substitute.For<IFilter>();
            String filterName = "Filter 1";

            controller.addFilter(filterName, filter);

            // We check if the new filter is added to the controller.
            CollectionAssert.Contains(controller.FilterNames, filterName);
        }

        [TestMethod]
        public void TestExecuteFilter1()
        {
            // We receive the testImage from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImage = new Bitmap(((System.Drawing.Image)(resources.GetObject("testImageOrigin"))));

            FilterController controller = new FilterController();
            controller.Origin = testImage;

            var filter = Substitute.For<IFilter>();
            String filterName = "Filter 1";

            // We add the fresh created filter to the controller
            controller.addFilter(filterName, filter);

            // We execute the filter
            controller.executeFilter(filterName);

            /* 
             * We check if the substitute has received a call "applyFilter"
             * aka if "executeFilter" has tried to execute the correct filter
             */
            filter.Received().applyFilter(Arg.Any<Bitmap>(), 0, 0, 0, 0, new Color());
        }

        [TestMethod]
        public void TestExecuteFilter2()
        {
            // We receive the testImage from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Bitmap testImage = new Bitmap(((System.Drawing.Image)(resources.GetObject("testImageOrigin"))));
            String filterName = "None";

            FilterController controller = new FilterController();
            controller.Origin = testImage;

            // We check if the resulted image is equal to the testImage
            bool equal = true;
            for (int x = 0; x < testImage.Width; x++)
            {
                for (int y = 0; y < testImage.Height; y++)
                {
                    if (testImage.GetPixel(x, y) != ((Bitmap)controller.Origin).GetPixel(x, y))
                    {
                        equal = false;
                    }
                }
            }

            Assert.IsTrue(equal);
        }

        [TestMethod]
        public void TestExecuteFilter3()
        {
            // We receive the testImage from Resource file.
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImageOrigin")));
            var controller = Substitute.For<IFilterController>();

            controller.executeFilter("Filter 1").Returns(testImage);

            Assert.AreEqual(testImage, controller.executeFilter("Filter 1"));
        }
    }
}
