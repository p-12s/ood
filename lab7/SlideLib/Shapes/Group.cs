using System;
using System.Collections.Generic;

namespace SlideLib.Shapes
{
    // составная фигура
    public class Group : Shape
    {
        List<Shape> _children = new List<Shape>();

        public Group() {}

        // операции, присущие паттерну
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
            int i = 0;

            Console.Write("Group(");
            foreach (var child in _children)
            {
                child.Draw(canvas);
                if (i != _children.Count - 1)
                    Console.Write("+");

                i++;
            }
            Console.Write(")");
        }

    }
}
