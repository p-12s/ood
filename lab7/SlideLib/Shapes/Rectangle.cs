using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    public class Rectangle : Shape
    {
        private Point<int> _topLeft;
        private Point<int> _bottomRight;
        private IStyle _lineStyle;
        private IStyle _fillStyle;

        public Rectangle(Point<int> topLeft, Point<int> bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        public sealed override RectD GetFrame()
        {
            return new RectD
            {
                topLeft = _topLeft,
                bottomRight = _bottomRight
            };

        }

        public sealed override void SetFrame(RectD rect)
        {
            _topLeft = rect.topLeft;
            _bottomRight = rect.bottomRight;
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
            throw new System.NotImplementedException();
        }
    };
}
