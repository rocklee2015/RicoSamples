<Query Kind="Program" />

void Main()
{
    //
	Stopwatch stopwatch = new Stopwatch();
	
	stopwatch.Start();
	Thread.Sleep(1500);
	stopwatch.Stop();
	stopwatch.ElapsedMilliseconds.Dump();


	stopwatch.Start();
	Thread.Sleep(2000);
	stopwatch.Stop();
	stopwatch.ElapsedMilliseconds.Dump();

	stopwatch.Start();
	Thread.Sleep(4000);
	stopwatch.Stop();
	stopwatch.ElapsedMilliseconds.Dump();


	stopwatch.ElapsedMilliseconds.Dump();
	stopwatch.Elapsed.TotalMilliseconds.Dump();
}

// Define other methods and classes here