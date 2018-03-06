<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
</Query>

/* Writing multithreaded code is fun. But debugging it is not!

Asynchronous methods allow the implementor of the method to take on the concurrency burden
so that callers can largely (or entirely) forget about thread safety issues. Moreover, fine-grained
asynchrony reduces or even ELIMINATES the need for SHARED STATE, thereby eliminating the need for
locking and signalling.

With WPF, Windows Forms, and ASP.NET applications, you automatically get a *synchronization context*.
(We can make LINQPad do the same thing by calling Util.CreateSynchronizationContext()).

A synchronization context allows asynchronous methods to perform callbacks ON THE SAME THREAD. This
means that consumers of asynchronous methods can enjoy concurrency while remaining SINGLE THREADED: */

void WaitForTwoSecondsAsync (Action continuation)
{
	var syncContext = AsyncOperationManager.SynchronizationContext;
	new Timer (_ => syncContext.Post (o => continuation(), _)).Change (2000, -1);
}

void Main()
{
	Util.CreateSynchronizationContext();
	("Waiting on thread " + Thread.CurrentThread.ManagedThreadId).Dump();
	for (int i = 0; i < 10; i++)
		WaitForTwoSecondsAsync (() => ("Done on thread " + Thread.CurrentThread.ManagedThreadId).Dump());
}