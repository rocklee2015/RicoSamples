<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* The AsyncCTPLibrary.dll that ships with the async CTP also includes hundreds of extension
methods that offer Task-based asynchronous versions of long-running .NET Framework methods.
(You can consume this library right now - and even ship it to clients - whether or not you
want to fully install the CTP and patch the compiler with C# 5's new async keywords that
we'll introduce next.)

For example, we can now download a web page as follows: */

// Kick off a download operation in the background:
Task<string> task = new WebClient().DownloadStringTaskAsync (new Uri ("http://www.albahari.com/threading"));

// Call the .ContinueWith method to tell a task to do something when it's finished.
task.ContinueWith (_ =>
{
	if (task.Exception != null)
		task.Exception.InnerException.Dump();
	else
	{
		string html = task.Result;
		html.Dump();
	}
});

// This new task-based pattern is called the TAP (Task-based Asynchronous Pattern). If you're
// familiar with the EAP (Event-based Asynchrnous Pattern) or the APM (Asynchronous Programming
// Model aka IAsyncResult pattern), you'll be pleased to know that the TAP deprecates both!

// Methods that follow the TAP are also usually overloaded to accept CancellationTokens
// and IProgress<> objects. More on this later.