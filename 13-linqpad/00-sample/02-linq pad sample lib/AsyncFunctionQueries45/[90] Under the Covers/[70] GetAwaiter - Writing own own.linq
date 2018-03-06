<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

/* OK, let's implement our own GetAwaiter method! The simplest example might be
to write an extension method on the TimeSpan type, so we can await a time interval
rather than having to call Task.Delay: */

async Task Main()
{
	await TimeSpan.FromMilliseconds (1000);
	"Done".Dump();
}

static class Extensions
{
	public static TaskAwaiter GetAwaiter (this TimeSpan timeSpan)
	{
		// Cheat, and call Task.Delay's awaiter!
		return Task.Delay (timeSpan).GetAwaiter();
	}
}

