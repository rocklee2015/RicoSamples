<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Another way to get just the result is to double-await:

async Task Main()
{
	// Throws a clean unrwapped NullReferenceException:
	string winningResult = await await Task.WhenAny (A(), B(), C());
	winningResult.Dump();
}

async Task<string> A() { await Task.Delay (5000); return "A"; }
async Task<string> B() { await Task.Delay (6000); throw null; return "B"; }
async Task<string> C() { await Task.Delay (7000); return "C"; }