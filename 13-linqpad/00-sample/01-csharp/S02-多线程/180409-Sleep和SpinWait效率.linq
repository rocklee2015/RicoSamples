<Query Kind="Program" />

void Main()
{
//
	NoSleep();
	ThreadSleepInThread();
	SpinWaitInThread();
	
}
private static int _count = 1000;
private static int _timeout_ms = 10;



private static void NoSleep()
{
	Thread thread = new Thread(() =>
	{
		var sw = Stopwatch.StartNew();
		for (int i = 0; i < _count; i++)
		{

		}
		Console.WriteLine("No Sleep Consume Time:{0}", sw.Elapsed.ToString());
	});
	thread.IsBackground = true;
	thread.Start();
}

private static void ThreadSleepInThread()
{
	Thread thread = new Thread(() =>
	{
		var sw = Stopwatch.StartNew();
		for (int i = 0; i < _count; i++)
		{
			Thread.Sleep(_timeout_ms);
		}
		Console.WriteLine("Thread Sleep Consume Time:{0}", sw.Elapsed.ToString());
	});
	thread.IsBackground = true;
	thread.Start();
}

private static void SpinWaitInThread()
{
	Thread thread = new Thread(() =>
	{
		var sw = Stopwatch.StartNew();
		for (int i = 0; i < _count; i++)
		{
			SpinWait.SpinUntil(() => true, _timeout_ms);
		}
		Console.WriteLine("SpinWait Consume Time:{0}", sw.Elapsed.ToString());
	});
	thread.IsBackground = true;
	thread.Start();
}
// Define other methods and classes here
