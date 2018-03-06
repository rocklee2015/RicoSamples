<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* You can write Task-based asynchronous methods by utilizing a TaskCompletionSource.
A TaskCompletionSource gives you a 'slave' Task that you can manually signal.
Calling SetResult() signals the task as complete, and any continuations kick off. */

void Main()
{	
	Task task = Delay (2000);
	task.ContinueWith (_ => "Done".Dump());
}

Task Delay (int milliseconds)		// Asynchronous NON-BLOCKING method
{
	var tcs = new TaskCompletionSource<object>();
	new Timer (_ => tcs.SetResult (null)).Change (milliseconds, -1);
	return tcs.Task;
}