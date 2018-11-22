using RGBAColor = System.UInt32;

namespace SlideLib
{
    public class Style : IStyle
    {
        private RGBAColor _color;
        private bool _isEnabled;

        public Style(RGBAColor color = 0)
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

        public bool IsEqual(Style style)
        {
            // первым для сравнения-присваивания приходит null
            if (style == null)
                return true;

            return _color == style.GetColor() && _isEnabled == style.IsEnabled();
        }
    };
}
