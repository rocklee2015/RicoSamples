<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// But what if we want to run those three methods in parallel? The simplest
// solution is first to start all of the tasks running, then await them:

async Task Main()
{
	Task<string> aTask = A();
	Task<string> bTask = B();
	Task<string> cTask = C();
	
	string a = await aTask, b = await bTask, c = await cTask;
		
	(a + b + c).Dump();		// One one second later!
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }