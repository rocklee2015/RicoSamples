<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
</Query>

/* When instantiated, the Progress<T> object saves the current sychronization context. It then posts back
to this context, so even if progress is reported on another thread, the message will forward safety on
the UI thread: */

var progressBar = new ProgressBar { Height = 30 };

progressBar.Dump ("Progress Bar");   // Display the WPF element inside LINQPad's output panel.

IProgress<int> progress = new Progress<int> (i => progressBar.Value = i);

// Let's pretend this is compute-bound. Task.Factory.StartNew is a good way to go, then.
Task.Factory.StartNew (() =>	
{
	for (int i = 0; i < 10; i++)
	{
		Thread.Sleep(100);	// Simulate long-running compute-bound activity.
		
		// We're on another thread - yet we can safely report progress to the UI thread.
		progress.Report ((i+1) * 10);
	}
});