using RGBAColor = System.UInt32;

namespace SlideLib
{
    public interface ICanvas
    {
        // Изменить цвет рисования линий
        void SetLineColor(RGBAColor color);

        // Изменить толщину рисования линий
        void SetLineThickness(int thickness);

        // Изменить цвет заполнения внутренних областей фигур
        void BeginFill(RGBAColor color);
	    void EndFill();

        // Нарисовать отрезок прямой линии
        void MoveTo(int x, int y);
	    void LineTo(int x, int y);

        //	Нарисовать эллипс
        void DrawEllipse(int left, int top, int width, int height);
        
        // Заполнить эллипс
        // Заполнить многоугольник, заданный массивом точек


    }
}
