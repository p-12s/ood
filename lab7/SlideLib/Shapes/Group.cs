using System;
using System.Collections.Generic;

namespace SlideLib.Shapes
{
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

    }
}
