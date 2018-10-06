using System;
using BeverageLib;

namespace BeverageApp
{
    class Program
    {
        public static void PrintBeverage(Beverage beverage)
        {
            Console.WriteLine("Name: {0}\nCosts: {1}\n", beverage._description, beverage.GetCost());
        }

        static void Main(string[] args)
        {
            Beverage latte = new Latte(); // 90
            latte = new Cinnamon(latte); // 20
            latte = new ChocolateCrumbs(latte, 2); // 2*2
            PrintBeverage(latte);

            Beverage capuccino = new Capuccino(CoffeeSize.Double); // 120
            capuccino = new Cinnamon(capuccino); // 20
            capuccino = new ChocolateCrumbs(capuccino, 2); // 2*2
            PrintBeverage(capuccino);
             
            Beverage tea = new Tea(GradeOfTea.Vietnamese); // 30
            tea = new Lemon(tea, 2); // 10*2
            tea = new Syrup(tea, SyrupType.Maple); // 15
            PrintBeverage(tea);

            Beverage milkshakeLarge = new Milkshake(); // 80
            milkshakeLarge = new Syrup(milkshakeLarge, SyrupType.Chocolate); // 15
            PrintBeverage(milkshakeLarge);

            Beverage milkshakeMedium = new Milkshake(MilkShakeSize.Medium); // 60
            PrintBeverage(milkshakeMedium);

            Beverage milkshakeSmall = new Milkshake(MilkShakeSize.Small); // 50
            PrintBeverage(milkshakeSmall);
        }

    }
}