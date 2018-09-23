using System;
using BeverageLib;

namespace BeverageApp
{
    class Program
    {
        public static void PrintBeverage(Beverage beverage)
        {
            Console.WriteLine("Title: {0}\nCosts: {1}", beverage.Name, beverage.GetCost());
        }

        static void Main(string[] args)
        {
            Beverage latte = new Coffee();
            latte = new Latte(latte);
            latte = new Cinnamon(latte);
            latte = new Lemon(latte, 2);
            latte = new IceCubes(latte, 2, IceCubeType.Dry);
            latte = new ChocolateCrumbs(latte, 2);

            PrintBeverage(latte);
        }
        
    }
}


