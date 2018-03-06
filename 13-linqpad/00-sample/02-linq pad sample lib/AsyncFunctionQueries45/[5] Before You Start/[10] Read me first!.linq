<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

/* Welcome to the Asynchronous Functions Tutorial. All samples are editable, so you can play
to your heart's delight!

This sample library requires .NET Framework 4.5. If you have installed Visual Studio 2012
or Windows 8, you're all set to go!

You can test the installation by hitting F5 to run the following code: */

"Thinking...".Dump();

await Task.Delay (2000);

"Success!".Dump();