<Query Kind="Program">
  <Reference Relative="..\..\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll">D:\00-github\00-Rocklee2015\RicoSamples\13-linqpad\00-sample\02-linq pad sample lib\queries\LinqInAction.LinqBooks.Common.dll</Reference>
  <Namespace>LinqInAction.LinqBooks.Common</Namespace>
</Query>

void Main()
{
	//MyBinaryTreeBasicTest();
	//MyBinarySearchTreeTest();
	MyBinaryExpressionTreeTest();
}

#region Test01:二叉树基本测试
static void MyBinaryTreeBasicTest()
{
	// 构造一颗二叉树，根节点为"A"
	MyBinaryTree<string> bTree = new MyBinaryTree<string>("A");
	Node<string> rootNode = bTree.Root;
	// 向根节点"A"插入左孩子节点"B"和右孩子节点"C"
	bTree.InsertLeft(rootNode, "B");
	bTree.InsertRight(rootNode, "C");
	// 向节点"B"插入左孩子节点"D"和右孩子节点"E"
	Node<string> nodeB = rootNode.lchild;
	bTree.InsertLeft(nodeB, "D");
	bTree.InsertRight(nodeB, "E");
	// 向节点"C"插入右孩子节点"F"
	Node<string> nodeC = rootNode.rchild;
	bTree.InsertRight(nodeC, "F");
	// 计算二叉树目前的深度
	Console.WriteLine("The depth of the tree : {0}", bTree.GetDepth(bTree.Root));

	// 前序遍历
	Console.WriteLine("---------PreOrder---------");
	bTree.PreOrder(bTree.Root);
	// 中序遍历
	Console.WriteLine();
	Console.WriteLine("---------MidOrder---------");
	bTree.MidOrder(bTree.Root);
	// 后序遍历
	Console.WriteLine();
	Console.WriteLine("---------PostOrder---------");
	bTree.PostOrder(bTree.Root);
	Console.WriteLine();
	// 前序遍历（非递归）
	Console.WriteLine("---------PreOrderNoRecurise---------");
	bTree.PreOrderNoRecurise(bTree.Root);
	// 中序遍历（非递归）
	Console.WriteLine();
	Console.WriteLine("---------MidOrderNoRecurise---------");
	bTree.MidOrderNoRecurise(bTree.Root);
	// 后序遍历（非递归）
	Console.WriteLine();
	Console.WriteLine("---------PostOrderNoRecurise---------");
	bTree.PostOrderNoRecurise(bTree.Root);
	Console.WriteLine();
	// 层次遍历
	Console.WriteLine("---------LevelOrderNoRecurise---------");
	bTree.LevelOrder(bTree.Root);
}
#endregion

#region Test02:二叉查找树基本测试
static void MyBinarySearchTreeTest()
{
	MyBinarySearchTree bst = new MyBinarySearchTree(8);
	bst.InsertNode(3);
	bst.InsertNode(10);
	bst.InsertNode(1);
	bst.InsertNode(6);
	bst.InsertNode(14);
	bst.InsertNode(4);
	bst.InsertNode(7);
	bst.InsertNode(13);

	Console.WriteLine("----------First LevelOrder----------");
	bst.LevelOrder(bst.Root);
	Console.WriteLine();

	bst.RemoveNode(6);
	Console.WriteLine("----------LevelOrder Again----------");
	bst.LevelOrder(bst.Root);
	Console.WriteLine();
}
#endregion

#region Test03:二叉表达式树求解四则运算
static void MyBinaryExpressionTreeTest()
{
	Console.WriteLine("请输入四则运算表达式（暂不支持带括号）：");
	string expression = Console.ReadLine();

	MyBinaryExprTree exprTree = new MyBinaryExprTree(expression);
	int result = exprTree.GetResult();
	Console.WriteLine("{0}={1}", expression, result);
}
#endregion
//===============
/// <summary>
/// 二叉表达式树求解四则运算
/// </summary>
public class MyBinaryExprTree
{
	private Node _head;         // 头结点指针
	private string _expression; // 构造二叉树的字符串
	private int _pos;           // 当前解析的字符所在的位置

	public MyBinaryExprTree(string constructStr)
	{
		this._expression = constructStr;
		this._head = CreateTree();
	}

