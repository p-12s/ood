namespace DocumentEditorLib
{
    public interface IImage
    {
        string GetPath();

        int GetWidth();

        int GetHeight();

        void Resize(int width, int height);
    }

    public class Image : IImage
    {
        private string _path;
        private int _width;
        private int _height;

        public Image(string path, int width, int height)
        {
            _path = path;
            _width = width;
            _height = height;
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

        public void Resize(int width, int height)
        {
            _width = width;
            _height = height;
        }
    }
}
