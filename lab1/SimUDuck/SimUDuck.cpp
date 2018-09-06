#include "stdafx.h"
#include <cassert>
#include <iostream>
#include <memory>

using namespace std;

struct IDanceBehavior
{
	virtual ~IDanceBehavior() {};
	virtual void Dance() = 0;
};
class DanceValse : public IDanceBehavior
{
public:
	void Dance() override
	{
		cout << "I'm dancing valse" << endl;
	}
};
class DanceMinuet : public IDanceBehavior
{
public:
	void Dance() override
	{
		cout << "I'm dancing minuet" << endl;
	}
};
class DanceNoWay : public IDanceBehavior
{
public:
	void Dance() override {}
};

struct IFlyBehavior
{
	virtual ~IFlyBehavior() {};
	virtual void Fly() = 0;
};
class FlyWithWings : public IFlyBehavior
{
public:
	void Fly() override
	{
		++m_numberOfFlights;
		cout << "I'm flying with wings!! " << m_numberOfFlights << endl;
	}
private:
	int m_numberOfFlights = 0;
};
class FlyNoWay : public IFlyBehavior
{
public:
	void Fly() override {}
};

struct IQuackBehavior
{
	virtual ~IQuackBehavior() {};
	virtual void Quack() = 0;
};
class QuackBehavior : public IQuackBehavior
{
public:
	void Quack() override
	{
		cout << "Quack Quack!!!" << endl;
	}
};
class SqueakBehavior : public IQuackBehavior
{
public:
	void Quack() override
	{
		cout << "Squeek!!!" << endl;
	}
};

class MuteQuackBehavior : public IQuackBehavior
{
public:
	void Quack() override {}
};

class Duck
{
public:
	Duck(unique_ptr<IFlyBehavior>&& flyBehavior,
		unique_ptr<IQuackBehavior>&& quackBehavior,
		unique_ptr<IDanceBehavior>&& danceBehavior)
		: m_quackBehavior(move(quackBehavior))
		, m_danceBehavior(move(danceBehavior))
	{
		assert(m_quackBehavior);
		SetFlyBehavior(move(flyBehavior));
	}
	void Quack() const
	{
		m_quackBehavior->Quack();
	}
	void Swim()
	{
		cout << "I'm swimming" << endl;
	}
	void Fly()
	{
		m_flyBehavior->Fly();
	}
	virtual void Dance()
	{
		m_danceBehavior->Dance();
		//cout << "I'm Dancing" << endl;
	}
	void SetFlyBehavior(unique_ptr<IFlyBehavior>&& flyBehavior)
	{
		assert(flyBehavior);
		m_flyBehavior = move(flyBehavior);
	}
	virtual void Display() const = 0;
	virtual ~Duck() = default;

private:
	unique_ptr<IQuackBehavior> m_quackBehavior;
	unique_ptr<IFlyBehavior> m_flyBehavior;
	unique_ptr<IDanceBehavior> m_danceBehavior;
};

class MallardDuck : public Duck
{
public:
	MallardDuck()
		: Duck(make_unique<FlyWithWings>(), make_unique<QuackBehavior>(), make_unique<DanceValse>())
	{
	}
	void Display() const override
	{
		cout << "I'm mallard duck" << endl;
	}
	void Dance() override 
	{
		cout << "I'm dancing valtz" << endl;
	}
};

class RedheadDuck : public Duck
{
public:
	RedheadDuck()
		: Duck(make_unique<FlyWithWings>(), make_unique<QuackBehavior>(), make_unique<DanceMinuet>())
	{
	}
	void Display() const override
	{
		cout << "I'm redhead duck" << endl;
	}
	void Dance() override
	{
		cout << "I'm dancing minuet" << endl;
	}
};

class DecoyDuck : public Duck
{
public:
	DecoyDuck()
		: Duck(make_unique<FlyNoWay>(), make_unique<MuteQuackBehavior>(), make_unique<DanceNoWay>())
	{
	}
	void Display() const override
	{
		cout << "I'm decoy duck" << endl;
	}
	void Dance() override {}
};

class RubberDuck : public Duck
{
public:
	RubberDuck()
		: Duck(make_unique<FlyNoWay>(), make_unique<SqueakBehavior>(), make_unique<DanceNoWay>())
	{
	}
	void Display() const override
	{
		cout << "I'm rubber duck" << endl;
	}
	void Dance() override {}
};

class ModelDuck : public Duck
{
public:
	ModelDuck()
		: Duck(make_unique<FlyNoWay>(), make_unique<QuackBehavior>(), make_unique<DanceNoWay>())
	{
	}
	void Display() const override
	{
		cout << "I'm model duck" << endl;
	}
	void Dance() override {}
};

void DrawDuck(Duck const& duck)
{
	duck.Display();
}

void PlayWithDuck(Duck& duck)
{
	DrawDuck(duck);
	duck.Quack();
	duck.Fly();
	duck.Fly();
	duck.Dance();
	cout << endl;
}

void main()
{
	MallardDuck mallarDuck;
	PlayWithDuck(mallarDuck);//MallardDuck умеет танцевать вальс

	RedheadDuck redheadDuck;
	PlayWithDuck(redheadDuck);//RedHeadDuck – менуэт

	RubberDuck rubberDuck;
	PlayWithDuck(rubberDuck);//Искусственные утки танцевать не умеют.

	DecoyDuck decoyDuck;
	PlayWithDuck(decoyDuck);//Искусственные утки танцевать не умеют.

	ModelDuck modelDuck;
	PlayWithDuck(modelDuck);
	modelDuck.SetFlyBehavior(make_unique<FlyWithWings>());
	PlayWithDuck(modelDuck);
}

/*
Доработайте программу SimUDuck, научив уток танцевать с использованием паттерна «Стратегия». 
MallardDuck умеет танцевать вальс, а RedHeadDuck – менуэт. 
Искусственные утки танцевать не умеют.
*/

/*
Доработайте программу SimUDuck таким образом, чтобы утки, умеющие летать, 
вели учет количества вылетов и выводили порядковый номер своего вылета в stdout. 
Примечание: от утки не требуется помнить число вылетов после смены стратегии полёта.
*/