	// 创建表达式树
	private Node CreateTree()
	{
		Node head = null;

		while (_pos < _expression.Length)
		{
			Node node = GetNode(); // 将当前解析字符转换为节点
			if (head == null)
			{
				head = node;
			}
			else if (head.IsOptr == false) // 根节点为数字，当前节点为根，原根节点变为左孩子
			{
				node.Left = head;
				head = node;
			}
			else if (node.IsOptr == false) // 如果当前节点是数字
			{
				// 当前节点沿右路插入最右边成为右孩子
				Node tempNode = head;
				while (tempNode.Right != null)
				{
					tempNode = tempNode.Right;
				}
				tempNode.Right = node;
			}
			else // 如果当前节点是运算符
			{
				if (GetPriority((char)node.Data) <= GetPriority((char)head.Data)) // 优先级低则成为根，原二叉树成为插入节点的左子树
				{
					node.Left = head;
					head = node;
				}
				else // 优先级高则成为根节点的右子树，原右子树成为插入节点的左子树
				{
					node.Left = head.Right;
					head.Right = node;
				}
			}
		}

		return head;
	}

	// 创建指定规范节点
	private Node GetNode()
	{
		char ch = _expression[_pos];
		if (char.IsDigit(ch))  // 字符为数字时
		{
			// 当操作数为2位及以上整数时,需要使用循环获取
			StringBuilder sbNumber = new StringBuilder();
			while (_pos < _expression.Length && char.IsDigit(ch = _expression[_pos]))
			{
				sbNumber.Append(ch);
				_pos++;
			}

			return new Node(Convert.ToInt32(sbNumber.ToString()));
		}
		else // 字符为运算符时
		{
			_pos++;
			return new Node(ch);
		}
	}

	// 先序遍历进行表达式求值
	private int PreOrderCalc(Node node)
	{
		int num1, num2;
		if (node.IsOptr)
		{
			// 递归先序遍历计算num1
			num1 = PreOrderCalc(node.Left);
			// 递归先序遍历计算num2
			num2 = PreOrderCalc(node.Right);
			char optr = (char)node.Data;

			switch (optr)
			{
				case '+':
					node.Data = num1 + num2;
					break;
				case '-':
					node.Data = num1 - num2;
					break;
				case '*':
					node.Data = num1 * num2;
					break;
				case '/':
					if (num2 == 0)
					{
						throw new DivideByZeroException("除数不能为0！");
					}
					node.Data = num1 / num2;
					break;
			}
		}

		return node.Data;
	}

	// 获取运算符的优先级
	private int GetPriority(char optr)
	{
		if (optr == '+' || optr == '-')
		{
			return 1;
		}
		else if (optr == '*' || optr == '/')
		{
			return 2;
		}
		else
		{
			return 0;
		}
	}

	// 获取四则运算表达式的值
	public int GetResult()
	{
		return PreOrderCalc(this._head);
	}

	#region 内部类：二叉表达式树节点
	/// <summary>
	/// 内部类：二叉表达式树节点
	/// </summary>
	private class Node
	{
		private bool _isOptr;

		public bool IsOptr
		{
			get { return _isOptr; }
			set { _isOptr = value; }
		}
		private int _data;

		public int Data
		{
			get { return _data; }
			set { _data = value; }
		}
		private Node _left;

		public Node Left
		{
			get { return _left; }
			set { _left = value; }
		}
		private Node _right;

		public Node Right
		{
			get { return _right; }
			set { _right = value; }
		}

		public Node(int data)
		{
			this._data = data;
			this._isOptr = false;
		}

		public Node(char optr)
		{
			this._isOptr = true;
			this._data = optr;
		}

		public override string ToString()
		{
			if (this._isOptr)
			{
				return Convert.ToString((char)this._data);
			}
			else
			{
				return this._data.ToString();
			}
		}
	}
	#endregion
}
//=========
/// <summary>
/// 二叉查找树的模拟实现
/// </summary>
public class MyBinarySearchTree
{
	// 二叉树的根节点
	private Node root;
	public Node Root
	{
		get
		{
			return this.root;
		}
	}

	public MyBinarySearchTree() { }

	public MyBinarySearchTree(int data)
	{
		this.root = new Node(data);
	}

	#region 基本的创建与移除方法
	// Method:判断该二叉树是否是空树
	public bool IsEmpty()
	{
		return this.root == null;
	}

