<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

// Here's the asynchronous version of the previous example.
// 
// Notice that we just add the async keyword, and await Task.Delay instead of sleeping.
// Everything else stays the same - and we don't block any threads!

var ab = new ActionBlock<int> (
	async i => 
	{
		await Task.Delay (1000);
		Console.Write (i + " ");
	},
	new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 10 }
);

for (int i = 0; i < 30; i++)
	ab.Post (i);

// LINQPad has a built-in visualizer for Dataflow blocks, so you can just call Dump() on them:
ab.Dump();