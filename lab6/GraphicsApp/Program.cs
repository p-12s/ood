using System;

namespace GraphicsApp
{
    class ModernCanvasAdapter : GraphicsLib.ICanvas
    {
        private ModernGraphicsLib.ModernGraphicsRenderer _modernGraphicsRenderer;

        public ModernCanvasAdapter(ModernGraphicsLib.ModernGraphicsRenderer modernGraphicsRenderer)
        {
            _modernGraphicsRenderer = modernGraphicsRenderer;
        }

        public void MoveTo(int x, int y)
        {
            _modernGraphicsRenderer.BeginDraw();
        }

        public void LineTo(int x, int y)
        {
            //_modernGraphicsRenderer.DrawLine();
        }
    }


    class Program
    {
        
        static void PaintPicture(ShapeDrawingLib.CanvasPainter painter, 
            ShapeDrawingLib.ICanvasDrawable obj)
        {
            painter.Draw(obj);
        }

        static void PaintPictureOnCanvas(ShapeDrawingLib.ICanvasDrawable obj)
        {
            Console.WriteLine("Старое API:");
            var simpleCanvas = new GraphicsLib.Canvas();
            var painter = new ShapeDrawingLib.CanvasPainter(simpleCanvas);
            PaintPicture(painter, obj);
        }


        static void PaintPictureOnModernGraphicsRenderer(ShapeDrawingLib.ICanvasDrawable obj)
        {
            Console.WriteLine("Новое API:");
            var renderer = new ModernGraphicsLib.ModernGraphicsRenderer();


            ModernCanvasAdapter modernAdapter = new ModernCanvasAdapter(renderer);
            var painter = new ShapeDrawingLib.CanvasPainter(modernAdapter);
            PaintPicture(painter, obj);


            // TODO: при помощи существующей функции PaintPicture() нарисовать
            // картину на renderer
            // Подсказка: используйте паттерн "Адаптер"
        }

        static void Main(string[] args)
        {
            

            var triangle = new ShapeDrawingLib.Triangle(
                new ShapeDrawingLib.Point(10, 15),
                new ShapeDrawingLib.Point(100, 200),
                new ShapeDrawingLib.Point(150, 250)
            );

            var rectangle = new ShapeDrawingLib.Rectangle(
                new ShapeDrawingLib.Point(10, 15), 18, 24
            );


            Console.WriteLine("Should we use new API (y)?");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "y")
            {
                PaintPictureOnModernGraphicsRenderer(triangle);
                PaintPictureOnModernGraphicsRenderer(rectangle);
            }
            else
            {
                PaintPictureOnCanvas(triangle);
                PaintPictureOnCanvas(rectangle);
            }
            

            Console.ReadLine();

            

         

        }
    }
}
