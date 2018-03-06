<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Instead of returning void, a method that you flag with async can return a Task. Take a look
at the GetTotalLength method - we've changed 'void' to 'Task' and this allows us to await it
in the Main method. Notice that we don't create the Task ourselves - the compiler creates one
for us (using a TaskCompletionSource) and signals it when the method completes (or faults). */

async void Main()
{
	string[] uris =
	{
		"http://linqpad.net",
		"http://linqpad.net/downloadglyph.png",
		"http://linqpad.net/linqpadscreen.png",
		"http://linqpad.net/linqpadmed.png",
	};
	
	await GetTotalLength (uris);   // Try deleting the 'await' keyword - notice the difference when run.	
	"Done!".Dump();	
}

async Task GetTotalLength (string[] uris)   // Notice that this now returns a Task.
{
	"Working...".Dump();
	int totalLength = 0;
	foreach (string uri in uris)
	{
		string html = await new WebClient().DownloadStringTaskAsync (new Uri (uri));
		totalLength += html.Length;
	}
	totalLength.Dump();
}