	// Method:插入一个新节点
	public void InsertNode(int data)
	{
		Node newNode = new Node();
		newNode.data = data;

		if (this.root == null)
		{
			this.root = newNode;
		}
		else
		{
			Node currentNode = this.root;
			Node parentNode = null;

			while (currentNode != null)
			{
				parentNode = currentNode;
				if (currentNode.data < data)
				{
					currentNode = currentNode.rchild;
				}
				else
				{
					currentNode = currentNode.lchild;
				}
			}

			if (parentNode.data < data)
			{
				// 若插入的元素值小于根节点值，则将元素插入到左子树中
				parentNode.rchild = newNode;
			}
			else
			{
				// 若插入的元素值不小于根节点值，则将元素插入到右子树中
				parentNode.lchild = newNode;
			}
		}
	}

	// Method:移除一个旧节点
	public void RemoveNode(int key)
	{
		Node current = null, parent = null;

		// 定位节点位置
		current = FindNode(key);

		// 没找到data为key的节点
		if (current == null)
		{
			Console.WriteLine("没有找到data为{0}的节点!", key);
			return;
		}

		#region 1.如果该节点是叶子节点
		if (current.lchild == null && current.rchild == null) // 如果该节点是叶子节点
		{
			if (current == this.root) // 如果该节点为根节点
			{
				this.root = null;
			}
			else if (parent.lchild == current) // 如果该节点为左孩子节点
			{
				parent.lchild = null;
			}
			else if (parent.rchild == current) // 如果该节点为右孩子节点
			{
				parent.rchild = null;
			}
		}
		#endregion
		#region 2.如果该节点是单支节点
		else if (current.lchild == null || current.rchild == null) // 如果该节点是单支节点 (只有一个左孩子节点或者一个右孩子节点)
		{
			if (current == this.root) // 如果该节点为根节点
			{
				if (current.lchild == null)
				{
					this.root = current.rchild;
				}
				else
				{
					this.root = current.lchild;
				}
			}
			else
			{
				if (parent.lchild == current && current.lchild != null)  // p是q的左孩子且p有左孩子
				{
					parent.lchild = current.lchild;
				}
				else if (parent.lchild == current && current.rchild != null) // p是q的左孩子且p有右孩子
				{
					parent.rchild = current.rchild;
				}
				else if (parent.rchild == current && current.lchild != null) // p是q的右孩子且p有左孩子
				{
					parent.rchild = current.lchild;
				}
				else // p是q的右孩子且p有右孩子
				{
					parent.rchild = current.rchild;
				}
			}
		}
		#endregion
		#region 3.如果该节点的左右子树均不为空 
		else // 如果该节点的左右子树均不为空 
		{
			Node t = current;
			Node s = current.lchild; // 从p的左子节点开始 
									 // 找到p的前驱，即p左子树中值最大的节点 
			while (s.rchild != null)
			{
				t = s;
				s = s.rchild;
			}

			current.data = s.data; // 把节点s的值赋给p

			if (t == current)
			{
				current.lchild = s.lchild;
			}
			else
			{
				current.rchild = s.rchild;
			}
		}
		#endregion
	}

	// Method:根据Key查找某个节点
	public Node FindNode(int key)
	{
		Node currentNode = this.root;
		while (currentNode != null && currentNode.data != key)
		{
			if (currentNode.data < key)
			{
				currentNode = currentNode.rchild;
			}
			else if (currentNode.data > key)
			{
				currentNode = currentNode.lchild;
			}
			else
			{
				break;
			}
		}

		return currentNode;
	}

	// Method:查找最大值
	public int FindMaxData()
	{
		Node currentNode = this.root;
		while (currentNode != null)
		{
			currentNode = currentNode.rchild;
		}

		return currentNode.data;
	}

	// Method:判断节点p是否叶子节点
	public bool IsLeafNode(Node p)
	{
		if (p == null)
		{
			return false;
		}

		return p.lchild == null && p.rchild == null;
	}

	// Method:计算二叉树的深度
	public int GetDepth(Node root)
	{
		if (root == null)
		{
			return 0;
		}

		int leftDepth = GetDepth(root.lchild);
		int rightDepth = GetDepth(root.rchild);

		if (leftDepth > rightDepth)
		{
			return leftDepth + 1;
		}
		else
		{
			return rightDepth + 1;
		}
	}
	#endregion

