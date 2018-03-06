<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Here's the same code written without C#'s new asynchronous functions.
//
// Notice how much effort asynchronous programming is, without language support!

void Main()
{
	string[] uris =
	{
		"http://linqpad.net",                      // Main URI		
		"http://linqpad.net/downloadglyph.png",    // Hard-code the graphics URIs for simplicity.
		"http://linqpad.net/linqpadscreen.png",    // Later, we'll use RegEx to parse
		"http://linqpad.net/linqpadmed.png",       // them from the HTML 
	};
	
	Task<int> task = GetTotalLength (uris);
	task.ContinueWith (_ =>     // We must explicitly check the Exception to avoid it getting
	{                           // rethrown on the finalizer thread.
		if (task.Exception != null)
			task.Exception.InnerException.Dump();
		else
			task.Result.Dump();
	});
}

Task<int> GetTotalLength (string[] uris)
{
	return new Downloader().GetTotalLength (uris);
}

class Downloader
{
	int totalLength;
	string[] uris;

	// Create a TaskCompletionSource - this gives us a Task object that we can manually signal.
	TaskCompletionSource<int> tcs = new TaskCompletionSource<int> ();

	public Task<int> GetTotalLength (string[] uris)
	{
		"Working...".Dump();
		this.uris = uris;
		DownloadPage (0);
		return tcs.Task;  // Return the 'slave' task to the caller
	}

	public void DownloadPage (int uriIndex)
	{		
		Task<string> downloadTask = new WebClient().DownloadStringTaskAsync (new Uri (uris [uriIndex]));
		downloadTask.ContinueWith (_ =>
		{
			if (downloadTask.Exception != null)
			{
				// Signal the Task as finished - with an exception.
				tcs.SetException (downloadTask.Exception.InnerException);
				return;
			}
			totalLength += downloadTask.Result.Length;
			if (uriIndex == uris.Length - 1) 
			{
				// Signal the Task as finished - with a return value.
				tcs.SetResult (totalLength);
				return;
			}
			DownloadPage (uriIndex + 1);
		});
	}
}