using System;
using System.Collections.Generic;
using System.Text;
using RGBAColor = System.UInt32;
using RectD = SlideLib.Rect<double>;


namespace SlideLib
{
    public interface IDrawable
    {
        void Draw(ICanvas canvas);
    };

    public interface IStyle
    {
        bool? IsEnabled();
        void Enable(bool enable);
        RGBAColor? GetColor();
        void SetColor(RGBAColor color);
    };

    public abstract class Component // Component: определяет интерфейс для всех компонентов в древовидной структуре
    {
        public Component() { }

        public abstract void Operation();

        public abstract void Add(Component c);

        public abstract void Remove(Component c);

        public abstract bool IsComposite();
    }

    /* в слайде может быть как одна фигура, так и группа фигур
     Слайд, как и фигуры могут быть нарисованы на холсте, представленном интерфейсом ICanvas. ICanvas предоставляет набор примитивных операций:
    •	Нарисовать отрезок прямой линии
    •	Нарисовать эллипс
    •	Заполнить эллипс
    •	Заполнить многоугольник, заданный массивом точек
    •	Изменить цвет заполнения внутренних областей фигур
    •	Изменить цвет рисования линий
    •	Изменить толщину рисования линий
    Вы можете внести необходимые изменения в список данных методов.
    */

    public class Composite : Component // и составными (группы фигур).
    {
        /*
             Свойства группы должны быть следующими:
        •	Фреймом группы должен быть фрейм, охватывающий свойства входящих в состав группы фигур
        •	Свойства стилей заливки и обводки группы фигур должны возвращать значение undefined (или его аналоги: null, none и т.п.) либо значение соответствующего свойства фигур в составе группы, если оно одинаково для всех фигур в составе группы
        При модификации свойств составной фигуры, должны происходить соответствующие изменения в составляющих ее фигурах:
        •	При изменении фрейма группы, входящие в ее состав фигуры должны пропорционально изменять свои координаты и размеры (см. видео в лекции)
        •	При изменении любого из свойств стиля обводки, полученного у группы, должны изменяться соответствующие свойства стилей обводки входящих в ее состав фигур. Аналогично поведение должно быть при изменении свойств стиля заливки, полученного у группы.
        В качестве реализации интерфейса ICanvas достаточно использовать вывод графических операций и их параметров в stdout.
        В приложении должен создаваться слайд, на который добавлены несколько фигур, как простых, так и составных, формирующих некоторое изображение (желательно, осмысленное). Затем приложение должно выполнять визуализацию слайда на холсте.
        */
        List<Component> _children = new List<Component>();

        public Composite()
        {
        }

        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public override bool IsComposite()
        {
            return true;
        }

        public override void Operation()
        {
            int i = 0;

            Console.Write("Branch(");
            foreach (Component component in _children)
            {
                component.Operation();
                if (i != _children.Count - 1)
                {
                    Console.Write("+");
                }
                i++;
            }
            Console.Write(")");
        }
    }

    public class Leaf : Component // Фигуры могут быть примитивными (прямоугольники, треугольники, эллипсы и т.п.) 
    {
        /*
         Каждая примитивная фигура обладает стилями обводки (LineStyle) и заливки (FillStyle), 
         а также ограничивающим прямоугольником (Frame), задающим координаты и размеры, внутри которых вписана фигура.
        Стиль заливки определяется:
        •	Наличием заливки. Фигуры с отключенной заливкой отображаются без заполнения внутренностей
        •	Цветом заливки в формате RGBA
        Стиль обводки определяется:
        •	Наличием обводки. Фигуры с отключенной обводкой отображаются без границы
        •	Цветом обводки в формате RGBA
        •	Толщиной рисования линий
        Данные свойства стилей доступны как для чтения, так и для записи
        */

        public Leaf()
        {
        }

        public override void Operation()
        {
            Console.Write("LEAF");
        }

        public override void Add(Component component)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Component component)
        {
            throw new NotImplementedException();
        }

        public override bool IsComposite()
        {
            return false;
        }
    }
}
