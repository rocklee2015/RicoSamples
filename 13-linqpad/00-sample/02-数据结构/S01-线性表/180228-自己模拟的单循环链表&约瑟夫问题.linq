<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	// 自己模拟的单循环链表的测试
	MyCircularLinkedListTest();
	
	// 约瑟夫问题-自定义单循环链表
	JosephusTest();
	// 约瑟夫问题-LinkedList
	JosephusTestWithLinkedList();
}
#region Method04:自己模拟的单循环链表的测试
static void MyCircularLinkedListTest()
{
	MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
	// 顺序插入5个节点
	linkedList.Add(1);
	linkedList.Add(2);
	linkedList.Add(3);
	linkedList.Add(4);
	linkedList.Add(5);

	Console.WriteLine("All nodes in the circular linked list:");
	Console.WriteLine(linkedList.GetAllNodes());
	Console.WriteLine("--------------------------------------");
	// 当前节点：第一个节点
	Console.WriteLine("Current node in the circular linked list:");
	Console.WriteLine(linkedList.CurrentItem);
	Console.WriteLine("--------------------------------------");
	// 移除当前节点(第一个节点)
	linkedList.Remove();
	Console.WriteLine("After remove the current node:");
	Console.WriteLine(linkedList.GetAllNodes());
	Console.WriteLine("Current node in the circular linked list:");
	Console.WriteLine(linkedList.CurrentItem);
	// 移除当前节点(第二个节点)
	linkedList.Remove();
	Console.WriteLine("After remove the current node:");
	Console.WriteLine(linkedList.GetAllNodes());
	Console.WriteLine("Current node in the circular linked list:");
	Console.WriteLine(linkedList.CurrentItem);
	Console.WriteLine("--------------------------------------");
}
#endregion
#region Method05:约瑟夫问题-自定义循环链表
static void JosephusTest()
{
	MyCircularLinkedList<int> linkedList = new MyCircularLinkedList<int>();
	string result = string.Empty;

	Console.WriteLine("Step1:请输入人数N");
	int n = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("Step2:请输入数字M");
	int m = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("Step3:报数游戏开始");
	// 添加参与人员元素
	for (int i = 1; i <= n; i++)
	{
		linkedList.Add(i);
	}
	// 打印所有参与人员
	Console.Write("所有参与人员：{0}", linkedList.GetAllNodes());
	Console.Write("\r\n" + "-------------------------------------");
	result = string.Empty;

	while (linkedList.Count > 1)
	{
		// 依次报数：移动
		linkedList.Move(m);
		// 记录出队人员
		result += linkedList.CurrentItem + " ";
		// 移除人员出队
		linkedList.Remove();
		Console.WriteLine();
		Console.Write("剩余报数人员：{0}", linkedList.GetAllNodes());
		Console.Write("  开始报数人员：{0}", linkedList.CurrentItem);
	}
	Console.WriteLine("\r\n" + "Step4:报数游戏结束");
	Console.WriteLine("-------------------------------------");
	Console.WriteLine("出队人员顺序：{0}", result + linkedList.CurrentItem);
}
#endregion
#region Method06:约瑟夫问题-LinkedList<T>
static void JosephusTestWithLinkedList()
{
	Console.WriteLine("请输入人数N");
	int n = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("请输入数字M");
	int m = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("-------------------------------------");

	LinkedList<Person> linkedList = InitPersonList(n);
	// 记录开始报数人员节点
	LinkedListNode<Person> startNode = linkedList.First;
	// 记录出队人员节点
	LinkedListNode<Person> removeNode;

	Console.Write("出队顺序：");
	while (linkedList.Count >= 1)
	{
		for (int i = 1; i < m; i++)
		{
			if (startNode != linkedList.Last)
			{
				startNode = startNode.Next;
			}
			else
			{
				startNode = linkedList.First;
			}
		}
		// 记录出队人员节点
		removeNode = startNode;
		// 打印出队人员ID号
		Console.Write(removeNode.Value.Id + " ");
		// 确定下一个开始报数人员
		if (startNode == linkedList.Last)
		{
			startNode = linkedList.First;
		}
		else
		{
			startNode = startNode.Next;
		}
		// 移除出队人员节点
		linkedList.Remove(removeNode);
	}
	Console.WriteLine();
}

