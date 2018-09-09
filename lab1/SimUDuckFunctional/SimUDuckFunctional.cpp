#include "stdafx.h"
#include <algorithm>
#include <functional>
#include <iostream>
#include <string>

// lambdas
// https://github.com/alexey-malov/oop/blob/master/samples/01-basics/lambdas/main.cpp
using namespace std;

using Strategy = function<int(int x, int y)>; // strategy - вроде что-то с void

class Context // Duck
{
public:
	int PerformOperation(int x, int y)
	{
		if (m_strategy)
		{
			return m_strategy(x, y);//вернет стратегию, которая яв-ся полем класса
		}
		return 0;
	}
	void SetStrategy(const Strategy& s) // проинициализируем стратегию
	{
		m_strategy = s;
	}

private:
	Strategy m_strategy;
};
// переименовать в утку или что там
// добавить стратегий



int AddingStrategy(int x, int y)
{
	return x + y;
}

int SubtractionStrategy(int x, int y)
{
	return x - y;
}

void main()
{
	{
		int numbers[] = { 6, 3, 2, 1, 3, 4 };
		sort(begin(numbers), end(numbers), [](int x, int y) { return x < y; });
		// отсортировало: 1, 2, 3, 3, 4, 6 - лучше запомнить, f11 непонятно
		sort(begin(numbers), end(numbers), less<int>());// аналог предыдущей

		function<bool(int, int)> compare = [](int x, int y) { return x < y; };
		sort(begin(numbers), end(numbers), compare);
	}
	{
		Context ctx;

		ctx.SetStrategy([](int x, int y) { return x + y; });//принимает 2 инта, возвр. инт
		cout << ctx.PerformOperation(1, 2) << endl;// 3
		// теперь стратегия проинициализирована, до этого была пуста


		ctx.SetStrategy(AddingStrategy); // вот так меняя стратегии, выполняется оператор
		cout << ctx.PerformOperation(1, 2) << endl;//3

		ctx.SetStrategy(SubtractionStrategy);
		cout << ctx.PerformOperation(1, 2) << endl;//-1
	}
}

/*

Перепишите приложение SimUDuck, реализовав паттерн «Стратегия» в функциональном стиле.
*/
