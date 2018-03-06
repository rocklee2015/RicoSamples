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
  static void Main() => System.Console.WriteLine (123);
}");

var compilation = CSharpCompilation.Create ("test")
  .AddReferences (
     MetadataReference.CreateFromFile (typeof(int).Assembly.Location))
  .AddSyntaxTrees (tree);

SemanticModel model = compilation.GetSemanticModel (tree);

var writeLineNode = tree.GetRoot().DescendantTokens().Single (
   t => t.Text == "WriteLine").Parent;

SymbolInfo symbolInfo = model.GetSymbolInfo (writeLineNode);
Console.WriteLine (symbolInfo.Symbol.ToString());  // System.Console.WriteLine(int)

symbolInfo.Symbol.Dump ("In more detail", 2);


