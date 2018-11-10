namespace SlideLib
{
    public struct Rect<T> // может переделать на 2 точки? если ничего не мешает - лучше будет
    {
        public T left { get; set; }
        public T top { get; set; }
        public T width { get; set; }
        public T height { get; set; }
    };

    //typedef Rect<double> RectD;
    //typedef uint RGBAColor;
    
}
