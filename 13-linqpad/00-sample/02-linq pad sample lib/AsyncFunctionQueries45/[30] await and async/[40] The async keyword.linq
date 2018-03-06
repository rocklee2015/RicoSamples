<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* The compiler demands that any method that uses the await keyword must be annotated
with the 'async' keyword. So if we set the language to 'C# Program' and write a complete
method, we must add the 'async' modifier to the method declaration: */

async void Main()
{
	"Working...".Dump();
	string[] uris =
	{
		"http://linqpad.net",
		"http://linqpad.net/downloadglyph.png",
		"http://linqpad.net/linqpadscreen.png",
		"http://linqpad.net/linqpadmed.png",
	};
	int totalLength = 0;
	foreach (string uri in uris)
	{
		string html = await new WebClient().DownloadStringTaskAsync (new Uri (uri));
		totalLength += html.Length;
	}
	totalLength.Dump();
}