	#region 基本的遍历方法
	// Method01:前序遍历
	public void PreOrder(Node node)
	{
		if (node != null)
		{
			// 根->左->右
			Console.Write(node.data);
			PreOrder(node.lchild);
			PreOrder(node.rchild);
		}
	}

	// Method02:中序遍历
	public void MidOrder(Node node)
	{
		if (node != null)
		{
			// 左->根->右
			MidOrder(node.lchild);
			Console.Write(node.data);
			MidOrder(node.rchild);
		}
	}

	// Method03:后序遍历
	public void PostOrder(Node node)
	{
		if (node != null)
		{
			// 左->右->根
			PostOrder(node.lchild);
			PostOrder(node.rchild);
			Console.Write(node.data);
		}
	}

	// Method04:层次遍历（广度优先遍历）
	public void LevelOrder(Node node)
	{
		if (root == null)
		{
			return;
		}

		Queue<Node> queueNodes = new Queue<Node>();
		queueNodes.Enqueue(node);
		Node tempNode = null;
		// 利用队列先进先出的特性存储节点并输出
		while (queueNodes.Count > 0)
		{
			tempNode = queueNodes.Dequeue();
			Console.Write(tempNode.data + " ");

			if (tempNode.lchild != null)
			{
				queueNodes.Enqueue(tempNode.lchild);
			}

			if (tempNode.rchild != null)
			{
				queueNodes.Enqueue(tempNode.rchild);
			}
		}
	}
	#endregion

	#region 嵌套类：节点
	public class Node
	{
		public int data { get; set; }

		public Node lchild { get; set; }

		public Node rchild { get; set; }

		public Node()
		{
		}

		public Node(int data)
		{
			this.data = data;
		}

		public Node(int data, Node lchild, Node rchild)
		{
			this.data = data;
			this.lchild = lchild;
			this.rchild = rchild;
		}
	}
	#endregion
}
//=============
/// <summary>
/// 二叉树的模拟实现
/// </summary>
/// <typeparam name="T">数据具体类型</typeparam>
public class MyBinaryTree<T>
{
	// 二叉树的根节点
	private Node<T> root;
	public Node<T> Root
	{
		get
		{
			return this.root;
		}
	}

	public MyBinaryTree() { }

	public MyBinaryTree(T data)
	{
		this.root = new Node<T>(data);
	}

	#region 基本的创建与移除方法
	// Method01:判断该二叉树是否是空树
	public bool IsEmpty()
	{
		return this.root == null;
	}

	// Method02:在节点p下插入左孩子节点的data
	public void InsertLeft(Node<T> p, T data)
	{
		Node<T> tempNode = new Node<T>(data);
		tempNode.lchild = p.lchild;

		p.lchild = tempNode;
	}

	// Method03:在节点p下插入右孩子节点的data
	public void InsertRight(Node<T> p, T data)
	{
		Node<T> tempNode = new Node<T>(data);
		tempNode.rchild = p.rchild;

		p.rchild = tempNode;
	}

	// Method04:删除节点p下的左子树
	public Node<T> RemoveLeft(Node<T> p)
	{
		if (p == null || p.lchild == null)
		{
			return null;
		}

		Node<T> tempNode = p.lchild;
		p.lchild = null;
		return tempNode;
	}

	// Method05:删除节点p下的右子树
	public Node<T> RemoveRight(Node<T> p)
	{
		if (p == null || p.rchild == null)
		{
			return null;
		}

		Node<T> tempNode = p.rchild;
		p.rchild = null;
		return tempNode;
	}

	// Method06:判断节点p是否叶子节点
	public bool IsLeafNode(Node<T> p)
	{
		if (p == null)
		{
			return false;
		}

		return p.lchild == null && p.rchild == null;
	}

	// Method07:计算二叉树的深度
	public int GetDepth(Node<T> root)
	{
		if (root == null)
		{
			return 0;
		}

		int leftDepth = GetDepth(root.lchild);
		int rightDepth = GetDepth(root.rchild);

		if (leftDepth > rightDepth)
		{
			return leftDepth + 1;
		}
		else
		{
			return rightDepth + 1;
		}
	}
	#endregion

	#region 基本的递归遍历方法
	// Method01:前序遍历
	public void PreOrder(Node<T> node)
	{
		if (node != null)
		{
			// 根->左->右
			Console.Write(node.data);
			PreOrder(node.lchild);
			PreOrder(node.rchild);
		}
	}

