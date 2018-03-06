<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* A callback that gets executed onced upon completion of an operation is more
accurately called a CONTINUATION. Let's be more accurate and update our sample :)  */

void WaitForTwoSecondsAsync (Action continuation)	// Asynchronous NON-BLOCKING method
{
	new Timer (_ => continuation()).Change (2000, -1);
}

void Main()
{
	"Waiting...".Dump();
	WaitForTwoSecondsAsync (() => "Done".Dump());
}