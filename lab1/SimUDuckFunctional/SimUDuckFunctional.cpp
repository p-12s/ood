#include "stdafx.h"

// lambdas
// https://github.com/alexey-malov/oop/blob/master/samples/01-basics/lambdas/main.cpp

using namespace std;

using FlyBehavior = function<void()>; // перекинуть обратно
using QuackBehavior = function<void()>;
using DanceBehavior = function<void()>;

FlyBehavior FlyWithWings() // TODO переделать без лямбды
{
	unsigned int numberOfFlights = 1;
	return [=]() mutable {
		cout << "I'm flying with wings!! " << numberOfFlights << endl;
		++numberOfFlights;
	};
}
void FlyNoWay()
{
}

//using QuackBehavior = function<void()>;
void Quack()
{
	cout << "Quack Quack!!!" << endl;
}
void Squeak()
{
	cout << "Squeek!!!" << endl;
};
void MuteQuack(){};

//using DanceBehavior = function<void()>;
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

class Duck // Duck
{
public:
	Duck( // почему конст и мув?
		FlyBehavior const& flyBehavior,
		QuackBehavior const& quackBehavior,
		DanceBehavior const& danceBehavior)
		//: m_flyBehavior(flyBehavior)
		: m_quackBehavior(quackBehavior)
		, m_danceBehavior(move(danceBehavior))
	{
		SetFlyBehavior(flyBehavior);
	}
	void Fly() //const
	{
		m_flyBehavior();
	}
	void Quack() const
	{
		m_quackBehavior();
	}
	virtual void Dance() // const ,надо? почему вирутальный только он?
	{
		m_danceBehavior();
	}
	void SetFlyBehavior(FlyBehavior const& flyBehavior)
	{
		m_flyBehavior = flyBehavior;
	}
	void Swim() const
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
	duck.Quack();
	duck.Dance();
	cout << endl;
}

class MallardDuck : public Duck
{
public:
	MallardDuck()
		: Duck(FlyWithWings(), Quack, DanceValse)
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
		: Duck(FlyWithWings(), Quack, DanceMinuet)
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
/*
class ModelDuck : public Duck
{
public:
	ModelDuck()
		: Duck(FlyNoWay, Quack, DanceNoWay)
	{
	}
	void Display() const override
	{
		cout << "I'm model duck" << endl;
	}
};*/

class ModelDuck : public Duck
{
public:
	ModelDuck()
		: Duck(FlyNoWay, Quack, DanceNoWay)
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
}

/*

Перепишите приложение SimUDuck, реализовав паттерн «Стратегия» в функциональном стиле.
*/
