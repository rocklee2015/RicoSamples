<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* Methods adhering to the TAP should also be overloaded to accept an IProgress<T> object if
if they want to support progress reporting. IProgress<T> is new interface in AsyncCtpLibrary.dll
and is rather like a cut-down version of IObserver<T>. It defines just one method:

public interface IProgress <in T>
{
	void Report (T value);
}

(If you're familiar with Reactive Framework, Report is equivalent to IObserver.OnNext).

AsyncCtpLibrary.dll also defines the class Progress<T> which is simple implementation of IProgress<T>.
It has a ProgressChanged event that you can handle, but the simplest way to use it is to pass an Action
delegate into its constructor, saying what you want to do whenever progress changes. For example:  */

async Task Main()
{
	var progress = new Progress<int> (i => ("We're " + i + "% complete").Dump());
	await FooAsync (CancellationToken.None, progress);
	"We're done!".Dump();
}

// Our FooAsync method supports the full TAP!
async Task FooAsync (CancellationToken cancelToken, IProgress<int> progress)
{
	for (int i = 0; i < 10; i++)
	{
		await Task.Delay (100, cancelToken);
		progress.Report ((i+1) * 10);
	}
}

// Notice how easy it is to fully implement the TAP. If you've used the EAP or APM in the past, you'll
// appreciate how much of a saving this is!