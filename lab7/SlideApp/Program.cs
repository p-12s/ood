using System;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;
using SlideLib;
using SlideLib.Shapes;


class Program
{
    /*
     В приложении должен создаваться слайд, на который добавлены несколько фигур, как простых, так и составных, 
     формирующих некоторое изображение (желательно, осмысленное). 
     Затем приложение должно выполнять визуализацию слайда на холсте.
    */

    static void Main(string[] args)
    {
        var slide = new Slide();
        var canvas = new Canvas();
        
        // поляна
        Shape glade = new Ellipse(new Point<int>(0, 0), 8, 20);

        // дом
        Group house = new Group();
        // стены с окном
        Group wallsWithWindow = new Group();
        wallsWithWindow.Add(new Rectangle(new Point<int>(0, 10), new Point<int>(10, 0)));
        wallsWithWindow.Add(new Ellipse(new Point<int>(5, 5), 3, 2));
        // крыша
        Group roof = new Group();
        roof.Add(new Triangle(new Point<int>(-2, 10), new Point<int>(5, 20), new Point<int>(12, 10)));

        house.Add(wallsWithWindow);
        house.Add(roof);

        slide.AddShape(glade);
        slide.AddShape(house);

        slide.Draw(canvas);


        // ОСТАНОВИЛСЯ ТУТ: создать слайдодержатель, и чтоб каждый слайд содержал фигуры и пока все. потом буду манип этими фигурами



        // что я могу делать с фигурами?

        // умею: 
        // объединять фигуры в группы
        // условно рисовать фигуры (вывожу название)
        // добавить на слайд домик из линий

        /*
        // ПРЯМОУГОЛЬНИК
        var rectangle = new Rectangle(new Point<int>(1, 10), new Point<int>(10, 1));
        
        // получить фрейм
        var rectangleFrame = rectangle.GetFrame();

        // изменить фрейм
        var newFrame = new RectD
        {
            topLeft = new Point<int>(10, 100),
            bottomRight = new Point<int>(100, 10)
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
        

        // ЭЛЛИПС
        var ellipse = new Ellipse(new Point<int>(0, 0), 10, 20);
        // обводка
         lineStyle = ellipse.GetLineStyle();
         ellipse.SetLineStyle(style1);
         lineStyle = ellipse.GetLineStyle();

         // заливка
         fillStyle = ellipse.GetFillStyle();
         ellipse.SetFillStyle(style2);
         fillStyle = ellipse.GetFillStyle();


         // ТРЕУГОЛЬНИК
         var triangle = new Triangle(new Point<int>(0, 0), new Point<int>(10, 10), new Point<int>(-10, -10));
         */



    }
}

