<Query Kind="Program">
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.QualityTools.Testing.Fakes.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.TestManagement.Client.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.TeamFoundation.TestManagement.Common.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.DebuggerVisualizers.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.QualityTools.Common.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.QualityTools.ExecutionCommon.dll</Reference>
  <Reference>&lt;ProgramFilesX86&gt;\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\ReferenceAssemblies\v2.0\Microsoft.VisualStudio.QualityTools.UnitTestFramework.dll</Reference>
  <Namespace>Microsoft.VisualStudio.TestTools.UnitTesting</Namespace>
</Query>

void Main()
{
	Expression<Func<int, bool>> funcExpression = num => num == 0;

	//开始解析
	ParameterExpression pExpression = funcExpression.Parameters[0]; //lambda 表达式参数
	BinaryExpression body = (BinaryExpression)funcExpression.Body;  //lambda 表达式主体：num == 0

//	Assert.AreEqual("num", pExpression.Name);//变量名
//	Assert.AreEqual("num", body.Left.ToString());//左边变量
//	Assert.AreEqual(ExpressionType.Equal, body.NodeType);//节点类型
//	Assert.AreEqual("0", body.Right.ToString());//右边变量

	Console.WriteLine($"解析：{pExpression.Name} => {body.Left} {body.NodeType} {body.Right}");
}

// Define other methods and classes here
