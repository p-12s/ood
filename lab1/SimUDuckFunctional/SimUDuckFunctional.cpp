#include "stdafx.h"

using namespace std;

// https://github.com/alexey-malov/oop/blob/master/samples/01-basics/lambdas/main.cpp
using FlyBehavior = function<void()>;
FlyBehavior FlyWithWings()
{
	unsigned int numberOfFlights = 1;
	return [=]() mutable {
		cout << "I'm flying with wings!! " << numberOfFlights << endl;
		++numberOfFlights;
		// variables is captured by the value (which can be changed inside the lambda)
	};
}
void FlyNoWay()
{
}

using QuackBehavior = function<void()>;
void DoQuack()
{
	cout << "Quack Quack!!!" << endl;
}
void Squeak()
{
	cout << "Squeek!!!" << endl;
};
void MuteQuack(){};

using DanceBehavior = function<void()>;
void DanceValse()
{
	cout << "I'm dancing valse" << endl;
}
void DanceMinuet()
{
	cout << "I'm dancing minuet" << endl;
}
void DanceNoWay()
{
}

class Duck
{
public:
	Duck(
		FlyBehavior const& flyBehavior,
		QuackBehavior const& quackBehavior,
		DanceBehavior const& danceBehavior)
		: m_quackBehavior(quackBehavior)
		, m_danceBehavior(danceBehavior)
	{
		SetFlyBehavior(flyBehavior);
	}
	void Fly() const
	{
		m_flyBehavior();
	}
	void Quack() const
	{
		m_quackBehavior();
	}
	void Dance() const
	{
		m_danceBehavior();
	}
	void SetFlyBehavior(FlyBehavior const& flyBehavior)
	{
		m_flyBehavior = flyBehavior;
	}
	static void Swim()
	{
		cout << "I'm swimming" << endl;
	}
	virtual void Display() const = 0;
	virtual ~Duck() = default;

private:
	FlyBehavior m_flyBehavior;
	QuackBehavior m_quackBehavior;
	DanceBehavior m_danceBehavior;
};

void DrawDuck(Duck const& duck)
{
	duck.Display();
}
void PlayWithDuck(Duck& duck)
{
	DrawDuck(duck);
	duck.Fly();
	duck.Fly();
	duck.Quack();
	duck.Dance();
	cout << endl;
}

class MallardDuck : public Duck
{
public:
	MallardDuck()
		: Duck(FlyWithWings(), DoQuack, DanceValse)
	{
	}

	void Display() const override
	{
		cout << "I'm mallard duck" << endl;
	}
};
class RedheadDuck : public Duck
{
public:
	RedheadDuck()
		: Duck(FlyWithWings(), DoQuack, DanceMinuet)
	{
	}
	void Display() const override
	{
		cout << "I'm redhead duck" << endl;
	}
};
class DecoyDuck : public Duck
{
public:
	DecoyDuck()
		: Duck(FlyNoWay, MuteQuack, DanceNoWay)
	{
	}
	void Display() const override
	{
		cout << "I'm decoy duck" << endl;
	}
};
class RubberDuck : public Duck
{
public:
	RubberDuck()
		: Duck(FlyNoWay, Squeak, DanceNoWay)
	{
	}
	void Display() const override
	{
		cout << "I'm rubber duck" << endl;
	}
};
class ModelDuck : public Duck
{
public:
	ModelDuck()
		: Duck(FlyNoWay, DoQuack, DanceNoWay)
	{
	}
	void Display() const override
	{
		cout << "I'm model duck" << endl;
	}
};

void main()
{
	MallardDuck mallarDuck;
	PlayWithDuck(mallarDuck);

	RedheadDuck redheadDuck;
	PlayWithDuck(redheadDuck);

	RubberDuck rubberDuck;
	PlayWithDuck(rubberDuck);

	DecoyDuck decoyDuck;
	PlayWithDuck(decoyDuck);

	ModelDuck modelDuck;
	PlayWithDuck(modelDuck);
	modelDuck.SetFlyBehavior(FlyWithWings());
	PlayWithDuck(modelDuck);
	modelDuck.SetFlyBehavior(FlyNoWay);
	PlayWithDuck(modelDuck);
	modelDuck.SetFlyBehavior(FlyWithWings());
	PlayWithDuck(modelDuck);
}
