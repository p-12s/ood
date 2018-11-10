using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<double>;

namespace SlideLib.Shapes
{
    public abstract class Shape
    {
        public Shape() { }

        public abstract RectD GetFrame();
        public abstract void SetFrame(RectD rect);

        public abstract IStyle GetLineStyle();
        public abstract void SetLineStyle(IStyle style);

        public abstract IStyle GetFillStyle();
        public abstract void SetFillStyle(IStyle style);

        public abstract void Draw(ICanvas canvas);//в примере - virtual
    };
}
