<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

static Stopwatch _watch = new Stopwatch();

static void Main(string[] args)
{
	_watch.Start();

	MissHandling();


}
static async Task MissHandling()
{
	var t1 = ThrowAfter(1000, new NotSupportedException("Error 1"));
	var t2 = ThrowAfter(2000, new NotImplementedException("Error 2"));

	try
	{
		await t1;
	}
	catch (NotSupportedException ex)
	{
		PrintException(ex);
	}
}


static async Task ThrowAfter(int timeout, Exception ex)
{
	await Task.Delay(timeout);
	throw ex;
}

static void PrintException(Exception ex)
{
	Console.WriteLine("Time: {0}\n{1}\n============", _watch.Elapsed, ex);
}




// Define other methods and classes here
