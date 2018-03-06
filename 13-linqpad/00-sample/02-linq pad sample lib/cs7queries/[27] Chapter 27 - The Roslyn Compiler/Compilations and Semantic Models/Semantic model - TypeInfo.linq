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
    var now = System.DateTime.Now;
    System.Console.WriteLine (now - now);
  }
}");

var compilation = CSharpCompilation.Create ("test")
  .AddReferences (
     MetadataReference.CreateFromFile (typeof(int).Assembly.Location))
  .AddSyntaxTrees (tree);

SemanticModel model = compilation.GetSemanticModel (tree);

SyntaxNode binaryExpr = tree.GetRoot().DescendantTokens().Single (
  t => t.Text == "-").Parent;

var typeInfo = model.GetTypeInfo (binaryExpr);

Console.WriteLine (typeInfo.Type.ToString());             // System.TimeSpan
Console.WriteLine (typeInfo.ConvertedType.ToString());    // object
