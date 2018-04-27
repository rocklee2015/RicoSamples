<Query Kind="Program" />

private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
private static AutoResetEvent _mainEvent = new AutoResetEvent(false);
void Main()
{
	var t = new Thread(() => Process(10));
	t.Start();

	Console.WriteLine("等待另外一个线程完成工作，Waiting for another thread to complete work");
	_workerEvent.WaitOne();
	Console.WriteLine("First operation is completed!");
	Console.WriteLine("Performing an operation on a main thread");
	Thread.Sleep(TimeSpan.FromSeconds(5));
	_mainEvent.Set();
	Console.WriteLine("Now running the second operation on a second thread");
	_workerEvent.WaitOne();
	Console.WriteLine("Second operation is completed!");
}
static void Process(int seconds)
{
	Console.WriteLine("Starting a long running work...");
	Thread.Sleep(TimeSpan.FromSeconds(seconds));
	Console.WriteLine("Work is done!");
	_workerEvent.Set();
	Console.WriteLine("Waiting for a main thread to complete its work");
	_mainEvent.WaitOne();
	Console.WriteLine("Starting second operation...");
	Thread.Sleep(TimeSpan.FromSeconds(seconds));
	Console.WriteLine("Work is done!");
	_workerEvent.Set();
}
// Define other methods and classes here
