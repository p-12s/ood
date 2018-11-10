namespace SlideLib
{
    public struct Point<T>
    {
        public Point(T x, T y)
        {
            X = x;
            Y = y;
        }

        public T X {get; set;}
        public T Y {get; set;}
    }

    public struct Rect<T>
    {
        public Point<T> topLeft { get; set; }
        public Point<T> bottomRight { get; set; }
    };

}
