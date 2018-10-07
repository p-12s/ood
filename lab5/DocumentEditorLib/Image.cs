using System.IO;
using System;
using System.Drawing;
using System.Linq;

namespace DocumentEditorLib
{
    public interface IImg
    {
        string GetPath();

        int GetWidth();

        int GetHeight();

        void Resize(int width, int height);
    }

    public class Img : IImg
    {
        private string _path;
        private int _width;
        private int _height;
        private bool _isImageValid = false;

        public Img(string path, int? height = null, int? width = null)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Error! File in path: '" + path + "' not exists");
            }
            else if (width < 0 || width > 10000 || height < 0 | height > 10000)
            {
                Console.WriteLine("Error! Width and height should be in the range of 1..10.000");
            }
            else
            {
                Image image = new Bitmap(path);
                if (image.Width <= 10000 && image.Height <= 10000)
                {
                    _path = path;
                    _width = width ?? image.Width;
                    _height = height ?? image.Height;
                    _isImageValid = true;
                }
            }
        }

        public string GetPath()
        {
            return _path;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public void Resize(int height, int width)
        {
            if (width < 0 || width > 10000 || height < 0 | height > 10000)
            {
                Console.WriteLine("Error! Cannot set size less than 0 or greater than 10,000");
            }
            else
            {
                _width = width;
                _height = height;
            }
        }

        public bool IsImageValid()
        {
            return _isImageValid;
        }
    }
}
