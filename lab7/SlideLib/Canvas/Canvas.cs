using RGBAColor = System.UInt32;

namespace SlideLib
{
    public class Canvas : ICanvas
    {
        RGBAColor _lineColor;
        RGBAColor _fillColor;
        bool _isFilling;

        public Canvas()
        {
            _isFilling = false;
        }



    }
}
