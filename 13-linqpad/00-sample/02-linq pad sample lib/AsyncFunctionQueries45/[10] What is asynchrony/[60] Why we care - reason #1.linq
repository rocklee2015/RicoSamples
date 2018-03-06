<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* With asynchronous methods, the CALLEE manages the concurrency, rather than the CALLER.

This is advantageous because the callee is typically in a BETTER POSITION to manage concurrency
and can be much more efficient about how it's done.

For instance, as we just saw, the callee can uses constructs such as timers to coalecse thousands of
concurrent asynchronous operations onto a FEW threads.

So, the first advantage of asynchronous methods is EFFICIENCY and SCALABILITY.
	
This is particularly relevant on servers - where there can be a lot of concurrent I/O-bound activity
(I/O-bound = anything that takes time without making the CPU hot). With I/O-bound activity, it's
possible with the async pattern to handle many concurrent operations without using lots of threads.

Even if you don't have thousands of concurrent operations, the asynchronous approach is advantageous
because it keeps I/O-bound operations OUT OF THE CLR THREAD POOL. The thread pool is a finely tuned
instrument, designed to allow maximum CPU utilization while avoiding oversubscription (this is
especially relevant in parallel programmming). Blocking on pooled threads reduces its effectiveness
in detecting oversubscription and makes its job that much harder. */