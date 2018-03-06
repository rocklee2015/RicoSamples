<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	// 自己模拟的双链表的实现
	MyDoubleLinkedListTest();
}
#region Method02.自己模拟的双链表的测试
static void MyDoubleLinkedListTest()
{
	MyDoubleLinkedList<int> linkedList = new MyDoubleLinkedList<int>();
	// Test1:顺序插入4个节点
	linkedList.AddAfter(0);
	linkedList.AddAfter(1);
	linkedList.AddAfter(2);
	linkedList.AddAfter(3);

	Console.WriteLine("The nodes in the DoubleLinkedList:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	Console.WriteLine("----------------------------");
	// Test2.1:在尾节点之前插入2个节点
	linkedList.AddBefore(10);
	linkedList.AddBefore(20);
	Console.WriteLine("After add 10 and 20:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	// Test2.2:在索引为2(即第3个节点)的位置之后插入单个节点
	linkedList.InsertAfter(2, 50);
	Console.WriteLine("After add 50:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	// Test2.3:在索引为2(即第3个节点)的位置之前插入单个节点
	linkedList.InsertBefore(2, 40);
	Console.WriteLine("After add 40:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	Console.WriteLine("----------------------------");
	// Test3.1:移除索引为7(即最后一个节点)的位置的节点
	linkedList.RemoveAt(7);
	Console.WriteLine("After remove an node in index of 7:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	// Test3.2:移除索引为0(即第一个节点)的位置的节点的值
	linkedList.RemoveAt(0);
	Console.WriteLine("After remove an node in index of 0:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	// Test3.3:移除索引为2(即第3个节点)的位置的节点
	linkedList.RemoveAt(2);
	Console.WriteLine("After remove an node in index of 2:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	Console.WriteLine("----------------------------");
	// Test4:修改索引为2(即第3个节点)的位置的节点的值
	linkedList[2] = 9;
	Console.WriteLine("After update the value of node in index of 2:");
	for (int i = 0; i < linkedList.Count; i++)
	{
		Console.Write(linkedList[i] + " ");
	}
	Console.WriteLine();
	Console.WriteLine("----------------------------");
}
#endregion
/// <summary>
/// 双链表的模拟实现
/// </summary>
public class MyDoubleLinkedList<T>
{
	private int count; // 字段：当前链表节点个数
	private DbNode<T> head; // 字段：当前链表的头结点

	// 属性：当前链表节点个数
	public int Count
	{
		get
		{
			return this.count;
		}
	}

	// 索引器
	public T this[int index]
	{
		get
		{
			return this.GetNodeByIndex(index).Item;
		}
		set
		{
			this.GetNodeByIndex(index).Item = value;
		}
	}

	public MyDoubleLinkedList()
	{
		this.count = 0;
		this.head = null;
	}

	// Method01:根据索引获取节点
	private DbNode<T> GetNodeByIndex(int index)
	{
		if (index < 0 || index >= this.count)
		{
			throw new ArgumentOutOfRangeException("index", "索引超出范围");
		}

		DbNode<T> tempNode = this.head;
		for (int i = 0; i < index; i++)
		{
			tempNode = tempNode.Next;
		}

		return tempNode;
	}

	// Method02:在尾节点后插入新节点
	public void AddAfter(T value)
	{
		DbNode<T> newNode = new DbNode<T>(value);
		if (this.head == null)
		{
			// 如果链表当前为空则置为头结点
			this.head = newNode;
		}
		else
		{
			DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
			// 调整插入节点与前驱节点指针关系
			lastNode.Next = newNode;
			newNode.Prev = lastNode;
		}
		this.count++;
	}

	// Method03:在尾节点前插入新节点
	public void AddBefore(T value)
	{
		DbNode<T> newNode = new DbNode<T>(value);
		if (this.head == null)
		{
			// 如果链表当前为空则置为头结点
			this.head = newNode;
		}
		else
		{
			DbNode<T> lastNode = this.GetNodeByIndex(this.count - 1);
			DbNode<T> prevNode = lastNode.Prev;
			// 调整倒数第2个节点与插入节点的关系
			prevNode.Next = newNode;
			newNode.Prev = prevNode;
			// 调整倒数第1个节点与插入节点的关系
			lastNode.Prev = newNode;
			newNode.Next = lastNode;
		}
		this.count++;
	}

	// Method04:在指定位置后插入新节点
	public void InsertAfter(int index, T value)
	{
		DbNode<T> tempNode;
		if (index == 0)
		{
			if (this.head == null)
			{
				tempNode = new DbNode<T>(value);
				this.head = tempNode;
			}
			else
			{
				tempNode = new DbNode<T>(value);
				tempNode.Next = this.head;
				this.head.Prev = tempNode;
				this.head = tempNode;
			}
		}
		else
		{
			DbNode<T> prevNode = this.GetNodeByIndex(index); // 获得插入位置的节点
			DbNode<T> nextNode = prevNode.Next; // 获取插入位置的后继节点
			tempNode = new DbNode<T>(value);
			// 调整插入节点与前驱节点指针关系
			prevNode.Next = tempNode;
			tempNode.Prev = prevNode;
			// 调整插入节点与后继节点指针关系
			if (nextNode != null)
			{
				tempNode.Next = nextNode;
				nextNode.Prev = tempNode;
			}
		}
		this.count++;
	}

	// Method05:在指定位置前插入新节点
	public void InsertBefore(int index, T value)
	{
		DbNode<T> tempNode;
		if (index == 0)
		{
			if (this.head == null)
			{
				tempNode = new DbNode<T>(value);
				this.head = tempNode;
			}
			else
			{
				tempNode = new DbNode<T>(value);
				tempNode.Next = this.head;
				this.head.Prev = tempNode;
				this.head = tempNode;
			}
		}
		else
		{
			DbNode<T> nextNode = this.GetNodeByIndex(index); // 获得插入位置的节点
			DbNode<T> prevNode = nextNode.Prev; // 获取插入位置的前驱节点
			tempNode = new DbNode<T>(value);
			// 调整插入节点与前驱节点指针关系
			prevNode.Next = tempNode;
			tempNode.Prev = prevNode;
			// 调整插入节点与后继节点指针关系
			tempNode.Next = nextNode;
			nextNode.Prev = tempNode;
		}
		this.count++;
	}

	// Method06:移除指定位置的节点
	public void RemoveAt(int index)
	{
		if (index == 0)
		{
			this.head = this.head.Next;
		}
		else
		{
			DbNode<T> prevNode = this.GetNodeByIndex(index - 1);
			if (prevNode.Next == null)
			{
				throw new ArgumentOutOfRangeException("index", "索引超出范围");
			}

			DbNode<T> deleteNode = prevNode.Next;
			DbNode<T> nextNode = deleteNode.Next;
			prevNode.Next = nextNode;
			if (nextNode != null)
			{
				nextNode.Prev = prevNode;
			}

			deleteNode = null;
		}
		this.count--;
	}
}
/// <summary>
/// 双链表的节点
/// </summary>
public class DbNode<T>
{
	public T Item { get; set; }
	public DbNode<T> Prev { get; set; }
	public DbNode<T> Next { get; set; }

	public DbNode()
	{
	}

	public DbNode(T item)
	{
		this.Item = item;
	}
}