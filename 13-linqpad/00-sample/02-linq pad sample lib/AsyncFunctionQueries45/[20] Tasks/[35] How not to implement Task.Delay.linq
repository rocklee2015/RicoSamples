<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Instead of using a TaskCompletionSource, you can get (seemingly) the same result by
calling Task.Factory.StartNew. This method runs a delegate on a pooled thread,
which is fine for compute-bound work. However, it's not great for I/O-bound work
because you tie up a thread, blocking for the duration of the operation! */

void Main()
{	
	Task task = Delay (2000);		  		// Try calling this 10,000 times...
	task.ContinueWith (_ => "Done".Dump());
}

Task Delay (int milliseconds)       // Asynchronous non-blocking wrapper....
{
	return Task.Factory.StartNew (() =>
	{
		Thread.Sleep (2000);        // ... around a BLOCKING method!
	});
}

// This approach is correct for COMPUTE-BOUND operations.