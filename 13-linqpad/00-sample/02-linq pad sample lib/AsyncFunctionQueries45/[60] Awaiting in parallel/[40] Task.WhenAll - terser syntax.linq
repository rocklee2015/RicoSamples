<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// If we eliminate the intermediate variables from that last example, it's less verbose:

async Task Main()
{
	string[] results = await Task.WhenAll (A(), B(), C());
		
	results.Dump();		// One one second later!
}

async Task<string> A() { await Task.Delay (1000); return "A"; }
async Task<string> B() { await Task.Delay (1000); return "B"; }
async Task<string> C() { await Task.Delay (1000); return "C"; }