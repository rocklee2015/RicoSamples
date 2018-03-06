<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	// 01.基于链表的栈
	//StackWithLinkListTest();
	// 02.基于数组的栈
	//StackWithArrayTest();
	// 03.进制转换问题
	NumberConvertTest();
}

#region Method01.基于链表的栈的测试
/// <summary>
/// 基于链表的栈的测试
/// </summary>
static void StackWithLinkListTest()
{
	MyLinkStack<int> stack = new MyLinkStack<int>();
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());

	Random rand = new Random();
	for (int i = 0; i < 10; i++)
	{
		stack.Push(rand.Next(1, 10));
	}
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
	Console.WriteLine("Size:{0}", stack.Size);
	Console.WriteLine("-------------------------------");

	for (int i = 0; i < 10; i++)
	{
		int node = stack.Pop();
		Console.Write(node + " ");
	}
	Console.WriteLine();
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
	Console.WriteLine("Size:{0}", stack.Size);
	Console.WriteLine("-------------------------------");

	for (int i = 0; i < 15; i++)
	{
		stack.Push(rand.Next(1, 15));
	}
	for (int i = 0; i < 15; i++)
	{
		int node = stack.Pop();
		Console.Write(node + " ");
	}
	Console.WriteLine();
}
#endregion

#region Method02.基于数组的栈的测试
/// <summary>
/// 基于数组的栈的测试
/// </summary>
static void StackWithArrayTest()
{
	MyArrayStack<int> stack = new MyArrayStack<int>(10);
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());

	Random rand = new Random();
	for (int i = 0; i < 10; i++)
	{
		stack.Push(rand.Next(1, 10));
	}
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
	Console.WriteLine("Size:{0}", stack.Size);
	Console.WriteLine("-------------------------------");

	for (int i = 0; i < 10; i++)
	{
		int node = stack.Pop();
		Console.Write(node + " ");
	}
	Console.WriteLine();
	Console.WriteLine("IsEmpty:{0}", stack.IsEmpty());
	Console.WriteLine("Size:{0}", stack.Size);
	Console.WriteLine("-------------------------------");

	for (int i = 0; i < 15; i++)
	{
		stack.Push(rand.Next(1, 15));
	}
	for (int i = 0; i < 15; i++)
	{
		int node = stack.Pop();
		Console.Write(node + " ");
	}
	Console.WriteLine();
}
#endregion

#region Method03:进制转换问题
static void NumberConvertTest()
{
	Console.WriteLine("请先输入要转换的十进制数：");
	int num = Convert.ToInt32(Console.ReadLine());
	Console.WriteLine("请再输入要转换的进制：(2进制、8进制、16进制)");
	int dec = Convert.ToInt32(Console.ReadLine());

	string result = DecConvert(num, dec);
	if (string.IsNullOrEmpty(result))
	{
		Console.WriteLine("#_#:转换出错，请重新再试！");
	}
	else
	{
		Console.WriteLine("^_^:({0})=({1})", num.ToString(), result);
	}
}

private static string DecConvert(int num, int dec)
{
	if (dec < 2 || dec > 16)
	{
		throw new ArgumentOutOfRangeException("dec", "只支持将十进制数转换为二进制到十六进制数");
	}

	MyLinkStack<char> stack = new MyLinkStack<char>();
	int residue;
	// 余数入栈
	while (num != 0)
	{
		residue = num % dec;
		if (residue >= 10)
		{
			// 如果是转换为16进制且余数大于10则需要转换为ABCDEF
			residue = residue + 55;
		}
		else
		{
			// 转换为ASCII码中的数字型字符1~9
			residue = residue + 48;
		}
		stack.Push((char)residue);
		num = num / dec;
	}
	// 反序出栈
	string result = string.Empty;
	while (stack.Size > 0)
	{
		result += stack.Pop();
	}

	return result;
}
#endregion

//=========
/// <summary>
/// 基于数组的栈实现
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class MyArrayStack<T>
{
	private T[] nodes;
	private int index;

	public MyArrayStack(int capacity)
	{
		this.nodes = new T[capacity];
		this.index = 0;
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="node">节点元素</param>
	public void Push(T node)
	{
		if (index == nodes.Length)
		{
			// 增大数组容量
			ResizeCapacity(nodes.Length * 2);
		}

		nodes[index] = node;
		index++;
	}

	/// <summary>
	/// 出栈
	/// </summary>
	/// <returns>出栈节点元素</returns>
	public T Pop()
	{
		if (index == 0)
		{
			return default(T);
		}

		T node = nodes[index - 1];
		index--;
		nodes[index] = default(T);

		if (index > 0 && index == nodes.Length / 4)
		{
			// 缩小数组容量
			ResizeCapacity(nodes.Length / 2);
		}
		return node;
	}

	/// <summary>
	/// 重置数组大小
	/// </summary>
	/// <param name="newCapacity">新的容量</param>
	private void ResizeCapacity(int newCapacity)
	{
		T[] newNodes = new T[newCapacity];
		if (newCapacity > nodes.Length)
		{
			for (int i = 0; i < nodes.Length; i++)
			{
				newNodes[i] = nodes[i];
			}
		}
		else
		{
			for (int i = 0; i < newCapacity; i++)
			{
				newNodes[i] = nodes[i];
			}
		}

		nodes = newNodes;
	}

	/// <summary>
	/// 栈是否为空
	/// </summary>
	/// <returns>true/false</returns>
	public bool IsEmpty()
	{
		return this.index == 0;
	}

	/// <summary>
	/// 栈中节点个数
	/// </summary>
	public int Size
	{
		get
		{
			return this.index;
		}
	}
}
//==================
/// <summary>
/// 基于链表的栈节点
/// </summary>
/// <typeparam name="T">元素类型</typeparam>
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
/// 基于链表的栈实现
/// </summary>
/// <typeparam name="T">类型</typeparam>
public class MyLinkStack<T>
{
	private Node<T> first;
	private int index;

	public MyLinkStack()
	{
		this.first = null;
		this.index = 0;
	}

	/// <summary>
	/// 入栈
	/// </summary>
	/// <param name="item">新节点</param>
	public void Push(T item)
	{
		Node<T> oldNode = first;
		first = new Node<T>();
		first.Item = item;
		first.Next = oldNode;

		index++;
	}

	/// <summary>
	/// 出栈
	/// </summary>
	/// <returns>出栈元素</returns>
	public T Pop()
	{
		T item = first.Item;
		first = first.Next;
		index--;

		return item;
	}

	/// <summary>
	/// 是否为空栈
	/// </summary>
	/// <returns>true/false</returns>
	public bool IsEmpty()
	{
		return this.index == 0;
	}

	/// <summary>
	/// 栈中节点个数
	/// </summary>
	public int Size
	{
		get
		{
			return this.index;
		}
	}
}
