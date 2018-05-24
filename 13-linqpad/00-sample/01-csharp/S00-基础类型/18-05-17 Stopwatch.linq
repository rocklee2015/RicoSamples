<Query Kind="Program" />

void Main()
{
	Stopwatch stopwatch = new Stopwatch();
	stopwatch.Start();
	
	Thread.Sleep(200);
	var duration=stopwatch.ElapsedMilliseconds.Dump();

	Thread.Sleep(200);
	duration=stopwatch.ElapsedMilliseconds-duration;
	duration.Dump();
	stopwatch.ElapsedMilliseconds.Dump();
	
	stopwatch.Stop();
	stopwatch.ElapsedMilliseconds.Dump();

	Thread.Sleep(200);
	stopwatch.ElapsedMilliseconds.Dump();
}

// Define other methods and classes here
