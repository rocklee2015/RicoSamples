<Query Kind="Statements">
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <NuGetReference>Microsoft.Tpl.Dataflow</NuGetReference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Threading.Tasks.Dataflow</Namespace>
</Query>

// Asynchronous lambdas are useful when you want to pass a potentially long-running delegate
// into a method. If the method accepts a Func<Task>, you can feed it an async lambda
// and get the benefits of asynchrony. A good example is with Microsoft's Dataflow API. In the
// following example, we create an ActionBlock and tell it to sleep for 1 second before writing
// out an integer. If we do this synchronously, and set the parallelism to 10, we block 10
// threads at a time!

var ab = new ActionBlock<int> (
	i => 
	{
		Thread.Sleep (1000);
		Console.Write (i + " ");
	},
	new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = 10 }
);

for (int i = 0; i < 30; i++)
	ab.Post (i);