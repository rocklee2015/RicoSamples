<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	// .NET中的双链表的应用
	LinkedListInDotNetTest();
}
#region Method03.系统自带双链表的测试
static void LinkedListInDotNetTest()
{
	LinkedList<int> linkedList = new LinkedList<int>();

	LinkedListNode<int> firstNode = new LinkedListNode<int>(0);
	linkedList.AddFirst(firstNode);

	var secondNode = linkedList.AddAfter(firstNode, 1);
	var thirdNode = linkedList.AddAfter(secondNode, 2);
	var fourthNode = linkedList.AddAfter(thirdNode, 3);
	var fifthNode = linkedList.AddAfter(fourthNode, 4);
}
#endregion
// Define other methods and classes here
