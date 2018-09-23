namespace BeverageLib
{
    public abstract class Beverage
    {
        public Beverage(string name)
        {
            this.name = name;
        }

        public string name { get; protected set; } // private?

        public abstract int GetCost();
    }

    public class Coffee : Beverage
    {
        public Coffee() : base("Coffee")
        {
        }
        
        public override int GetCost()
        {
            return 0; // хак
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
        private static GradeOfTea gradeOfTea;

        private static string GetGradeName(GradeOfTea grade)
        {
            switch(grade)
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
                    return "Uncknown";
            }
        }

        public Tea(GradeOfTea grade = GradeOfTea.Indian) : base(GetGradeName(grade) + " Tea")
        {
            gradeOfTea = grade;
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
        private MilkShakeSize milkShakeSize;

        private static string GetGradeName(MilkShakeSize size)
        {
            switch (size)
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

        public Milkshake(MilkShakeSize size = MilkShakeSize.Large) : base(GetGradeName(size) + " Milkshake")
        {
            milkShakeSize = size;
        }

        public override int GetCost()
        {
            return (milkShakeSize == MilkShakeSize.Small ? 50 : 
                milkShakeSize == MilkShakeSize.Medium ? 60 : 80);
        }
    }

}
