using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocumentEditorLib;
using System.IO;
using System.Drawing;

namespace DocumentEditorTest
{
    [TestClass]
    public class ImageTests
    {
        private readonly string _currImageFolder = Path.GetFullPath(
            Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\test-image\"));

        public void AreImagesEqual(Img img, bool isValidityExpected, string expectedPath, int expectedHeight, int expectedWidth)
        {
            Assert.AreEqual(img.IsImageValid(), isValidityExpected);
            Assert.AreEqual(img.GetPath(), expectedPath);
            Assert.AreEqual(img.GetHeight(), expectedHeight);
            Assert.AreEqual(img.GetWidth(), expectedWidth);
        }

        [TestMethod]
        public void HasProperties()
        {
            string path = _currImageFolder + "cat.png";

            Image image = new Bitmap(path);
            AreImagesEqual(new Img(path), true, path, image.Height, image.Width);
        }

        [TestMethod]
        public void PictureIsNotLoadedWithWrongPath()
        {
            string path = _currImageFolder + "none-exists-image.png";
            AreImagesEqual(new Img(path), false, null, 0, 0);
        }

        [TestMethod]
        public void PictureDoesNotLoadLargerThan10000Pixels()
        {
            string path = _currImageFolder + "h1-w10001.png";
            AreImagesEqual(new Img(path), false, null, 0, 0);

            string path2 = _currImageFolder + "h10001-w1.png";
            AreImagesEqual(new Img(path2), false, null, 0, 0);
        }

        [TestMethod]
        public void PictureLoadedLessThan10000Pixels()
        {
            string path = _currImageFolder + "h1-w10000.png";
            AreImagesEqual(new Img(path), true, path, 1, 10000);

            string path2 = _currImageFolder + "h10000-w1.png";
            AreImagesEqual(new Img(path2), true, path2, 10000, 1);

            string path3 = _currImageFolder + "h1-w9999.png";
            AreImagesEqual(new Img(path3), true, path3, 1, 9999);

            string path4 = _currImageFolder + "h9999-w1.png";
            AreImagesEqual(new Img(path4), true, path4, 9999, 1);
        }
        
        [TestMethod]
        public void CannotBeSetNegativeOrLargerThan10000PixelsSides()
        {
            string path = _currImageFolder + "cat.png";
            AreImagesEqual(new Img(path, -1), false, null, 0, 0);
            AreImagesEqual(new Img(path, -1, -1), false, null, 0, 0);
            AreImagesEqual(new Img(path, null, -1), false, null, 0, 0);

            AreImagesEqual(new Img(path, 10001), false, null, 0, 0);
            AreImagesEqual(new Img(path, 10001, 10001), false, null, 0, 0);
            AreImagesEqual(new Img(path, null, 10001), false, null, 0, 0);
        }

        [TestMethod]
        public void CannotSetSidesLessThanZeroOrMoreThan10000Pixels()
        {
            string path = _currImageFolder + "cat.png";
            Img img = new Img(path, 300, 200);
            AreImagesEqual(img, true, path, 300, 200);

            img.Resize(350, 250);
            AreImagesEqual(img, true, path, 350, 250);

            img.Resize(-1, 250);
            AreImagesEqual(img, true, path, 350, 250);

            img.Resize(250, -1);
            AreImagesEqual(img, true, path, 350, 250);

            img.Resize(-1, -1);
            AreImagesEqual(img, true, path, 350, 250);


            img.Resize(10000, 250);
            AreImagesEqual(img, true, path, 10000, 250);

            img.Resize(250, 10000);
            AreImagesEqual(img, true, path, 250, 10000);

            img.Resize(10000, 10000);
            AreImagesEqual(img, true, path, 10000, 10000);


            img.Resize(10001, 250);
            AreImagesEqual(img, true, path, 10000, 10000);

            img.Resize(250, 10001);
            AreImagesEqual(img, true, path, 10000, 10000);

            img.Resize(10001, 10001);
            AreImagesEqual(img, true, path, 10000, 10000);
        }
    }
}
