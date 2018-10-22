using System;
using System.IO;

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
        private Point _p1, _p2, _p3; //TODO дописать приватную часть 

        public Triangle(Point p1, Point p2, Point p3)
        {
            // TODO: написать код конструктора
            _p1 = p1;
            _p2 = p2;
            _p3 = p3;
        }

        public void Draw(GraphicsLib.ICanvas canvas)
        {
            // TODO: написать код рисования треугольника на холсте
        }
    }

    public class Rectangle : ICanvasDrawable
    {
        private Point _leftTop;
        private int _width, _height; // TODO: дописать приватную часть 


        public Rectangle(Point leftTop, int width, int height)
        {
            // TODO: написать код конструктора
            _leftTop = leftTop;
            _width = width;
            _height = height;
        }

        public void Draw(GraphicsLib.ICanvas canvas) // TODO тут все const override. как это будет в шарпе? может использовать шаблонный метод?
        {
	        // TODO: написать код рисования прямоугольника на холсте
        }
    };

    // Художник, способный рисовать ICanvasDrawable-объекты на ICanvas
    public class CanvasPainter
    {
        //private:
	    // TODO: дописать приватную часть

        public CanvasPainter(GraphicsLib.ICanvas canvas)
        {
            // TODO: дописать конструктор класса
        }
        public void Draw(ICanvasDrawable drawable)
	    {
		    // TODO: дописать код рисования ICanvasDrawable на canvas, переданном в конструктор
	    }
    };
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
    public class ModernGraphicsRenderer
    {
        //private Stream _out; для простоты выводим к консоль
        private bool _drawing;

        public ModernGraphicsRenderer()
        {
            _drawing = false;
        }

        ~ModernGraphicsRenderer()
        {
            if (_drawing) // Завершаем рисование, если оно было начато
                EndDraw();
        }

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
        void EndDraw()
        {
            if (!_drawing)
                throw new InvalidOperationException("Drawing has not been started");

            Console.WriteLine("</draw>");
            _drawing = false;
        }

    };
}



/////////////
///
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

        public void SetColor(uint rgbColor) // опуть тут override - как заменить?
        {
	        // TODO: вывести в output цвет в виде строки SetColor (#RRGGBB)
        }

        public void MoveTo(int x, int y)
        {
	        // Реализация остается без изменения
        }

        public void LineTo(int x, int y)
        {
	        // Реализация остается без изменения
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
    class RGBAColor
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
    class ModernGraphicsRenderer
    {
        private bool _drawing;

        public ModernGraphicsRenderer()
        {
            _drawing = false;
        }

        ~ModernGraphicsRenderer() // возможно не нужен
        {
            // Реализация остается без изменения
        }

        // Этот метод должен быть вызван в начале рисования
        public void BeginDraw() // TODO вспомогательное сделать приватным
        {
            // Реализация остается без изменения
        }

        // Выполняет рисование линии
        public void DrawLine(Point start, Point end, RGBAColor color)
	    {
		    // TODO: выводит в output инструкцию для рисования линии в виде
		    // <line fromX="3" fromY="5" toX="5" toY="17">
		    //   <color r="0.35" g="0.47" b="1.0" a="1.0" />
		    // </line>
		    // Можно вызывать только между BeginDraw() и EndDraw()
	    }

	    // Этот метод должен быть вызван в конце рисования
	    void EndDraw()
        {
            // Реализация остается без изменения
        }	
    };
}
