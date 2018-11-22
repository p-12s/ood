using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;

namespace SlideLib.Shapes
{
    // Определяет интерфейс для всех компонентов в древовидной структуре
    public abstract class Shape
    {
        public Shape() { }

        // все операции
        /*
        public abstract RectD GetFrame();
        public abstract void SetFrame(RectD rect);

        public abstract IStyle GetLineStyle();
        public abstract void SetLineStyle(IStyle style);

        public abstract IStyle GetFillStyle();
        public abstract void SetFillStyle(IStyle style);
        */

        public abstract void Draw(ICanvas canvas);

        // операции, присущие паттерну
        public abstract void Add(Shape Shape);

        public abstract void Remove(Shape Shape);

        public abstract bool IsComposite();

    };
}
