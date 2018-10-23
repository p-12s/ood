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
        // TODO: нарисовать прямоугольник и треугольник при помощи painter (недоступно для изменения)
        static void PaintPicture(ShapeDrawingLib.CanvasPainter painter, ShapeDrawingLib.ICanvasDrawable obj)
        {
            painter.Draw(obj);
        }

        static void PaintPictureOnCanvas(ShapeDrawingLib.ICanvasDrawable obj)
        {
            var simpleCanvas = new GraphicsLib.Canvas(); // тут канвас
            var painter = new ShapeDrawingLib.CanvasPainter(simpleCanvas);
            PaintPicture(painter, obj);
        }

        static void PaintPictureOnModernGraphicsRenderer()
        {
            Console.WriteLine("отработал Модерн");
            var renderer = new ModernGraphicsLib.ModernGraphicsRenderer(); // а тут рендер
            renderer.BeginDraw();
            renderer.DrawLine();
            renderer.EndDrow();
            // TODO: при помощи существующей функции PaintPicture() нарисовать
            // картину на renderer
            // Подсказка: используйте паттерн "Адаптер"



        }

        //class Adapter : 

/*
        // Пространство имен приложения (доступно для модификации)
    namespace app
    {
        void PaintPicture(shape_drawing_lib::CCanvasPainter & painter)
        {
            using namespace shape_drawing_lib;

  CTriangle triangle({ 10, 15 }, { 100, 200 }, { 150, 250 });
  CRectangle rectangle({ 30, 40 }, 18, 24);

  // TODO: нарисовать прямоугольник и треугольник при помощи painter
}

void PaintPictureOnCanvas()
{
    graphics_lib::CCanvas simpleCanvas;
    shape_drawing_lib::CCanvasPainter painter(simpleCanvas);
    PaintPicture(painter);
}
}

int main()
{
    app::PaintPictureOnCanvas();

    return 0;
}
*/

static void Main(string[] args)
        {
            Console.WriteLine("Should we use new API (y)?");

            var triangle = new ShapeDrawingLib.Triangle(
                new ShapeDrawingLib.Point(10, 15),
                new ShapeDrawingLib.Point(100, 200),
                new ShapeDrawingLib.Point(150, 250)
            );

            var rectangle = new ShapeDrawingLib.Rectangle(new ShapeDrawingLib.Point(10, 15), 18, 24);

            
           
            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                PaintPictureOnModernGraphicsRenderer();
            }
            else
            {
                PaintPictureOnCanvas(triangle);
                PaintPictureOnCanvas(rectangle);
            }
            
            Console.ReadLine();

            // почистить комменты

            // сделать методы Dispose() приватными, может и другие тоже

        }
    }
}
