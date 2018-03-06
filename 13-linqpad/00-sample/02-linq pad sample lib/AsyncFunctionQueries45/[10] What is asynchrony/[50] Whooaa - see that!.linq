<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* If you got an OutOfMemoryException in that last example, it's because each thread consumes ~1MB
of memory, and you tried to create 10,000 threads! (If you didn't get an error, I want your computer!)

Now, let's go back to our asynchronous version, and call that 10,000 times: */

void WaitForTwoSecondsAsync (Action continuation)		// Asynchronous NON-BLOCKING method
{
	new Timer (_ => continuation()).Change (2000, -1);
}

void Main()
{
	"Waiting...".Dump();
	for (int i = 0; i < 10000; i++)
		WaitForTwoSecondsAsync (() => "Done".Dump());
}

// No problem!