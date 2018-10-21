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

// Пространство имен библиотеки для рисования фигур (использует GraphicsLib)
// Код библиотеки недоступен для изменения
namespace ShapeDrawingLib
{
    public struct Point
    {
        public int x;
        public int y;
    };

    // Интерфейс объектов, которые могут быть нарисованы на холсте из GraphicsLib
    interface ICanvasDrawable
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
    class CanvasPainter
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
        private int _x, _y;

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }
    };

    // Класс для современного рисования графики
    class ModernGraphicsRenderer
    {
        public ModernGraphicsRenderer(ostream & strm) : m_out(strm)
        {
        }

        /*~CModernGraphicsRenderer() как это будет у меня?
        {
            if (m_drawing) // Завершаем рисование, если оно было начато
            {
                EndDraw();
            }
        }*/

        // Этот метод должен быть вызван в начале рисования
        void BeginDraw()
        {
            if (m_drawing)
            {
                throw logic_error("Drawing has already begun");
            }
            m_out << "<draw>" << endl;
            m_drawing = true;
        }

        // Выполняет рисование линии
        public void DrawLine(const CPoint & start, const CPoint & end)
	    {
		    if (!m_drawing)
		    {
			    throw logic_error("DrawLine is allowed between BeginDraw()/EndDraw() only");
            }
            m_out << boost::format(R"(  <line fromX="%1%" fromY="%2" toX="%3%" toY="%4%"/>)") << endl;
	    }

// Этот метод должен быть вызван в конце рисования
void EndDraw()
{
    if (!m_drawing)
    {
        throw logic_error("Drawing has not been started");
    }
    m_out << "</draw>" << endl;
    m_drawing = false;
}
private:
	ostream & m_out;
	bool m_drawing = false;
};
}



/////////////
///
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

void PaintPictureOnModernGraphicsRenderer()
{
    modern_graphics_lib::CModernGraphicsRenderer renderer(cout);
    (void)&renderer; // устраняем предупреждение о неиспользуемой переменной

    // TODO: при помощи существующей функции PaintPicture() нарисовать
    // картину на renderer
    // Подсказка: используйте паттерн "Адаптер"
}
}

namespace graphics_lib_pro
{
    // Холст для рисования
    class ICanvas
    {
        public:
	// Установка цвета в формате 0xRRGGBB
	virtual void SetColor(uint32_t rgbColor) = 0;
	virtual void MoveTo(int x, int y) = 0;
	virtual void LineTo(int x, int y) = 0;
	virtual ~ICanvas() = default;
};

    // Реализация холста для рисования
    class CCanvas : public ICanvas
{
public:
	void SetColor(uint32_t rgbColor) override
	{
		// TODO: вывести в output цвет в виде строки SetColor (#RRGGBB)
	}
void MoveTo(int x, int y) override
	{
		// Реализация остается без изменения
	}
	void LineTo(int x, int y) override
	{
		// Реализация остается без изменения
	}
};
}

// Пространство имен обновленной современной графической библиотеки (недоступно для изменения)
namespace modern_graphics_lib_pro
{
    class CPoint
    {
        public:
	CPoint(int x, int y) :x(x), y(y) { }

        int x;
        int y;
    };

    // Цвет в формате RGBA, каждый компонент принимает значения от 0.0f до 1.0f
    class CRGBAColor
    {
        public:
	CRGBAColor(float r, float g, float b, float a) :r(r), g(g), b(b), a(a) { }
        float r, g, b, a;
    };

    // Класс для современного рисования графики
    class CModernGraphicsRenderer
    {
        public:
	CModernGraphicsRenderer(ostream & strm) : m_out(strm)
        {
        }

        ~CModernGraphicsRenderer()
        {
            // Реализация остается без изменения
        }

        // Этот метод должен быть вызван в начале рисования
        void BeginDraw()
        {
            // Реализация остается без изменения
        }

        // Выполняет рисование линии
        void DrawLine(const CPoint & start, const CPoint & end, const CRGBAColor& color)
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
        private:
	ostream & m_out;
	bool m_drawing = false;
    };
}

int main()
{
    cout << "Should we use new API (y)?";
    string userInput;
    if (getline(cin, userInput) && (userInput == "y" || userInput == "Y"))
    {
        app::PaintPictureOnModernGraphicsRenderer();
    }
    else
    {
        app::PaintPictureOnCanvas();
    }

    return 0;
}
