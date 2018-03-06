<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Rather than awaiting a second time, we could access the Result property of the winning task.
// This won't block because the task will already have finished. However, it's still not a
// good idea, because if the task faults, it throws an awkward AggregateException instead of
// throwing the naked exception (this is a feature of tasks, not WhenAny):

async Task Main()
{
	Task<string> winningTask = await Task.WhenAny (A(), B(), C());
	
	// Throws an awkward AggregateException instead of a clean NullReferenceException
	string result = winningTask.Result;
	
	result.Dump();   // 2 seconds later
}

async Task<string> A() { await Task.Delay (5000); return "A"; }
async Task<string> B() { await Task.Delay (2000); throw null; return "B"; }
async Task<string> C() { await Task.Delay (7000); return "C"; }