<Query Kind="Program" />

void Main()
{
	for (int i = 1; i <= 6; i++)
	{
		string threadName = "Thread " + i;
		int secondsToWait = 2 + 2 * i;
		var t = new Thread(() => AccessDatabase(threadName, secondsToWait));
		t.Start();
	}
}
static SemaphoreSlim _semaphore = new SemaphoreSlim(4);
static void AccessDatabase(string name, int seconds)
{
	Console.WriteLine("{0} waits to access a database", name);
	_semaphore.Wait();
	//granted 被准许
	Console.WriteLine("{0} was granted an access to a database", name);
	Thread.Sleep(TimeSpan.FromSeconds(seconds));
	Console.WriteLine("{0} is completed", name);
	_semaphore.Release();

}
// Define other methods and classes here