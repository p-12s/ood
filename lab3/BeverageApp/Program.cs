using System;
using BeverageLib;

namespace BeverageApp
{
    class Program
    {
        public static void PrintBeverage(Beverage beverage)
        {
            Console.WriteLine("Name: {0}\nCosts: {1}\n", beverage.name, beverage.GetCost());
        }

        static void Main(string[] args)
        {
            /*latte = new Cinnamon(latte);
            Beverage latte = new Coffee(); // тут странно, приходится кофе делать цену 0
            latte = new Latte(latte);
            latte = new Lemon(latte, 2);
            latte = new IceCubes(latte, 2, IceCubeType.Dry);
            latte = new ChocolateCrumbs(latte, 2);

            PrintBeverage(latte);*/


            /* Beverage tea = new Tea();
             PrintBeverage(tea);
             */
             Beverage tea1 = new Tea();
             PrintBeverage(tea1);

            Milkshake milkshake1 = new Milkshake();
            milkshake1 = new Lemon(milkshake1, 2); ;// new Syrup(milkshake1, SyrupType.Chocolate);
            PrintBeverage(milkshake1);

            Milkshake milkshake2 = new Milkshake(MilkShakeSize.Medium);
            PrintBeverage(milkshake2);

            Milkshake milkshake3 = new Milkshake(MilkShakeSize.Small);
            PrintBeverage(milkshake3);

            /*
             Beverage tea2 = new Tea(GradeOfTea.Japanese);
             PrintBeverage(tea2);

             Beverage tea3 = new Tea(GradeOfTea.Vietnamese);
             PrintBeverage(tea3);*/


            // распечатать каждый кейс
        }

    }
}

/*
 Изучив запросы клиентов, было принято увеличить ассортимент предлагаемых напитков:
    • Ввести стандартную и двойную порцию латте. Двойная порция стоит 130 рублей, стандартная – 90. 
    • Ввести стандартную (80) и двойную (120р) порции капучино

    • Предлагать покупателям 4 сорта чая (цена не зависит от стоимости). Названия сортов 
    выберите на свое усмотрение.

    • Предлагать маленькую (50 р), среднюю (60р) и большую (80р) порции молочных коктейлей
Реализуйте в программе необходимые изменения.
Размер порции напитка, а также сорт чая влияет на описание напитка.
     */
