using System;
using System.Collections.Generic;
using System.Text;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<double>;

//typedef std::function<void(ICanvas & canvas, const IShape & shape)> DrawingStrategy;

namespace SlideLib
{/*
    public interface IDrawable
    {
        void Draw(ICanvas canvas);//ref?
    }

    public interface IStyle
    {
        bool? IsEnabled();
        void Enable(bool enable);
        RGBAColor? GetColor();
        void SetColor(RGBAColor color);
    };

    class IGroupShape;

    public interface IShape : IDrawable
    {
        RectD GetFrame();
	    void SetFrame(RectD rect);
	    IStyle GetOutlineStyle();
	    IStyle GetOutlineStyle();

        IStyle GetFillStyle();
	    IStyle GetFillStyle();

        List<IGroupShape> GetGroup();
    };

    public class IShapes
    {
        uint GetShapesCount();
        void InsertShape(List<IShape> shape, uint position = uint.MaxValue);
        List<IShape> GetShapeAtIndex(uint index);
	    void RemoveShapeAtIndex(uint index);
    };



    class CSimpleShape : public IShape
    {
    public:
	    CSimpleShape(const DrawingStrategy & drawingStrategy)
        {
            (void)&drawingStrategy;
        }
    };

    class CGroupShape : public IGroupShape
    {

    };

    class ISlide : IDrawable
    {
        public double GetWidth();
        public double GetHeight();//virtual ?
        virtual IShapes & GetShapes();
    };

    class CSlide : public ISlide
    {
    }
    */
}
