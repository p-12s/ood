using System;

namespace GraphicsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Should we use new API (y)?");

            string choice = Console.ReadLine();
            if (choice.ToLower() == "y")
            {
                App.PaintPictureOnModernGraphicsRenderer();
            }
            else
            {
                App.PaintPictureOnCanvas();
            }
            // портировать классы

        }
    }
}
