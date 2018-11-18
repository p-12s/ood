using System;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<int>;
using SlideLib;
using SlideLib.Shapes;


class Program
{
    /*public class Client
    {
        // принимает абстрактный класс, от которого наследуются и компоновщик, и лист
        public void ClientCode(ICanvas canvas, Shape Shape)
        {
            Console.Write("RESULT: ");
            Shape.Draw(ref canvas);
        }

        public void ClientCode2(ICanvas canvas, Shape shape1, Shape shape2)
        {
            if (shape1.IsComposite())
            {
                shape1.Add(shape2);
            }

            Console.Write("RESULT: ");
            shape1.Draw(ref canvas);

            Console.WriteLine();
        }

    }*/
    /*
     В приложении должен создаваться слайд, на который добавлены несколько фигур, как простых, так и составных, 
     формирующих некоторое изображение (желательно, осмысленное). 
     Затем приложение должно выполнять визуализацию слайда на холсте.
         */
    static void Main(string[] args)
    {
        var slide = new Slide();

        var canvas = new Canvas();

        Shape rectangle = new Rectangle(new Point<int>(1, 10), new Point<int>(10, 1));

        Group tree = new Group();

        Group group2 = new Group();
        group2.Add(new Ellipse(new Point<int>(0, 0), 10, 20));
        group2.Add(new Triangle(new Point<int>(0, 0), new Point<int>(10, 10), new Point<int>(-10, -10)));

        Group group3 = new Group();
        group3.Add(new Triangle(new Point<int>(0, 0), new Point<int>(10, 10), new Point<int>(-10, -10)));

        tree.Add(group3);
        tree.Add(group3);


        // ОСТАНОВИЛСЯ ТУТ: создать слайдодержатель, и чтоб каждый слайд содержал фигуры и пока все. потом буду врететь этими фигурами



        // умею: 
        // объединять фигуры в группы
        // условно рисовать фигуры (вывожу название)


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

