<Query Kind="Statements">
  <NuGetReference>Microsoft.CodeAnalysis.CSharp</NuGetReference>
  <Namespace>Microsoft.CodeAnalysis</Namespace>
  <Namespace>Microsoft.CodeAnalysis.CSharp</Namespace>
  <Namespace>Microsoft.CodeAnalysis.CSharp.Syntax</Namespace>
  <Namespace>Microsoft.CodeAnalysis.Text</Namespace>
  <Namespace>Microsoft.CodeAnalysis.Emit</Namespace>
</Query>

var tree = CSharpSyntaxTree.ParseText (@"class Program 
{
  static void Main() => System.Console.WriteLine (""Hello"");
}");

var compilation = CSharpCompilation
	.Create ("test")
	.WithOptions (new CSharpCompilationOptions (OutputKind.ConsoleApplication))
	.AddSyntaxTrees (tree)
	.AddReferences (MetadataReference.CreateFromFile (typeof(int).Assembly.Location));

string outputPath = Path.Combine (Path.GetTempPath(), "test.exe");
EmitResult result = compilation.Emit (outputPath);

Console.WriteLine (result.Success);

// Run the executable
Util.Cmd (outputPath);
