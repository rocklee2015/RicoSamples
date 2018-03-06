<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// There's also a generic subclass of Task called Task<TResult>. This has a Result
// property which stores a RETURN VALUE of the concurrent operation.

void Main()
{	
	Task<int> task = GetAnswerToLifeUniverseAndEverything();
	task.ContinueWith (_ => task.Result.Dump());
}

Task<int> GetAnswerToLifeUniverseAndEverything ()   // We're now returning a Task of int
{
	var tcs = new TaskCompletionSource<int>();   // Call SetResult with a int instead:
	new Timer (_ => tcs.SetResult (42)).Change (3000, -1);
	return tcs.Task;
}

// This is great, because most methods return a value of some sort!
//
// You can think of Task<int> as 'an int in the future'.