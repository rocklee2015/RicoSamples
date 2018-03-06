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
  static void Main()
  {
    int x = 123, y = 234;

  }
}");

CSharpCompilation compilation = CSharpCompilation.Create ("test")
  .AddReferences (
    MetadataReference.CreateFromFile (typeof(int).Assembly.Location))
  .AddSyntaxTrees (tree);

SemanticModel model = compilation.GetSemanticModel (tree);

// Look for available symbols at start of 6th line:
int index = tree.GetText().Lines[5].Start;

foreach (ISymbol symbol in model.LookupSymbols (index))
	Console.WriteLine (symbol.ToString());

model.LookupSymbols (index).Dump ("More detail", 1);