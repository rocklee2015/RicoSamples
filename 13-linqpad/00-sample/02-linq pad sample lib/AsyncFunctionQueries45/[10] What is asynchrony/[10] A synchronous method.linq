<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* The term 'asynchronous' loosely just means 'concurrent'.

However, the term 'asynchronous method' or 'asynchronous call' has a specific meaning.

It means a *non-blocking method* - one that returns immediately to the caller and continues
doing its stuff in the background. An asynchronous method typically executes a CALLBACK when
its job is done.

To illustrate the difference, let's first look at a SYNCHRONOUS method: */

void WaitForTwoSeconds()		// Synchronous BLOCKING method
{
	Thread.Sleep (2000);
}
	
void Main()
{
	"Waiting...".Dump();
	WaitForTwoSeconds();		// This method BLOCKS while it's working
	"Done!".Dump();
}