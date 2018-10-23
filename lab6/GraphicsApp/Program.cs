using System;

/*
// Пространство имен приложения (доступно для модификации)
namespace App
{
    public void PaintPicture(ShapeDrawingLib.CanvasPainter painter)
    {
        //using ShapeDrawingLib;

        new ShapeDrawingLib.Triangle(
            new ShapeDrawingLib.Point(10, 15),
            new ShapeDrawingLib.Point(100, 200),
            new ShapeDrawingLib.Point(150, 250)
            );

        new ShapeDrawingLib.Rectangle(
            new ShapeDrawingLib.Point(10, 15),
            18, 24);

        // TODO: нарисовать прямоугольник и треугольник при помощи painter
    }

    void PaintPictureOnCanvas()
    {
        GraphicsLib.Canvas simpleCanvas;
        ShapeDrawingLib.CanvasPainter painter(simpleCanvas);
        PaintPicture(painter);
    }

    void PaintPictureOnModernGraphicsRenderer()
    {
        ModernGraphicsLib.ModernGraphicsRenderer renderer();//рисуем в консоль, убрал cout
        //(void)&renderer; // устраняем предупреждение о неиспользуемой переменной

        // TODO: при помощи существующей функции PaintPicture() нарисовать
        // картину на renderer
        // Подсказка: используйте паттерн "Адаптер"
    }
}
*/

namespace GraphicsApp
{
    class Program
    {
        static void PaintPicture(ShapeDrawingLib.CanvasPainter painter)
        {
            //using ShapeDrawingLib;

            /*new ShapeDrawingLib.Triangle(
                new ShapeDrawingLib.Point(10, 15),
                new ShapeDrawingLib.Point(100, 200),
                new ShapeDrawingLib.Point(150, 250)
                );

            new ShapeDrawingLib.Rectangle(new ShapeDrawingLib.Point(10, 15), 18, 24);
            */
            // TODO: нарисовать прямоугольник и треугольник при помощи painter

            Console.WriteLine("11");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Should we use new API (y)?");

            GraphicsLib.ICanvas canvas = new GraphicsLib.Canvas();
            ShapeDrawingLib.CanvasPainter painter = new ShapeDrawingLib.CanvasPainter(canvas);

            PaintPicture(painter);










            /*GraphicsLib.Canvas canvas = new GraphicsLib.Canvas();
            
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                App.PaintPictureOnModernGraphicsRenderer();
            }
            else
            {
                App.PaintPictureOnCanvas();
            }
            */


            // портировать классы

            // почистить комменты

            // сделать методы Dispose() приватными, может и другие тоже

        }
    }
}
