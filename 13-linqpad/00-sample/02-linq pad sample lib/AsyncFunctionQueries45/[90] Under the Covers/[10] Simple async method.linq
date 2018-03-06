<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* To see what the compiler does with asynchronous functions, consider the following 
program. How might it translate the Main() method? */

async void Main()
{
	string s1 = await A();
	string s2 = await B();
	string s3 = await C();

	Console.WriteLine (s1 + s2 + s3);
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }