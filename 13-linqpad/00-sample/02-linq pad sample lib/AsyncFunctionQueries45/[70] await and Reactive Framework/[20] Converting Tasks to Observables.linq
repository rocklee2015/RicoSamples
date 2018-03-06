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

/* The ToObservable() extension method (in System.Reactive.Threading.Tasks namespace) converts
a task to an observable. This is great for bring asynchronous methods into the world of Rx.

In the following example, we write a reactive LINQ query that downloads a sequence of URIs
and then total up their length using the .Sum() operator. */

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
result.Dump();