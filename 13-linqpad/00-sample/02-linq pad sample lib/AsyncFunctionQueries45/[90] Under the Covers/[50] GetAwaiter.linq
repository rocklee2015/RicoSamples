<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* The compiler translations we gave in previous example were simplifications of
what the actually does - it's been written to cope with more complicated scenarios,
and this makes the translations messier.

There's also one important thing it does differently to what we showed: rather than
calling .ContinueWith() on the tasks, it calls a method called GetAwaiter().

GetAwaiter is an extension method defined in AsyncCtpLibrary.dll and provides an
alternative means of attaching continuations to a task: */

// Create a simple task
var task = Task.Delay (1000);

// Call GetAwaiter() on the task:
var awaiter = task.GetAwaiter();

awaiter.IsCompleted.Dump ("IsCompleted");

// Attach a continuation:
awaiter.OnCompleted (() => "I've finished!".Dump());

// So, why did they come up with GetAwaiter?
// Why doesn't the compiler just call ContinueWith?