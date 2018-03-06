<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// If any of the non-winning tasks throw, their exceptions will be 'lost'. This is not typically
// a problem in the scenarios for which WhenAny is useful; however if it's an issue you should
// exception-handle the code within the async methods that you're calling.

async Task Main()
{
	string winningResult = await await Task.WhenAny (A(), B(), C());
	winningResult.Dump();
}

async Task<string> A() { await Task.Delay (5000); throw null; return "A"; }  // Exception lost
async Task<string> B() { await Task.Delay (2000); return "B"; }
async Task<string> C() { await Task.Delay (7000); throw null; return "C"; }  // Exception lost