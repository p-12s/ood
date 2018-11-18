using RGBAColor = System.UInt32;

namespace SlideLib
{
    public interface IStyle
    {
        bool? IsEnabled();

        void Enable(bool enable);

        RGBAColor? GetColor();

        void SetColor(RGBAColor color);
    };
}
