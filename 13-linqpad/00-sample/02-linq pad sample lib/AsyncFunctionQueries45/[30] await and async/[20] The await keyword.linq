<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// C# 5 introduces the await keyword to make what we just did easier.
// Here's the same code as in the last example, re-written with the await keyword.

Task<string> task = new WebClient().DownloadStringTaskAsync (new Uri ("http://www.albahari.com/threading"));
string html = await task;
html.Dump();

// The await keyword turns everything that follows - in this case html.Dump() - into a CONTINUATION.

// Because we're awaiting a Task<string>, our await expression evaluates to a string.
// If you await a plain (non-generic) Task, you get a void.

// The continuation can comprise any number of lines of code. We can even be smack in the middle
// of a loop - or a try block!