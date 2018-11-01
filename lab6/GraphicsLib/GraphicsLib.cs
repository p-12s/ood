using System;

// Пространство имен графической библиотеки (недоступно для изменения)
namespace GraphicsLib
{
    public interface ICanvas
    {
        // Ставит "перо" в точку x, y
        void MoveTo(int x, int y);

        // Рисует линию с текущей позиции, передвигая перо в точку x,y 
        void LineTo(int x, int y);
    }

    // Реализация холста для рисования
    public class Canvas : ICanvas
    {
        public void MoveTo(int x, int y)
        {
            Console.WriteLine("MoveTo ({0}, {1})", x, y);
        }

        public void LineTo(int x, int y)
        {
            Console.WriteLine("LineTo ({0}, {1})", x, y);
        }
    }
}


// Пространство имен современной графической библиотеки (недоступно для изменения)
namespace ModernGraphicsLib
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    };

    // Класс для современного рисования графики
    public class ModernGraphicsRenderer : IDisposable
    {
        //private Stream _out; для простоты выводим к консоль
        private bool _drawing;
        private bool _disposed;

        public ModernGraphicsRenderer()
        {
            _drawing = false;
            _disposed = false;
        }

        #region Destructor

        /*
        1 вариант деструктора:
        ~ModernGraphicsRenderer()
        {
            if (_drawing) // Завершаем рисование, если оно было начато
                EndDraw();
        }
        деструктор будет скомпилирован в:

        protected override void Finalize()
        {
            try
            {
                if (_drawing) // Завершаем рисование, если оно было начато
                    EndDraw();
            }
            finally
            {
                base.Finalize();
            }
        }

        минус подхода в том, что освобождение ресурсов выполняется не сразу.
        На уровне памяти это выглядит так: сборщик мусора при размещении объекта в куче определяет, 
        поддерживает ли данный объект метод Finalize. И если объект имеет метод Finalize, 
        то указатель на него сохраняется в специальной таблице, которая называется очередь финализации. 
        Когда наступает момент сборки мусора, сборщик видит, что данный объект должен быть уничтожен, 
        и если он имеет метод Finalize, то он копируется в еще одну таблицу и окончательно уничтожается лишь 
        при следующем проходе сборщика мусора.
        
        поэтому 2 вариант:
        */

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // подавляем финализацию
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    EndDraw();
                }
                // освобождаем неуправляемые объекты
                _disposed = true;
            }
        }

        ~ModernGraphicsRenderer()
        {
            Dispose(false);
        }

        #endregion

        // Этот метод должен быть вызван в начале рисования
        public void BeginDraw()
        {
            if (_drawing)
                throw new InvalidOperationException("Drawing has already begun");

            Console.WriteLine("<draw>");
            _drawing = true;
        }

        // Выполняет рисование линии
        public void DrawLine(Point start, Point end)
        {
            if (!_drawing)
                throw new InvalidOperationException("DrawLine is allowed between BeginDraw()/EndDraw() only");

            Console.WriteLine("(<line from X=\"{0}\" from Y=\"{1}\" to X=\"{2}\" to Y=\"{3}\"/>)", start.X, start.Y, end.X, end.Y);
        }

        // Этот метод должен быть вызван в конце рисования
        public void EndDraw()
        {
            if (!_drawing)
                throw new InvalidOperationException("Drawing has not been started");

            Console.WriteLine("</draw>");
            _drawing = false;
        }

    };
}


