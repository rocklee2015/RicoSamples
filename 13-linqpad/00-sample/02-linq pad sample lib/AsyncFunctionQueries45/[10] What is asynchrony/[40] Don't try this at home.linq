<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* The first reason is SCALABILITY. Let's take that code we just wrote - the code that
calls a SYNCHRONOUS BLOCKING method on a worker thread, and call it 10,000 times.

See what happens! */

void WaitForTwoSeconds()		// Synchronous BLOCKING method
{
	Thread.Sleep (2000);
}
	
void Main()
{
	"Waiting...".Dump();
	
	// 10000 is not a big number for a computer. We should be able to write out the
	// word "Done!" 10000 times in a row without error, right???
	
	for (int i = 0; i < 10000; i++)
		new Thread (() => { WaitForTwoSeconds(); "Done!".Dump(); }).Start();
}