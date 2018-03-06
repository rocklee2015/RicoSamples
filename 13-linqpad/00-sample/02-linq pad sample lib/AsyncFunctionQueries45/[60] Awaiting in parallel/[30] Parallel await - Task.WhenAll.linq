<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Another solution is to call Task.WhenAll. This accepts a params array of tasks, and
// returns a task that's signalled when all the others are complete:

async Task Main()
{
	Task<string> aTask = A();
	Task<string> bTask = B();
	Task<string> cTask = C();
	
	// We get all the results back in an array:
	string[] results = await Task.WhenAll (aTask, bTask, cTask);
		
	results.Dump();		// One one second later!
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }