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
    /*void DrawEllipse()
    {
        Pen myPen = new Pen(Color.Red);
        Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.DrawEllipse(myPen, new Rectangle(0, 0, 200, 300));
        myPen.Dispose();
        formGraphics.Dispose();
    }

     void DrawRectangle()
    {
        Pen myPen = new Pen(Color.Red);
        Graphics formGraphics;
        formGraphics = this.CreateGraphics();
        formGraphics.DrawRectangle(myPen, new Rectangle(0, 0, 200, 300));
        myPen.Dispose();
        formGraphics.Dispose();
    }*/

    static void Main(string[] args)
    {
        // просто создать фигуру с заливокой и прочим
        var rectangle = new Rectangle(new Point(0, 10), new Point(10, 0));
        // поисграться ее методами




        // добавить вторую с методами


        // и третью



        var a = 1;
        // написать остаток программы

        //Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));
        //Graphics.DrawLine(pen, 20, 10, 300, 100);


        Console.WriteLine("Hello World!");
    }
}

