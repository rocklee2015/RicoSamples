<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>Rx-Main</NuGetReference>
  <Namespace>System</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Reactive</Namespace>
  <Namespace>System.Reactive.Concurrency</Namespace>
  <Namespace>System.Reactive.Disposables</Namespace>
  <Namespace>System.Reactive.Joins</Namespace>
  <Namespace>System.Reactive.Linq</Namespace>
  <Namespace>System.Reactive.Subjects</Namespace>
  <Namespace>System.Reactive.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* In that last example, we ended up with an IObservable<int>, and used LINQPad's Dump()
method to subscribe to the observable and report the result.

If we want to "unwrap" the observable ourselves, the best approach it to await it: */

string[] uris =
{
	"http://linqpad.net",
	"http://linqpad.net/downloadglyph.png",
	"http://linqpad.net/linqpadscreen.png",
	"http://linqpad.net/linqpadmed.png",
};

var query =
	from uri in uris.ToObservable()
	from html in new WebClient().DownloadStringTaskAsync (uri).ToObservable()
	select html.Length;

IObservable<int> result = query.Sum();
int intResult = await result;			// "Unwrap" the observable result.
intResult.Dump();

// This is a great example on how the Reactive Framework, Tasks and asynchronous functions
// play well together.