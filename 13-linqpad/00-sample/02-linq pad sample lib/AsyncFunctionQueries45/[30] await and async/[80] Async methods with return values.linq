<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* To return a value, use the generic Task<TResult> instead of Task, where TResult is
whatever type your want your method to return.

In this example, GetTotalLength returns an integer asynchronously. */

async void Main()
{
	string[] uris =
	{
		"http://linqpad.net",
		"http://linqpad.net/downloadglyph.png",
		"http://linqpad.net/linqpadscreen.png",
		"http://linqpad.net/linqpadmed.png",
	};
	
	int result = await GetTotalLength (uris);
	result.Dump();	
}

async Task<int> GetTotalLength (string[] uris)   // This now returns a Task<int>
{
	"Working...".Dump();
	int totalLength = 0;
	foreach (string uri in uris)
	{
		string html = await new WebClient().DownloadStringTaskAsync (new Uri (uri));
		totalLength += html.Length;
	}
	return totalLength;    // We must return an integer if our method returns Task<int>
}

// The ability to easily *create* asynchronous functions is essential if you want resusable
// functionality. We can call that method above from more than one place, and even unit test it!
// If you're familiar with the EAP (Event-based Asynchronous Pattern), you'll know how much
// harder it is do the same thing, and write a GetTotalLength method that follows the EAP.