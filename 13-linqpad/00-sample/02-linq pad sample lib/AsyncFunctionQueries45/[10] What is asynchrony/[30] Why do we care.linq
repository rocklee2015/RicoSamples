<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* So, what's the advantage of the asynchronous approach? 
	
			** Why go to this extra trouble? **

Why not go back to the simple SYNCHRONOUS approach and just spin up a thread
if we want concurrency?
	
Like this: */

void WaitForTwoSeconds()		// Synchronous BLOCKING method
{
	Thread.Sleep (2000);
}
	
void Main()
{
	"Waiting...".Dump();
	new Thread (() => { WaitForTwoSeconds(); "Done!".Dump(); }).Start();
}

// We get the same result!!