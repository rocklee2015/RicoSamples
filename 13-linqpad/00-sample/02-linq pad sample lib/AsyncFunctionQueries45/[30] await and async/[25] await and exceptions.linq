<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// If the task completes with an exception, the exception gets re-thrown onto whoever awaits it.
// So, we don't need to fiddle around checking the Exception property of the task. In fact, it's
// easiest to forget about the task and await the asynchronous method directly:

string html = await (new WebClient().DownloadStringTaskAsync (new Uri ("http://albahari.com/InvalidUrl")));
html.Dump();

// (this should throw a WebException onto us - if you want, you can catch it explicitly in a catch block).

// Our continuation is still fairly boring - just one line of code! Let's give it something more
// interesting...