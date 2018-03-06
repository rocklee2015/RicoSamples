<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Now let's suppose we write an async method that returns a Task<TResult> such as
the ABC method in the following example. How might the compiler deal with that?  */

async void Main()
{
	string result = await ABC();
	Console.WriteLine (result);
}

async Task<string> ABC()
{
	string s1 = await A();
	string s2 = await B();
	string s3 = await C();
		
	return s1 + s2 + s3;
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }