using ImageConversion.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _625_1_TDD_RedzigEggenschwiler_Test
{
    [TestClass]
    public class TestFileAccessHandler
    {
        [TestMethod]
        public void TestLoadImage()
        {
            //load test image
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImage")));
            //create test components
            PictureBox pb = new PictureBox();
            pb.Image = testImage;
            Bitmap map = new Bitmap(testImage);
            //substitute
            var fileAccessHandler = Substitute.For<IFileAccessHandler>();
            fileAccessHandler.LoadImage(pb, map).Returns(testImage);
            Assert.AreEqual(testImage, fileAccessHandler.LoadImage(pb, map));
        }

        [TestMethod]
        public void TestSaveImage()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Resources));
            Image testImage = ((System.Drawing.Image)(resources.GetObject("testImage")));

            var fileAccessHandler = Substitute.For<IFileAccessHandler>();
            Assert.AreEqual(false, fileAccessHandler.SaveImage(testImage, "test", "C:/"));
        }
    }
}
