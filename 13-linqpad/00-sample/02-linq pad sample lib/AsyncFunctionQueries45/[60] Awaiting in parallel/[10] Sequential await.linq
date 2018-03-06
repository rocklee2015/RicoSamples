<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Suppose we have three asynchronous methods and want to await them each in turn.
// We simply await one after another:

async Task Main()
{
	string a = await A();
	string b = await B();
	string c = await C();
	
	(a + b + c).Dump();		// Three seconds later!
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }