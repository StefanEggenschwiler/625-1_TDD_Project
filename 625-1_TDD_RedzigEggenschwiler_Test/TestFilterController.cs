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
        public void TestAlpha()
        {
            int alpha = 255;
            var controller = new FilterController();

            controller.Alpha = alpha;
            Assert.AreEqual(controller.Alpha, alpha);
        }

        [TestMethod]
        public void TestRed()
        {
            int red = 100;
            var controller = new FilterController();

            controller.Red = red;
            Assert.AreEqual(controller.Red, red);
        }

        [TestMethod]
        public void TestGreen()
        {
            int green = 110;
            var controller = new FilterController();

            controller.Green = green;
            Assert.AreEqual(controller.Green, green);
        }

        [TestMethod]
        public void TestBlue()
        {
            int blue = 200;
            var controller = new FilterController();

            controller.Blue = blue;
            Assert.AreEqual(controller.Blue, blue);
        }

        [TestMethod]
        public void TestFilterNames()
        {
            List<string> filters = new List<string>(new string[] { "None", "Mega Filter Custom", "Laplacian 5x5 of Gaussian 3x3" });
            var controller = new FilterController();

            CollectionAssert.IsSubsetOf(filters, controller.FilterNames);
        }

        [TestMethod]
        public void TestOrigin()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImage")));
            var controller = new FilterController();

            controller.Origin = testImage;
            Assert.AreEqual(controller.Origin, testImage);
        }

        [TestMethod]
        public void TestAddFilter()
        {
            var controller = new FilterController();
            var filter = Substitute.For<IFilter>();
            String filterName = "Filter 1";

            controller.addFilter(filterName, filter);


        }

        [TestMethod]
        public void TestExecuteFilter1()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImage")));
            var controller = Substitute.For<IFilterController>();

            controller.executeFilter("Filter 1").Returns(testImage);

            Assert.AreEqual(controller.executeFilter("Filter 1"), testImage);
        }

        [TestMethod]
        public void TestExecuteFilter2()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImage")));
            var controller = Substitute.For<IFilterController>();

            controller.executeFilter("Filter 1").Returns(testImage);

            Assert.AreEqual(controller.executeFilter("Filter 1"), testImage);
        }
    }
}
