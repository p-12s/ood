namespace BeverageLib
{
    public abstract class Beverage 
    {
        public string _description { get; protected set; }

        public Beverage(string description)
        {
            _description = description;
        }

        public abstract int GetCost();
    }

    // Размер порции кофе
    public enum CoffeeSize
    {
        Standard,
        Double
    };

    public class Capuccino : Beverage
    {
        private CoffeeSize _coffeeSize;

        public Capuccino(CoffeeSize coffeeSize = CoffeeSize.Standard)
            : base("Capuccino")
        {
            _coffeeSize = coffeeSize;
        }
        
        public override int GetCost()
        {
            return _coffeeSize == CoffeeSize.Standard ? 80 : 120;
        }
    }

    public class Latte : Beverage
    {
        private CoffeeSize _coffeeSize;

        public Latte(CoffeeSize coffeeSize = CoffeeSize.Standard)
            : base("Latte")
        {
            _coffeeSize = coffeeSize;
        }

        public override int GetCost()
        {
            return _coffeeSize == CoffeeSize.Standard ? 90 : 130;
        }
    }

    public enum GradeOfTea
    {
        Chinese,
        Indian,
        Japanese,
        Vietnamese
    };

    public class Tea : Beverage
    {
        private static GradeOfTea _gradeOfTea;

        private static string GetGradeName(GradeOfTea gradeOfTea)
        {
            switch(gradeOfTea)
            {
                case GradeOfTea.Indian:
                    return "Indian";

                case GradeOfTea.Chinese:
                    return "Chinese";

                case GradeOfTea.Japanese:
                    return "Japanese";

                case GradeOfTea.Vietnamese:
                    return "Vietnamese";

                default:
                    return "Unknown";
            }
        }

        public Tea(GradeOfTea gradeOfTea = GradeOfTea.Indian) : 
            base(GetGradeName(gradeOfTea) + " Tea")
        {
            _gradeOfTea = gradeOfTea;
        }

        public override int GetCost()
        {
            return 30;
        }
    }

    // Размер порции молочного коктейля
    public enum MilkShakeSize
    {
        Small,
	    Medium,
	    Large
    };

    public class Milkshake : Beverage
    {
        private static MilkShakeSize _milkShakeSize;

        private static string GetGradeName(MilkShakeSize milkShakeSize)
        {
            switch (milkShakeSize)
            {
                case MilkShakeSize.Small:
                    return "Small";

                case MilkShakeSize.Medium:
                    return "Medium";

                case MilkShakeSize.Large:
                    return "Large";

                default:
                    return "Uncknown";
            }
        }

        public Milkshake(MilkShakeSize milkShakeSize = MilkShakeSize.Large) : 
            base(GetGradeName(milkShakeSize) + " Milkshake")
        {
            _milkShakeSize = milkShakeSize;
        }

        public override int GetCost()
        {
            return (_milkShakeSize == MilkShakeSize.Small ? 50 :
                _milkShakeSize == MilkShakeSize.Medium ? 60 : 80);
        }
    }

}
