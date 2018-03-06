<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// The await keyword is really useful when you want to run something in a loop. For instance:

string[] uris =
{
	"http://linqpad.net",
	"http://linqpad.net/downloadglyph.png",
	"http://linqpad.net/linqpadscreen.png",
	"http://linqpad.net/linqpadmed.png",
};

// Try doing the following without the await keyword!

int totalLength = 0;
foreach (string uri in uris)
{
	string html = await (new WebClient().DownloadStringTaskAsync (new Uri (uri)));
	totalLength += html.Length;
}
totalLength.Dump();

// The continuation is not just 'totalLength += html.Length', but the rest of the loop! (And that final
// call to 'totalLength.Dump()' at the end.)

// Logically, execution EXITS THE METHOD and RETURNS TO THE CALLER upon reaching the await statement. Rather
// like a 'yield return' (in fact, the compiler uses the same state-machine engine to rewrite asynchronous
// functions as it does iterators).
//
// When the task completes, the continuation kicks off and execution jumps back into the middle of the 
// loop - right where it left off!