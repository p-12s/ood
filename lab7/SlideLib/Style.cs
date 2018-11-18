using RGBAColor = System.UInt32;

namespace SlideLib
{
    public class Style : IStyle
    {
        private RGBAColor _color;
        private bool _isEnabled;

        public Style(RGBAColor color = 0)// возможно не надо иниц
        {
            _color = color;
            _isEnabled = true;
        }

        public bool? IsEnabled()
        {
            return _isEnabled;
        }

        public void Enable(bool enable)
        {
            _isEnabled = enable;
        }

        public RGBAColor? GetColor()
        {
            return _color;
        }

        public void SetColor(RGBAColor color)
        {
            _color = color;
        }
    };
}
