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
    }
}
