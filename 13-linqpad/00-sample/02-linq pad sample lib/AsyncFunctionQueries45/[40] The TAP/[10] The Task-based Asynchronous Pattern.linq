<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Methods following the Task-based Asynchronous Pattern (TAP) return a Task<TResult>.
// Their names also usually end in the word 'Async' or 'TaskAsync'.
//
// We wrote and used such methods in the previous section:

Task<string> downloadTask = new WebClient().DownloadStringTaskAsync (new Uri ("http://microsoft.com"));
string html = await downloadTask;
html.Length.Dump ("Web page length");

// Task.Delay is the asynchronous version of Thread.Sleep. When you await Task.Delay, you
// return to the caller and say 'Get back to me in x milliseconds'.

"Waiting 3000 milliseconds...".Dump();
await Task.Delay (3000);
"Done!".Dump();