<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* This is identical to the previous example, except that the Main method itself now
returns a Task. This tells LINQPad to display 'Querying continuing asynchronously' in
the statusbar until done.
*/

async Task Main()
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