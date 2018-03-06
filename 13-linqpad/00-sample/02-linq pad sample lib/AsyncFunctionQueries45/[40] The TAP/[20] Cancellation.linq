<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Methods following the Task-based Asynchronous Pattern (TAP) should be overloaded to accept
// a CancellationToken if they support cancellation. To create a CancellationToken, instantiate
// a CancellationTokenSource. We saw an example in the previous section 'Simple UI with cancellation'.
//
// The AsyncCtpLibrary.dll includes a convenient extension method called CancelAfter. This is
// great for testing scenarios:

var cancelSource = new CancellationTokenSource();
cancelSource.CancelAfter (1000);	// Tell it to cancel automatically after one second

"Waiting 3000 milliseconds...".Dump();
try
{
	await Task.Delay (3000, cancelSource.Token);
}
catch (OperationCanceledException) 
{
	"Our await was cancelled!".Dump();
}
"Done!".Dump();
