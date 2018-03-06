<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// Task.WhenAny returns a task that completes when ANY of the tasks passed to it complete.
// This is useful in redundancy, for example, fetching data from two remote sources and
// using the result of whichever one returns first.
//
// In the following example, A(), B(), and C() all delay for different lengths of time.

async Task Main()
{
	Task<string> winningTask = await Task.WhenAny (A(), B(), C());
	
	// The return value is actually the task that won, so we need to await again to get the result:
	string result = await winningTask;
	
	result.Dump();   // 2 seconds later
}

async Task<string> A() { await Task.Delay (5000); return "A"; }   // Delays 5 seconds
async Task<string> B() { await Task.Delay (2000); return "B"; }   // Delays 2 seconds
async Task<string> C() { await Task.Delay (7000); return "C"; }   // Delays 7 seconds