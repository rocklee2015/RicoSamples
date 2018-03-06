<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Just as named methods can be asynchronous, so can unnamed methods (or more specifically,
lambda expressions). For instance, consider the following async method: */

async Task<int> Foo()
{
	await Task.Delay (1000);
	return 123;
}

// We can await it as follows:

async void Main()
{
	int x = await Foo();
	x.Dump();
	
	// Here's the same function as Foo expressed as an asynchronous lambda expression:
	
	Func<Task<int>> fooFunc = async () =>     // The async keyword indicates an async lambda.
	{
		await Task.Delay (1000);
		return 123;
	};
	
	int y = await fooFunc();
	y.Dump();
}