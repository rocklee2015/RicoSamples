<Query Kind="Program" />

void Main()
{
	Expression<Action<int>> actionExpression = n => Console.WriteLine(n);
	Expression<Func<int, bool>> funcExpression1 = (n) => n < 0;
	Expression<Func<int, int, bool>> funcExpression2 = (n, m) => n - m == 0;
}

// Define other methods and classes here
