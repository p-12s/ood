using System;
using System.Collections.Generic;

namespace SlideLib.Shapes
{
    // Слайдом считается изображение, состоящее из набора геометрических фигур.

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

        public override void Draw(ref ICanvas canvas)
        {
            int i = 0;

            Console.Write("Branch(");
            foreach (var Shape in _children)
            {
                Shape.Draw(ref canvas);
                if (i != _children.Count - 1)
                {
                    Console.Write("+");
                }
                i++;
            }
            Console.Write(")");
        }

    }
}
