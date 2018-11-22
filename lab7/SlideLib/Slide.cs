using SlideLib.Shapes;
using System.Collections.Generic;

namespace SlideLib
{
    // Слайдом считается изображение, состоящее из набора 
    // геометрических фигур.
    public class Slide
    {
        List<Shape> _shapes = new List<Shape>();

        public Slide() {}

        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        public double GetWidth()
        {
            return 0;
        }

        public double GetHeight()
        {
            return 0;
        }

        public List<Shape> GetShapes()
        {
            return null;
        }

        public void RemoveShape(int index)
        {
            if (index >= _shapes.Count || index < 0)
                throw new System.Exception("Out of range");

            _shapes.RemoveAt(index);
        }

        public void Draw(ICanvas canvas)
        {
            foreach (var shape in _shapes)
            {
                shape.Draw(canvas);
            }

                
        }

    }
}
