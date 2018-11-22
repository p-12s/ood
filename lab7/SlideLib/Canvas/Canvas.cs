using System;
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
            _lineColor = 0;
            _fillColor = 0;
            _isFilling = false;
        }

        // Изменить цвет рисования линий
        public void SetLineColor(RGBAColor color)
        {
            throw new NotImplementedException();
        }

        // Изменить толщину рисования линий
        public void SetLineThickness(int thickness)
        {
            throw new NotImplementedException();
        }

        // Изменить цвет заполнения внутренних областей фигур
        public void BeginFill(RGBAColor color)
        {
            throw new NotImplementedException();
        }

        public void EndFill()
        {
            throw new NotImplementedException();
        }

        // Нарисовать отрезок прямой линии
        public void MoveTo(int x, int y)
        {
            Console.WriteLine("MoveTo ({0}, {1})", x, y);
        }

        public void LineTo(int x, int y)
        {
            Console.WriteLine("LineTo ({0}, {1})", x, y);
        }

        public void DrawEllipse(int left, int top, int width, int height)
        {
            MoveTo(left, top);
            Console.WriteLine("Draw Ellipse (verticalRadius: {0}, horizontalRadius: {1})", height, width);
        }


    }
}
