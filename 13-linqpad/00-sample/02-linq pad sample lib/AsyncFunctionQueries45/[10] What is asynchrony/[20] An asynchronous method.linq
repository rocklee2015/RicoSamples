<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* Here's the asynchronous equivalent, using plain C# code. When you run it, notice that the
script will complete immediately: LINQPad will say 'Query successful' right away and then two
seconds later, the result will be printed out: */

void WaitForTwoSecondsAsync (Action callback)		// Asynchronous NON-BLOCKING method
{
	new Timer (_ => callback()).Change (2000, -1);
}

void Main()
{
	"Waiting...".Dump();
	WaitForTwoSecondsAsync (() => "Done".Dump());
}