	// Method02:中序遍历
	public void MidOrder(Node<T> node)
	{
		if (node != null)
		{
			// 左->根->右
			MidOrder(node.lchild);
			Console.Write(node.data);
			MidOrder(node.rchild);
		}
	}

	// Method03:后序遍历
	public void PostOrder(Node<T> node)
	{
		if (node != null)
		{
			// 左->右->根
			PostOrder(node.lchild);
			PostOrder(node.rchild);
			Console.Write(node.data);
		}
	}
	#endregion

	#region 基本的非递归遍历方法
	// Method01:前序遍历
	public void PreOrderNoRecurise(Node<T> node)
	{
		if (node == null)
		{
			return;
		}
		// 根->左->右
		Stack<Node<T>> stack = new Stack<Node<T>>();
		stack.Push(node);
		Node<T> tempNode = null;

		while (stack.Count > 0)
		{
			// 1.遍历根节点
			tempNode = stack.Pop();
			Console.Write(tempNode.data);
			// 2.右子树压栈
			if (tempNode.rchild != null)
			{
				stack.Push(tempNode.rchild);
			}
			// 3.左子树压栈(目的：保证下一个出栈的是左子树的节点)
			if (tempNode.lchild != null)
			{
				stack.Push(tempNode.lchild);
			}
		}
	}

	// Method02:中序遍历
	public void MidOrderNoRecurise(Node<T> node)
	{
		if (node == null)
		{
			return;
		}
		// 左->根->右
		Stack<Node<T>> stack = new Stack<Node<T>>();
		Node<T> tempNode = node;

		while (tempNode != null || stack.Count > 0)
		{
			// 1.依次将所有左子树节点压栈
			while (tempNode != null)
			{
				stack.Push(tempNode);
				tempNode = tempNode.lchild;
			}
			// 2.出栈遍历节点
			tempNode = stack.Pop();
			Console.Write(tempNode.data);
			// 3.左子树遍历结束则跳转到右子树
			tempNode = tempNode.rchild;
		}
	}

	// Method03:后序遍历
	public void PostOrderNoRecurise(Node<T> node)
	{
		if (root == null)
		{
			return;
		}

		// 两个栈：一个存储，一个输出
		Stack<Node<T>> stackIn = new Stack<Node<T>>();
		Stack<Node<T>> stackOut = new Stack<Node<T>>();
		Node<T> currentNode = null;
		// 根节点首先压栈
		stackIn.Push(node);
		// 左->右->根
		while (stackIn.Count > 0)
		{
			currentNode = stackIn.Pop();
			stackOut.Push(currentNode);
			// 左子树压栈
			if (currentNode.lchild != null)
			{
				stackIn.Push(currentNode.lchild);
			}
			// 右子树压栈
			if (currentNode.rchild != null)
			{
				stackIn.Push(currentNode.rchild);
			}
		}

		while (stackOut.Count > 0)
		{
			// 依次遍历各节点
			Node<T> outNode = stackOut.Pop();
			Console.Write(outNode.data);
		}
	}

	// Method04:层次遍历（广度优先遍历）
	public void LevelOrder(Node<T> node)
	{
		if (root == null)
		{
			return;
		}

		Queue<Node<T>> queueNodes = new Queue<Node<T>>();
		queueNodes.Enqueue(node);
		Node<T> tempNode = null;
		// 利用队列先进先出的特性存储节点并输出
		while (queueNodes.Count > 0)
		{
			tempNode = queueNodes.Dequeue();
			Console.Write(tempNode.data);

			if (tempNode.lchild != null)
			{
				queueNodes.Enqueue(tempNode.lchild);
			}

			if (tempNode.rchild != null)
			{
				queueNodes.Enqueue(tempNode.rchild);
			}
		}
	}
	#endregion
}
//======
/// <summary>
/// 二叉树的节点定义
/// </summary>
/// <typeparam name="T">数据具体类型</typeparam>
public class Node<T>
{
	public T data { get; set; }

	public Node<T> lchild { get; set; }

	public Node<T> rchild { get; set; }

	public Node()
	{
	}

	public Node(T data)
	{
		this.data = data;
	}

	public Node(T data, Node<T> lchild, Node<T> rchild)
	{
		this.data = data;
		this.lchild = lchild;
		this.rchild = rchild;
	}
}