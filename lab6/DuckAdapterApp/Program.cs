using System;

namespace DuckAdapterApp
{
    public interface IDuck
    {
        void Quack();
	    void Fly();
    };

    class MallardDuck : IDuck
    {
        public void Quack()
	    {
            Console.WriteLine("Quack");
	    }

        public void Fly()
	    {
            Console.WriteLine("I'm flying");
        }
    };

    public interface ITurkey
    {
        void Gobble();
	    void Fly();
    };

    class WildTurkey : ITurkey
    {
        public void Gobble()
        {
            Console.WriteLine("Gobble gobble");
        }
        public void Fly()
        {
            Console.WriteLine("I'm flying a short distance");
        }
    };
    
    class TurkeyAdapter : IDuck // адаптер заставляет индейку имитировать утку 
    {
        private ITurkey _turkey;

        public TurkeyAdapter(ITurkey turkey)
        {
            _turkey = turkey;
        }

        public void Quack()
	    {
		    _turkey.Gobble();
	    }

        public void Fly()
	    {
		    for (int i = 0; i< 5; ++i)
			    _turkey.Fly();
	    }

    };

    class Program
    {
        static void Main(string[] args)
        {
            void TestDuck(IDuck duck)
            {
                duck.Quack();
                duck.Fly();
            }

            MallardDuck mallardDuck = new MallardDuck();
            TestDuck(mallardDuck);

            WildTurkey wildTurkey = new WildTurkey();
            TurkeyAdapter turkeyAdapter = new TurkeyAdapter(wildTurkey);
            TestDuck(turkeyAdapter);
        }
    }
}
