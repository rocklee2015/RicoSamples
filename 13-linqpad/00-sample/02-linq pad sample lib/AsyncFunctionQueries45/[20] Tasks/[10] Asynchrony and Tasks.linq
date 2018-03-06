<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* So far, we've been using simple Action delegates to implement continuations. This is OK,
but there's no way to communicate an exception back to the caller if something goes wrong.
And it doesn't give us any nice way to abstract asynchronous operations in general.

A better solution is have the asynchronous method return a Task. The Task class was introduced
in Framework 4.0 to represent a concurrent operation. A Task is essentially a signalling
construct - signalling when a concurrent operation is complete. The AsyncCTPLibrary.dll that ships
with the async CTP includes a method called Task.Delay(int dueTime) which returns a task that
gets signalled in dueTime milliseconds. */

Task task = Task.Delay (2000);

// Call ContinueWith(...) to tell a task to do something when it's finished (signalled):

task.ContinueWith (_ => "Done".Dump());

// Task.Delay is the asynchronous equivalent of Thread.Sleep.