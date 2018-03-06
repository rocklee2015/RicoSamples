<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Tasks also have an Exception property for storing the ERROR should a concurrent 
// operation fail. Calling SetException on a TaskCompletionSource signals as complete
// while populating its Exception property instead of the Result property.

void Main()
{	
	Task<int> task = GetAnswerToLifeUniverseAndEverything();
	task.ContinueWith (_ => task.Exception.InnerException.Dump());
}

Task<int> GetAnswerToLifeUniverseAndEverything()
{
	var tcs = new TaskCompletionSource<int>();
	new Timer (_ => tcs.SetException (new Exception ("You're not going to like the answer!"))).Change (2000, -1);
	return tcs.Task;
}