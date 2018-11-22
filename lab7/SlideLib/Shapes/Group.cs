using System;
using System.Collections.Generic;
using System.Linq;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    /*
        Фреймом группы должен быть фрейм, охватывающий свойства входящих 
        в состав группы фигур

        Свойства стилей заливки и обводки группы фигур должны 
        возвращать значение undefined(или его аналоги: null, none и т.п.)
        либо значение соответствующего свойства фигур в составе группы,
        если оно одинаково для всех фигур в составе группы
    */

    public class Group : Shape
    {
        List<Shape> _children = new List<Shape>();

        public Group() {}

        public override void Add(Shape Shape)
        {
            _children.Add(Shape);
        }

        public override void Remove(Shape Shape)
        {
            _children.Remove(Shape);
        }

        public override bool IsComposite()
        {
            return true;
        }

        public override void Draw(ICanvas canvas)
        {
            Console.WriteLine("\nGroup:");
            foreach (var child in _children)
                child.Draw(canvas);
        }

        public override RectD GetFrame()
        {
            // получить все x, y координаты и выбрать из них
            List<int> xCoordinats = new List<int>();
            List<int> yCoordinats = new List<int>();

            foreach (var child in _children)
            {
                RectD childFrame = child.GetFrame();
                
                xCoordinats.Add(childFrame.topLeft.X);
                xCoordinats.Add(childFrame.bottomRight.X);
                yCoordinats.Add(childFrame.topLeft.Y);
                yCoordinats.Add(childFrame.bottomRight.Y);
            }

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

        public override Style GetLineStyle()
        {
            // если цвет у всех одинаковый - вернуть его
            bool isSameColor = true;
            Style lineStyle = null;

            //ОСТАНОВИЛСЯ ТУТ: надо заставить сравнивать цвета
            // далее научить ресайзить группу и фигуру

            foreach (var child in _children)
            {
                var style = child.GetLineStyle();
                if (!style.IsEqual(lineStyle) /*не одинаковый*/)
                {
                    isSameColor = false;
                    break;
                }
                lineStyle = style;
            }
            return isSameColor ? lineStyle : null;
        }






    }
}
