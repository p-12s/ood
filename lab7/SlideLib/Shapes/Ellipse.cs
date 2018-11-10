using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    public class Ellipse : Shape
    {
        private Point<int> _center;
        private int _verticalRadius;
        private int _horizontalRadius;
        private double _rotation;
        private IStyle _lineStyle;
        private IStyle _fillStyle;

        public Ellipse(Point<int> center, int verticalRadius, int horizontalRadius, double rotation)
        {
            _center = center;
            _verticalRadius = verticalRadius;
            _horizontalRadius = horizontalRadius;
            _rotation = rotation;
        }

        public sealed override RectD GetFrame()
        {
            return new RectD // тут по-умному высчитать фрейм
            {
                topLeft = new Point<int>(0, 0),
                bottomRight = new Point<int>(0, 0)
            };

        }

        public sealed override void SetFrame(RectD rect) // а тут по-умному перенести из фрейма в размеры и позиции
        {
            
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

        public double GetRotation()
        {
            return _rotation;
        }

        public void SetRotation(double rotation)
        {
            _rotation = rotation;
        }

        public sealed override void Draw(ICanvas canvas)
        {
        }
    };
}
