<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// Tasks let you degrade to synchronous behavior if you choose.
// Calling Wait() on a task blocks while it completes:

Task task = Task.Delay (2000);
task.Wait();  // Blocks for two seconds - just like Thread.Sleep()!
"Done".Dump();