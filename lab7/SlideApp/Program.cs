using System;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;
using SlideLib;
using SlideLib.Shapes;

/*class Ellipse : Shape
{
    public sealed override void Draw(ICanvas canvas)
    {
    }
};

class Triangle : Shape
{
    public sealed override void Draw(ICanvas canvas)
    {
    }
}*/

class Program
{

    static void Main(string[] args)
    {
        // ПРЯМОУГОЛЬНИК
        var rectangle = new Rectangle(new Point<int>(1, 10), new Point<int>(10, 1));
        
        // получить фрейм
        var rectangleFrame = rectangle.GetFrame();

        // изменить фрейм
        var newFrame = new RectD
        {
            topLeft = new Point<int>(10, 100),
            bottomRight = new Point<int>(100, 10)
        };
        rectangle.SetFrame(newFrame);
        rectangleFrame = rectangle.GetFrame();

        // обводка
        var lineStyle = rectangle.GetLineStyle();
        var style1 = new Style(0);
        rectangle.SetLineStyle(style1);
        lineStyle = rectangle.GetLineStyle();

        // заливка
        var fillStyle = rectangle.GetFillStyle();
        var style2 = new Style(100);
        rectangle.SetFillStyle(style2);
        fillStyle = rectangle.GetFillStyle();


        // ЭЛЛИПС
        var ellipse = new Ellipse(new Point<int>(0, 0), 10, 20, 0);
        // обводка
        lineStyle = ellipse.GetLineStyle();
        ellipse.SetLineStyle(style1);
        lineStyle = ellipse.GetLineStyle();

        // заливка
        fillStyle = ellipse.GetFillStyle();
        ellipse.SetFillStyle(style2);
        fillStyle = ellipse.GetFillStyle();


        // ТРЕУГОЛЬНИК



        var a = 1;
        // написать остаток программы

        //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        //Graphics.DrawLine(pen, 20, 10, 300, 100);


        Console.WriteLine("Hello World!");
    }
}

