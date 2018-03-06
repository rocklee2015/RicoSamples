<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* The first reason for GetAwaiter existing is to allow things other than Tasks to be awaitable.
The problem with ContinueWith is that it accepts an Action<Task> or Func<...,Task> parameter,
making it messy, say, for an IObservable<T> to offer its own version of that method:

   public Task ContinueWith (Action<Task> continuationAction)

The GetAwaiter protocol is easier for types other than Tasks to follow. Calling that method
returns an "awaiter" type which must implement System.Runtime.CompilerServices.INotifyCompletion
interface, which defines a single method as follows:

  void OnCompleted (Action continuation);

An awaiter object should also expose the following two members (not part of an interface):

  - bool IsCompleted { get; }
  - T GetResult()   // where T is the return value of the operation, if it has one
  
As long as a type follows this protocol, we can call await on it!

The second reason for GetAwaiter existing is that the default semantics for ContinueWith()
methods are designed more for parallel programming than asynchronous programming. The 
semantics for GetAwaiter differ from ContinueWith in the following ways:

1. It automatically picks up the current synchronization context, if active, and posts to it.
2. It avoids unnecessary hops to the thread-pool or synchronization context.
3. If the async operation faults, it throws the real exception, rather an wrapping it in an
   AggregateException.  */