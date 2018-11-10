using System;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<double>;
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
        // прямоугольник
        var rectangle = new Rectangle(new Point(1, 10), new Point(10, 1));
        
        // получить фрейм
        var rectangleFrame = rectangle.GetFrame();

        // изменить фрейм
        var newFrame = new RectD
        {
            top = 100,
            left = 10,
            width = 50,
            height = 60
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




        // добавить вторую с методами

        // и третью



        var a = 1;
        // написать остаток программы

        //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        //Graphics.DrawLine(pen, 20, 10, 300, 100);


        Console.WriteLine("Hello World!");
    }
}

