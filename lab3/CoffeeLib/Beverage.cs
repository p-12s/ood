namespace BeverageLib
{
    public abstract class Beverage
    {
        public Beverage(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }

        public abstract int GetCost();
    }

    public class Coffee : Beverage
    {
        public Coffee() : base("Coffee")
        {
        }

        public override int GetCost()
        {
            return 60;
        }
    }

    public class Tea : Beverage
    {
        public Tea() : base("Tea")
        {
        }

        public override int GetCost()
        {
            return 30;
        }
    }

    public class Milkshake : Beverage
    {
        public Milkshake() : base("Milkshake")
        {
        }

        public override int GetCost()
        {
            return 80;
        }
    }

    public abstract class BeverageDecorator : Beverage
    {
        protected Beverage beverage;

        public BeverageDecorator(string name, Beverage beverage) : base(name)
        {
            this.beverage = beverage;
        }
    }

    public class Capuccino : BeverageDecorator
    {
        public Capuccino(Beverage p) : base(p.Name + " Capuccino", p)
        {
        }

        public override int GetCost()
        {
            return beverage.GetCost() + 80;
        }
    }

    public class Latte : BeverageDecorator
    {
        public Latte(Beverage p) : base(p.Name + " Latte", p)
        {
        }

        public override int GetCost()
        {
            return beverage.GetCost() + 90;
        }
    }

    // Добавка из корицы
    public class Cinnamon : BeverageDecorator
    {
        public Cinnamon(Beverage p) : base(p.Name + ", Cinnamon", p)
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
        private int Quantity;
        public Lemon(Beverage p, int quantity = 1) : base(p.Name + ", Lemon x" + quantity, p)
        {
            Quantity = quantity;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (10 * Quantity);
        }
    }

    public enum IceCubeType
    {
        Dry,	// Сухой лед (для суровых сибирских мужиков)
	    Water   // Обычные кубики из воды
    };
    
    // Добавка "Кубики льда". Определяется типом и количеством кубиков, что влияет на стоимость и описание
    public class IceCubes : BeverageDecorator
    {
        private int Quantity;
        private IceCubeType Type;

        public IceCubes(Beverage p, int quantity = 1, IceCubeType type = IceCubeType.Water) 
            : base(p.Name + ", " + ((type == IceCubeType.Water) ? "Water " : "Dry ") + 
                  "ice cubes x" + quantity, p)
        {
            Quantity = quantity;
            Type = type;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + ((Type == IceCubeType.Dry ? 10 : 5) * Quantity);
        }
    }

    // Тип сиропа
    public enum SyrupType
    {
        Chocolate,	// Шоколадный
	    Maple,		// Кленовый
    }

    public class Syrup : BeverageDecorator
    {
        private SyrupType SyrupType;

        public Syrup(Beverage p, SyrupType syrupType)
            : base(p.Name + ", " + ((syrupType == SyrupType.Chocolate) ? "Chocolate " : "Maple ") +
                  "syrup", p)
        {
            SyrupType = syrupType;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + 15;
        }
    }

    // Шоколадная крошка
    public class ChocolateCrumbs : BeverageDecorator
    {
        private int Mass;

        public ChocolateCrumbs(Beverage p, int mass)
            : base(p.Name + ", Chocolate crumbs " + mass.ToString() + "g", p)
        {
            Mass = mass;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (2 * Mass);
        }
    }

    // Кокосовая крошка
    public class CoconutFlakes : BeverageDecorator
    {
        private int Mass;

        public CoconutFlakes(Beverage p, int mass)
            : base(p.Name + ", Coconut flakes " + mass.ToString() + "g", p)
        {
            Mass = mass;
        }

        public override int GetCost()
        {
            return beverage.GetCost() + (1 * Mass);
        }
    }

}
