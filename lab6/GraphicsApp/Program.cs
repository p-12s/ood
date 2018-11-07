using System;

namespace GraphicsApp
{
    class ModernCanvasAdapter : GraphicsLib.ICanvas
    {
        private ModernGraphicsLib.ModernGraphicsRenderer _modernGraphicsRenderer;
        private ModernGraphicsLib.Point _start;
        private ModernGraphicsLib.Point _end;
        private bool _disposed;

        public ModernCanvasAdapter(ModernGraphicsLib.ModernGraphicsRenderer modernGraphicsRenderer)
        {
            _modernGraphicsRenderer = modernGraphicsRenderer;
            _modernGraphicsRenderer.BeginDraw();
        }

        public void MoveTo(int x, int y)
        {
            _start = new ModernGraphicsLib.Point(x, y);
        }

        public void LineTo(int x, int y)
        {
            _end = new ModernGraphicsLib.Point(x, y);
            _modernGraphicsRenderer.DrawLine(_start, _end);
            _start = _end;
        }

        #region Destructor

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    //dispose managed resources
                    _modernGraphicsRenderer.EndDraw();
                }
            }
            //dispose unmanaged resources
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
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
            Console.WriteLine("Old API:");
            var simpleCanvas = new GraphicsLib.Canvas();
            var painter = new ShapeDrawingLib.CanvasPainter(simpleCanvas);
            PaintPicture(painter, obj);
        }

        static void PaintPictureOnModernGraphicsRenderer(ShapeDrawingLib.ICanvasDrawable obj)
        {
            Console.WriteLine("New API:");
            var renderer = new ModernGraphicsLib.ModernGraphicsRenderer();
            using (ModernCanvasAdapter modernAdapter = new ModernCanvasAdapter(renderer))
            {
                var painter = new ShapeDrawingLib.CanvasPainter(modernAdapter);
                PaintPicture(painter, obj);
            }

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
                Console.WriteLine("\nDraw a Triangle");
                PaintPictureOnModernGraphicsRenderer(triangle);

                Console.WriteLine("\nDraw a Rectangle");
                PaintPictureOnModernGraphicsRenderer(rectangle);
            }
            else
            {
                Console.WriteLine("\nDraw a Triangle");
                PaintPictureOnCanvas(triangle);

                Console.WriteLine("\nDraw a Rectangle");
                PaintPictureOnCanvas(rectangle);
            }            

        }
    }
}
