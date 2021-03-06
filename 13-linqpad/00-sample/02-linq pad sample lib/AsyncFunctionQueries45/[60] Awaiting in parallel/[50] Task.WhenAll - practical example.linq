<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Here's a more practical application of Task.WhenAll. We're calculating the size of a web
page like we did earlier. But this time, we first download the HTML and then parse it with RegEx,
looking for 'src=' patterns to find links to graphics and so on. We then download those graphics
in parallel, returning the total length of all objects. All without blocking any threads! */

async Task Main()
{
	int size = await GetSiteSize (new Uri ("http://linqpad.net"));
	size.Dump ("LINQPad page size");
}

async Task<int> GetSiteSize (Uri uri)
{
	("Downloading " + uri + "...").Dump();
	string html = await new WebClient().DownloadStringTaskAsync (uri);	

	var otherFiles =
		from Match m in SrcMatch.Matches (html)
		select m.Groups[1].Value;
		
	var otherFileLengths = 
		from otherPage in otherFiles.Distinct().Dump ("(these are the other URIs)")
		select new WebClient().DownloadDataTaskAsync (new Uri (uri, otherPage));
		
	// DownloadDataTaskAsync returns a Task<byte[]>, therefore when we await WhenAll on
	// an array of them, we'll end up with an array of byte[], in other words a byte[][].
	
	byte[][] fileContents = await Task.WhenAll (otherFileLengths);
	return html.Length + fileContents.Sum (fc => fc.Length);
}

Regex SrcMatch = new Regex (@"src\s*=\s*['""](.*?\.(png|gif|png|jpg|js))['""]", RegexOptions.IgnoreCase);