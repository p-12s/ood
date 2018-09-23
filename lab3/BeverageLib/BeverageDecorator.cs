namespace BeverageLib
{
    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage beverage;

        public BeverageDecorator(string name, Beverage beverage) : base(name)
        {
            this.beverage = beverage;
        }
    }

    // Размер порции кофе
    public enum CoffeeSize
    {
        Standard,
	    Double
    };

    public class Capuccino : BeverageDecorator
    {
        private CoffeeSize coffeeSize;

        public Capuccino(Beverage p, CoffeeSize size = CoffeeSize.Standard) : base(p.name + " Capuccino", p)
        {
            coffeeSize = size;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (coffeeSize == CoffeeSize.Standard ? 80 : 120);
        }
    }

    public class Latte : BeverageDecorator
    {
        private CoffeeSize coffeeSize;

        public Latte(Beverage p, CoffeeSize size = CoffeeSize.Standard) : base(p.name + " Latte", p)
        {
            coffeeSize = size;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (coffeeSize == CoffeeSize.Standard ? 90 : 130);
        }
    }

    // Добавка из корицы
    public class Cinnamon : BeverageDecorator
    {
        public Cinnamon(Beverage p) : base(p.name + ", Cinnamon", p)
        {
        }

        public override int GetCost()
        {
            return beverage.GetCost() + 20;
        }
    }

    // Лимонная добавка
    public class Lemon : BeverageDecorator
    {
        private int quantity;
        public Lemon(Beverage p, int quant = 1) : base(p.name + ", Lemon x" + quant, p)
        {
            quantity = quant;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (10 * quantity);
        }
    }

    public enum IceCubeType
    {
        Dry,    // Сухой лед (для суровых сибирских мужиков)
        Water   // Обычные кубики из воды
    };

    // Добавка "Кубики льда". Определяется типом и количеством кубиков, что влияет на стоимость и описание
    public class IceCubes : BeverageDecorator
    {
        private int quantity;
        private IceCubeType cubeType;

        public IceCubes(Beverage p, int quant = 1, IceCubeType type = IceCubeType.Water)
            : base(p.name + ", " + ((type == IceCubeType.Water) ? "Water " : "Dry ") + "ice cubes x" + quant, p)
        {
            quantity = quant;
            cubeType = type;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + ((cubeType == IceCubeType.Dry ? 10 : 5) * quantity);
        }
    }

    // Тип сиропа
    public enum SyrupType
    {
        Chocolate,  // Шоколадный
        Maple,		// Кленовый
    }

    public class Syrup : BeverageDecorator
    {
        private SyrupType syrupType;

        public Syrup(Beverage p, SyrupType type)
            : base(p.name + ", " + ((type == SyrupType.Chocolate) ? "Chocolate " : "Maple ") +
                  "syrup", p)
        {
            syrupType = type;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + 15;
        }
    }

    // Шоколадная крошка
    public class ChocolateCrumbs : BeverageDecorator
    {
        private int mass;

        public ChocolateCrumbs(Beverage p, int chocolateMass)
            : base(p.name + ", Chocolate crumbs " + chocolateMass.ToString() + "g", p)
        {
            mass = chocolateMass;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (2 * mass);
        }
    }

    // Кокосовая крошка
    public class CoconutFlakes : BeverageDecorator
    {
        private int mass;

        public CoconutFlakes(Beverage p, int coconutMass)
            : base(p.name + ", Coconut flakes " + coconutMass.ToString() + "g", p)
        {
            mass = coconutMass;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (1 * mass);
        }
    }
}
