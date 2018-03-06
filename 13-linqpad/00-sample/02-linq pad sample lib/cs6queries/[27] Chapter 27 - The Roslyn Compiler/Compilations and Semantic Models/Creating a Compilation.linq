<Query Kind="Statements">
  <NuGetReference>Microsoft.CodeAnalysis.CSharp</NuGetReference>
  <Namespace>Microsoft.CodeAnalysis</Namespace>
  <Namespace>Microsoft.CodeAnalysis.CSharp</Namespace>
  <Namespace>Microsoft.CodeAnalysis.CSharp.Syntax</Namespace>
  <Namespace>Microsoft.CodeAnalysis.Text</Namespace>
</Query>

var compilation = CSharpCompilation.Create ("test");

compilation = compilation.WithOptions (
  new CSharpCompilationOptions (OutputKind.ConsoleApplication));

var tree = CSharpSyntaxTree.ParseText (@"class Program 
{
  static void Main() => System.Console.WriteLine (""Hello"");
}");

compilation = compilation.AddSyntaxTrees (tree);

compilation = compilation.AddReferences (MetadataReference.CreateFromFile (typeof(int).Assembly.Location));

// Or, in one step:

compilation = CSharpCompilation
	.Create ("test")
	.WithOptions (new CSharpCompilationOptions (OutputKind.ConsoleApplication))
	.AddSyntaxTrees (tree)
	.AddReferences (MetadataReference.CreateFromFile (typeof(int).Assembly.Location));
	
compilation.GetDiagnostics().Dump ("Errors and warnings");