// Пространство имен библиотеки для рисования фигур (использует GraphicsLib)
// Код библиотеки недоступен для изменения
namespace ShapeDrawingLib
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    };

    // Интерфейс объектов, которые могут быть нарисованы на холсте из GraphicsLib
    public interface ICanvasDrawable
    {
        void Draw(GraphicsLib.ICanvas canvas);
    };

    public class Triangle : ICanvasDrawable
    {
        private Point _p1, _p2, _p3;

        public Triangle(Point p1, Point p2, Point p3)
        {
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public void Draw(GraphicsLib.ICanvas canvas)
        {
            Console.WriteLine("Draw a Triangle:");
            canvas.MoveTo(_p1.X, _p1.Y);
            canvas.LineTo(_p2.X, _p2.Y);
            canvas.LineTo(_p3.X, _p3.Y);
            canvas.LineTo(_p1.X, _p1.Y);
        }
    }

    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private int _width, _height;

        public Rectangle(Point leftTop, int width, int height)
        {
            _leftTop = leftTop;
            _width = width;
            _height = height;
        }

        public void Draw(GraphicsLib.ICanvas canvas)
        {
            Console.WriteLine("Draw a Rectangle");
            canvas.MoveTo(_leftTop.X, _leftTop.Y);
            canvas.LineTo(_leftTop.X + _width, _leftTop.Y);
            canvas.LineTo(_leftTop.X + _width, _leftTop.Y - _height);
            canvas.LineTo(_leftTop.X, _leftTop.Y - _height);
            canvas.LineTo(_leftTop.X, _leftTop.Y);
        }
    };

    // Художник, способный рисовать ICanvasDrawable-объекты на ICanvas
    public class CanvasPainter
    {
        private ICanvasDrawable _obj;
        private GraphicsLib.ICanvas _canvas;

        public CanvasPainter(GraphicsLib.ICanvas canvas)
        {
            _canvas = canvas;
        }

        public void Draw(ICanvasDrawable obj)
	    {
            _obj = obj;
            _obj.Draw(_canvas);
        }
    };
}
















namespace GraphicsLibPro
{
    // Холст для рисования
    public interface ICanvas
    {
	    // Установка цвета в формате 0xRRGGBB
	    void SetColor(uint rgbColor);
	    void MoveTo(int x, int y);
	    void LineTo(int x, int y);
    };

    // Реализация холста для рисования
    class Canvas : ICanvas
    {
        private uint _rgbColor;

        public void SetColor(uint rgbColor) // опуть тут override - как заменить?
        {
            // TODO: вывести в output цвет в виде строки SetColor (#RRGGBB)
            _rgbColor = rgbColor;
            Console.WriteLine("Canvas color set: " + _rgbColor);
        }

        public void MoveTo(int x, int y)
        {
            Console.WriteLine("MoveTo ({0}, {1})", x, y);
        }

        public void LineTo(int x, int y)
        {
            Console.WriteLine("LineTo ({0}, {1})", x, y);
        }
    };
}

// Пространство имен обновленной современной графической библиотеки (недоступно для изменения)
namespace ModernGraphicsLibPro
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    };

    // Цвет в формате RGBA, каждый компонент принимает значения от 0.0f до 1.0f
    public class RGBAColor
    {
        public float R { get; set; }
        public float G { get; set; }
        public float B { get; set; }
        public float A { get; set; }

        public RGBAColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }
    };

    // Класс для современного рисования графики
    public class ModernGraphicsRenderer : IDisposable
    {
        private bool _drawing;
        private bool _disposed;

        public ModernGraphicsRenderer()
        {
            _drawing = false;
            _disposed = false;
        }

        #region Destructor

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); // подавляем финализацию
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Освобождаем управляемые ресурсы
                    EndDraw();
                }
                // освобождаем неуправляемые объекты
                _disposed = true;
            }
        }

        ~ModernGraphicsRenderer()
        {
            Dispose(false);
        }

        #endregion

        // Этот метод должен быть вызван в начале рисования
        public void BeginDraw()
        {
            if (_drawing)
                throw new InvalidOperationException("Drawing has already begun");

            Console.WriteLine("<draw>");
            _drawing = true;
        }

        // Выполняет рисование линии
        // Можно вызывать только между BeginDraw() и EndDraw()
        public void DrawLine(Point start, Point end, RGBAColor color)
        {
            if (!_drawing)
                throw new InvalidOperationException("DrawLine is allowed between BeginDraw()/EndDraw() only");

            Console.WriteLine("(<line from X=\"{0}\" from Y=\"{1}\" to X=\"{2}\" to Y=\"{3}\"/>)", 
                start.X, start.Y, end.X, end.Y);
            Console.WriteLine("<color r=\"{0}\" g=\"{1}\" b=\"{2}\" a=\"{3}\"/>",
                color.R, color.G, color.B, color.A);
            Console.WriteLine("<line/>");

        }

        // Этот метод должен быть вызван в конце рисования
        void EndDraw()
        {
            if (!_drawing)
                throw new InvalidOperationException("Drawing has not been started");

            Console.WriteLine("</draw>");
            _drawing = false;
        }

    };
}
