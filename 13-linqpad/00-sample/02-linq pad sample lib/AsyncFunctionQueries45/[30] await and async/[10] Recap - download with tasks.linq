<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// We just saw how to download a web page asynchronously using the new extension method,
// and write out the result without blocking or using threads. Here it is again:

Task<string> task = new WebClient().DownloadStringTaskAsync (new Uri ("http://www.albahari.com/threading"));
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