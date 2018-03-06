<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	// 01.基于链表的队列
	QueueWithLinkListTest();
	"=".PadRight(30,'=').Dump();
	// 02.基于数组的队列
	QueueWithArrayTest();
}
#region Method01.基于链表的队列的测试
/// <summary>
/// 基于链表的队列的测试
/// </summary>
static void QueueWithLinkListTest()
{
	MyLinkQueue<int> queue = new MyLinkQueue<int>();
	Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
	Random rand = new Random();
	// 顺序插入5个元素
	for (int i = 0; i < 5; i++)
	{
		int num = rand.Next(1, 10);
		queue.EnQueue(num);
		Console.WriteLine("{0} enqueue.", num);
	}
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	// 5个元素依次出队
	for (int i = 0; i < 5; i++)
	{
		Console.WriteLine("{0} dequeue.", queue.DeQueue());
	}
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	// 顺序插入10个元素
	for (int i = 0; i < 10; i++)
	{
		int num = rand.Next(1, 10);
		queue.EnQueue(num);
		Console.WriteLine("{0} enqueue.", num);
	}
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	// 10个元素依次出队
	for (int i = 0; i < 10; i++)
	{
		Console.WriteLine("{0} dequeue.", queue.DeQueue());
	}
	Console.WriteLine("Size:{0}", queue.Size);
}
#endregion

#region Method02.基于数组的队列的测试
/// <summary>
/// 基于数组的队列的测试
/// </summary>
static void QueueWithArrayTest()
{
	MyArrayQueue<int> queue = new MyArrayQueue<int>(5);
	Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
	Console.WriteLine("Size:{0}", queue.Size);

	Random rand = new Random();
	// Test1.1:顺序插入5个数据元素
	for (int i = 0; i < 5; i++)
	{
		int num = rand.Next(1, 10);
		queue.EnQueue(num);
		Console.WriteLine("{0} enqueue.", num);
	}
	Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
	Console.WriteLine("Size:{0}", queue.Size);
	// Test1.2:临时插入1个数据元素验证数组是否扩容
	queue.EnQueue(rand.Next(1, 20));
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	// Test2.1:前5个元素出队
	for (int i = 0; i < 5; i++)
	{
		Console.WriteLine("{0} dequeue.", queue.DeQueue());
	}
	Console.WriteLine("Is Empty:{0}", queue.IsEmpty());
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	// Test2.2:最后一个数据元素出队验证数组是否收缩容量
	queue.DeQueue();
	Console.WriteLine("Size:{0}", queue.Size);
	Console.WriteLine("-------------------------");
	queue.DeQueue();
}
#endregion
/// <summary>
/// 基于数组的队列实现
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class MyArrayQueue<T>
{
	private T[] items;
	private int size;
	private int head;
	private int tail;

	public MyArrayQueue(int capacity)
	{
		this.items = new T[capacity];
		this.size = 0;
		this.head = this.tail = 0;
	}

	/// <summary>
	/// 入队
	/// </summary>
	/// <param name="item">入队元素</param>
	public void EnQueue(T item)
	{
		if (Size == items.Length)
		{
			// 扩大数组容量
			ResizeCapacity(items.Length * 2);
		}

		items[tail] = item;
		tail++;

		size++;
	}

	/// <summary>v 
	/// 出队
	/// </summary>
	/// <returns>出队元素</returns>
	public T DeQueue()
	{
		if (Size == 0)
		{
			return default(T);
		}

		T item = items[head];
		items[head] = default(T);
		head++;

		if (head > 0 && Size == items.Length / 4)
		{
			// 缩小数组容量
			ResizeCapacity(items.Length / 2);
		}

		size--;
		return item;
	}

	/// <summary>
	/// 重置数组大小
	/// </summary>
	/// <param name="newCapacity">新的容量</param>
	private void ResizeCapacity(int newCapacity)
	{
		T[] newItems = new T[newCapacity];
		int index = 0;
		if (newCapacity > items.Length)
		{
			for (int i = 0; i < items.Length; i++)
			{
				newItems[index++] = items[i];
			}
		}
		else
		{
			for (int i = 0; i < items.Length; i++)
			{
				if (!items[i].Equals(default(T)))
				{
					newItems[index++] = items[i];
				}
			}

			head = tail = 0;
		}

		items = newItems;
	}

	/// <summary>
	/// 栈是否为空
	/// </summary>
	/// <returns>true/false</returns>
	public bool IsEmpty()
	{
		return this.size == 0;
	}

	/// <summary>
	/// 栈中节点个数
	/// </summary>
	public int Size
	{
		get
		{
			return this.size;
		}
	}
}
//======================
/// <summary>
/// 基于链表的队列节点
/// </summary>
/// <typeparam name="T"></typeparam>
public class Node<T>
{
	public T Item { get; set; }
	public Node<T> Next { get; set; }

	public Node(T item)
	{
		this.Item = item;
	}

	public Node()
	{ }
}

/// <summary>
/// 基于链表的队列实现
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class MyLinkQueue<T>
{
	private Node<T> head;
	private Node<T> tail;
	private int size;

	public MyLinkQueue()
	{
		this.head = null;
		this.tail = null;
		this.size = 0;
	}

	/// <summary>
	/// 入队操作
	/// </summary>
	/// <param name="node">节点元素</param>
	public void EnQueue(T item)
	{
		Node<T> oldLastNode = tail;
		tail = new Node<T>();
		tail.Item = item;

		if (IsEmpty())
		{
			head = tail;
		}
		else
		{
			oldLastNode.Next = tail;
		}

		size++;
	}

	/// <summary>
	/// 出队操作
	/// </summary>
	/// <returns>出队元素</returns>
	public T DeQueue()
	{
		T result = head.Item;
		head = head.Next;
		size--;

		if (IsEmpty())
		{
			tail = null;
		}
		return result;
	}

	/// <summary>
	/// 是否为空队列
	/// </summary>
	/// <returns>true/false</returns>
	public bool IsEmpty()
	{
		return this.size == 0;
	}

	/// <summary>
	/// 队列中节点个数
	/// </summary>
	public int Size
	{
		get
		{
			return this.size;
		}
	}
}
