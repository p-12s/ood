using System;
using System.Collections.Generic;
using System.Linq;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    public class Triangle : Shape
    {
        private Point<int> _point1;
        private Point<int> _point2;
        private Point<int> _point3;
        private IStyle _lineStyle;
        private IStyle _fillStyle;

        public Triangle(Point<int> point1, Point<int> point2, Point<int> point3)
        {
            _point1 = point1;
            _point2 = point2;
            _point3 = point3;
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
            Console.WriteLine("Triangle:");
            canvas.MoveTo(_point1.X, _point1.Y);
            canvas.LineTo(_point2.X, _point2.Y);
            canvas.LineTo(_point3.X, _point3.Y);
            canvas.LineTo(_point1.X, _point1.Y);
        }

        /*
        public sealed override RectD GetFrame()
        {
            List<int> xCoordinats = GetXCoordinats();
            List<int> yCoordinats = GetYCoordinats();
            int maxTop = yCoordinats.Max(item => item);
            int minBottom = yCoordinats.Min(item => item);
            int minLeft = xCoordinats.Min(item => item);
            int maxRight = yCoordinats.Max(item => item);

            return new RectD
            {
                topLeft = new Point<int>(minLeft, maxTop),
                bottomRight = new Point<int>(maxRight, minBottom)
            };
        }

        public sealed override void SetFrame(RectD rect)
        {
            // пока не буду расчитывать. а вообще, в какую сторону фрейм вырос - в ту увеличивать максимальную координату
            throw new System.NotImplementedException();
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

        */
        #region Private members

        private List<int> GetXCoordinats()
        {
            return new List<int>
            {
                _point1.X,
                _point2.X,
                _point3.X
            };
        }

        private List<int> GetYCoordinats()
        {
            return new List<int>
            {
                _point1.Y,
                _point2.Y,
                _point3.Y
            };
        }

        #endregion
        
    };
}
