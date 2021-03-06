﻿using System;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    public class Rectangle : Shape
    {
        private Point<int> _topLeft;
        private Point<int> _bottomRight;
        private Style _lineStyle;
        private Style _fillStyle;

        public Rectangle(Point<int> topLeft, Point<int> bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
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
            Console.WriteLine("Rectangle:");
            canvas.MoveTo(_topLeft.X, _topLeft.Y);
            canvas.LineTo(_bottomRight.X, _topLeft.Y);
            canvas.LineTo(_bottomRight.X, _bottomRight.Y);
            canvas.LineTo(_topLeft.X, _bottomRight.Y);
            canvas.LineTo(_topLeft.X, _topLeft.Y);
        }

        public sealed override RectD GetFrame()
        {
            return new RectD
            {
                topLeft = _topLeft,
                bottomRight = _bottomRight
            };
        }

        public sealed override Style GetLineStyle()
        {
            return _lineStyle;
        }

        /*
        
        public sealed override void SetFrame(RectD rect)
        {
            _topLeft = rect.topLeft;
            _bottomRight = rect.bottomRight;
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