static LinkedList<Person> InitPersonList(int count)
{
	LinkedList<Person> personList = new LinkedList<Person>();
	for (int i = 1; i <= count; i++)
	{
		Person person = new Person();
		person.Id = i;
		person.Name = "Counter-" + i.ToString();

		personList.AddLast(person);
	}

	return personList;
}
#endregion
/// <summary>
/// 单向循环链表的模拟实现
/// </summary>
public class MyCircularLinkedList<T>
{
	private int count; // 字段：记录数据元素个数
	private CirNode<T> tail; // 字段：记录尾节点的指针
	private CirNode<T> currentPrev; // 字段：使用前驱节点标识当前节点

	// 属性：指示链表中元素的个数
	public int Count
	{
		get
		{
			return this.count;
		}
	}

	// 属性：指示当前节点中的元素值
	public T CurrentItem
	{
		get
		{
			return this.currentPrev.Next.Item;
		}
	}

	public MyCircularLinkedList()
	{
		this.count = 0;
		this.tail = null;
	}

	public bool IsEmpty()
	{
		return this.tail == null;
	}

	// Method01:根据索引获取节点
	private CirNode<T> GetNodeByIndex(int index)
	{
		if (index < 0 || index >= this.count)
		{
			throw new ArgumentOutOfRangeException("index", "索引超出范围");
		}

		CirNode<T> tempNode = this.tail.Next;
		for (int i = 0; i < index; i++)
		{
			tempNode = tempNode.Next;
		}

		return tempNode;
	}

	// Method02:在尾节点后插入新节点
	public void Add(T value)
	{
		CirNode<T> newNode = new CirNode<T>(value);
		if (this.tail == null)
		{
			// 如果链表当前为空则新元素既是尾头结点也是头结点
			this.tail = newNode;
			this.tail.Next = newNode;
			this.currentPrev = newNode;
		}
		else
		{
			// 插入到链表末尾处
			newNode.Next = this.tail.Next;
			this.tail.Next = newNode;
			// 改变当前节点
			if (this.currentPrev == this.tail)
			{
				this.currentPrev = newNode;
			}
			// 重新指向新的尾节点
			this.tail = newNode;
		}

		this.count++;
	}

	// Method03:移除当前所在节点
	public void Remove()
	{
		if (this.tail == null)
		{
			throw new NullReferenceException("链表中没有任何元素");
		}
		else if (this.count == 1)
		{
			// 只有一个元素时将两个指针置为空
			this.tail = null;
			this.currentPrev = null;
		}
		else
		{
			if (this.currentPrev.Next == this.tail)
			{
				// 当删除的是尾指针所指向的节点时
				this.tail = this.currentPrev;
			}
			// 移除当前节点
			this.currentPrev.Next = this.currentPrev.Next.Next;
		}

		this.count--;
	}

	// Method04:获取所有节点信息
	public string GetAllNodes()
	{
		if (this.count == 0)
		{
			throw new NullReferenceException("链表中没有任何元素");
		}
		else
		{
			CirNode<T> tempNode = this.tail.Next;
			string result = string.Empty;
			for (int i = 0; i < this.count; i++)
			{
				result += tempNode.Item + " ";
				tempNode = tempNode.Next;
			}

			return result;
		}
	}

	// Method05:让当前节点向前移动指定步数
	public void Move(int step = 1)
	{
		if (step < 1)
		{
			throw new ArgumentOutOfRangeException("step", "移动步数不能小于1");
		}

		for (int i = 1; i < step; i++)
		{
			currentPrev = currentPrev.Next;
		}
	}
}
/// <summary>
/// 循环链表节点定义
/// </summary>
public class CirNode<T>
{
	public T Item { get; set; }
	public CirNode<T> Next { get; set; }

	public CirNode()
	{
	}

	public CirNode(T item)
	{
		this.Item = item;
	}
}
public class Person
{
	public int Id { get; set; }

	public string Name { get; set; }
}