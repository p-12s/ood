using System;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    public class Ellipse : Shape
    {
        private Point<int> _center;
        private int _verticalRadius;
        private int _horizontalRadius;
        private Style _lineStyle;
        private Style _fillStyle;

        public Ellipse(Point<int> center, int verticalRadius, int horizontalRadius)
        {
            _center = center;
            _verticalRadius = verticalRadius;
            _horizontalRadius = horizontalRadius;
        }

        

        public override void Add(Shape Shape)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Shape Shape)
        {
            throw new NotImplementedException();
        }

        public override bool IsComposite()
        {
            return false;
        }

        public sealed override void Draw(ICanvas canvas)
        {
            Console.WriteLine("Ellipse:");
            canvas.DrawEllipse(_center.X, _center.Y, _horizontalRadius, _verticalRadius);
        }

        public sealed override RectD GetFrame()
        {
            return new RectD
            {
                topLeft = new Point<int>((_center.X - _horizontalRadius), (_center.Y + _verticalRadius)),
                bottomRight = new Point<int>((_center.X + _horizontalRadius), (_center.Y - _verticalRadius))
            };
        }

        public sealed override Style GetLineStyle()
        {
            return _lineStyle;
        }

        /*
        public sealed override void SetFrame(RectD rect)
        {
            int height = rect.topLeft.Y - rect.bottomRight.Y;
            int width = rect.bottomRight.X - rect.topLeft.X;
            _verticalRadius = height / 2;
            _horizontalRadius = width / 2;
            _center.X = rect.topLeft.X + _horizontalRadius;
            _center.Y = rect.topLeft.Y - _verticalRadius;
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

        */



    };
}
