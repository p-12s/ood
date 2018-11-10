using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<double>;

namespace SlideLib.Shapes
{
    public class Rectangle : Shape
    {
        private Point _topLeft;
        private Point _bottomRight;
        private IStyle _lineStyle;
        private IStyle _fillStyle;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public sealed override RectD GetFrame()
        {
            return new RectD();//возвр фрейм по размерам
        }

        public sealed override void SetFrame(RectD rect)
        {//пересчет координат
        }

        public sealed override IStyle GetLineStyle()
        {
            return _lineStyle;
        }

        public sealed override void SetLineStyle(IStyle style)
        {
            _lineStyle = style;
        }

        public sealed override IStyle GetFillStyle()
        {
            return _fillStyle;
        }

        public sealed override void SetFillStyle(IStyle style)
        {
            _fillStyle = style;
        }

        public sealed override void Draw(ICanvas canvas)
        {
        }
    };
}
