namespace BeverageLib
{
    public abstract class CondimentDecorator : Beverage
    {
        private Beverage _beverage;

        public CondimentDecorator(string description, Beverage beverage)
            : base(description)
        {
            _beverage = beverage;
        }

        public override sealed int GetCost()
        {
            return _beverage.GetCost() + GetCondimentCost();
        }

        protected abstract int GetCondimentCost();
    }

    // Добавка из корицы
    public class Cinnamon : CondimentDecorator
    {
        public Cinnamon(Beverage p)
            : base(p._description + ", Cinnamon", p)
        {
        }

        protected override int GetCondimentCost()
        {
            return 20;
        }
    }

    // Лимонная добавка
    public class Lemon : CondimentDecorator
    {
        private int _quantity;
        public Lemon(Beverage p, int quantity = 1)
            : base(p._description + ", Lemon x" + quantity, p)
        {
            _quantity = quantity;
        }

        protected override int GetCondimentCost()
        {
            return 10 * _quantity;
        }
    }

    public enum IceCubeType
    {
        Dry,    // Сухой лед (для суровых сибирских мужиков)
        Water   // Обычные кубики из воды
    };

    // Добавка "Кубики льда". Определяется типом и количеством кубиков, что влияет на стоимость и описание
    public class IceCubes : CondimentDecorator
    {
        private int _quantity;
        private IceCubeType _cubeType;

        public IceCubes(Beverage p, int quantity = 1, IceCubeType cubeType = IceCubeType.Water)
            : base(p._description + ", " + ((cubeType == IceCubeType.Water) ? "Water " : "Dry ")
                  + "ice cubes x" + quantity, p)
        {
            _quantity = quantity;
            _cubeType = cubeType;
        }

        protected override int GetCondimentCost()
        {
            return (_cubeType == IceCubeType.Dry ? 10 : 5) * _quantity;
        }
    }

    // Тип сиропа
    public enum SyrupType
    {
        Chocolate,  // Шоколадный
        Maple,		// Кленовый
    }

    public class Syrup : CondimentDecorator
    {
        private SyrupType _syrupType;

        public Syrup(Beverage p, SyrupType syrupType)
            : base(p._description + ", " + ((syrupType == SyrupType.Chocolate) ? "Chocolate " : "Maple ") +
                  "syrup", p)
        {
            _syrupType = syrupType;
        }

        protected override int GetCondimentCost()
        {
            return 15;
        }
    }

    // Шоколадная крошка
    public class ChocolateCrumbs : CondimentDecorator
    {
        private int _mass;

        public ChocolateCrumbs(Beverage p, int mass)
            : base(p._description + ", Chocolate crumbs " + mass.ToString() + "g", p)
        {
            _mass = mass;
        }

        protected override int GetCondimentCost()
        {
            return 2 * _mass;
        }
    }

    // Кокосовая крошка
    public class CoconutFlakes : CondimentDecorator
    {
        private int _mass;

        public CoconutFlakes(Beverage p, int mass)
            : base(p._description + ", Coconut flakes " + mass.ToString() + "g", p)
        {
            _mass = mass;
        }

        protected override int GetCondimentCost()
        {
            return 1 * _mass;
        }
    }
}
