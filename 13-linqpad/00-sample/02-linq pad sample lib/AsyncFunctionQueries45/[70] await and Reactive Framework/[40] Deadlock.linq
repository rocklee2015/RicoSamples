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

/* Another way to "unwrap" the final Observable<int> is to call .Single() on it. However,
this approach is inferior because it's *synchronous* (it blocks rather than awaiting).

Synchronously waiting an operation that itself awaits it dangerous if a synchronization context
is active (in other words, if you're writing a WPF, WinForms or ASP.NET app) - because you can
end up deadlocking the synchronization context! We can demonstrate this by creating a UI - or
more easily by calling LINQPad's Util.CreateSynchronizationContext(). The latter creates a
synchronization context without needing a UI. It also has an inbuilt DEADLOCK monitor: */

#LINQPad /optimize-    // Disable C# compiler optimizations for more precise error reporting
                       // (you can also do this in Edit | Preferences, Query)

Util.CreateSynchronizationContext();    // Tell LINQPad to create a synchronization context
                                        // with an inbuilt deadlock monitor:
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
int intResult = result.Single();        // BLOCKS, deadlocking sync context!
intResult.Dump();