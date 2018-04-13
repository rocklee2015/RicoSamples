<Query Kind="Program" />

void Main()
{
	//通过 Expression 类创建表达式树
	//lambda：num => num == 0
	ParameterExpression pExpression = Expression.Parameter(typeof(int));    //参数：num
	ConstantExpression cExpression = Expression.Constant(0);    //常量：0
	BinaryExpression bExpression = Expression.MakeBinary(ExpressionType.Equal, pExpression, cExpression);   //表达式：num == 0
	Expression<Func<int, bool>> lambda = Expression.Lambda<Func<int, bool>>(bExpression, pExpression);  //lambda 表达式：num => num == 0
}

// Define other methods and classes here
