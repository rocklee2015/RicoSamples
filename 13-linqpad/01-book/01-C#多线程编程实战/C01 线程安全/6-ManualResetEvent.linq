<Query Kind="Program" />

//一开始设置为false才会等待收到信号才执行
static ManualResetEvent mr = new ManualResetEvent(false);
void Main()
{
	Thread t = new Thread(Run);
	//启动辅助线程
	t.Start();
	//等待辅助线程执行完毕之后，主线程才继续执行
	Console.WriteLine("主线程一边做自己的事，一边等辅助线程执行!" + DateTime.Now.ToString("mm:ss"));
	mr.WaitOne();
	Console.WriteLine("收到信号，主线程继续执行" + DateTime.Now.ToString("mm:ss"));
	
}
static void Run()
{
	//模拟长时间任务
	Thread.Sleep(3000);
	Console.WriteLine("辅助线程长时间任务完成！" + DateTime.Now.ToString("mm:ss"));
	mr.Set();
}

// Define other methods and classes here