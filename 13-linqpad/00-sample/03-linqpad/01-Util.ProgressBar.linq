<Query Kind="Program" />

void Main()
{
	var pb1 = new ProgressBar();
	Thread.Sleep(50);
	pb1.Update(10, "Doing something"); Thread.Sleep(550);
	pb1.Update(20, "Doing something"); Thread.Sleep(550);
	pb1.Update(40, "Doing something"); Thread.Sleep(550);
	pb1.Update(60, "Doing something"); Thread.Sleep(550);
	pb1.Update(80, "Doing something"); Thread.Sleep(550);
	pb1.Update(100); Thread.Sleep(50);
}
public class ProgressBar
{
	Util.ProgressBar prog;

	public ProgressBar()
	{
		Init("Processing");
	}

	private void Init(string msg)
	{
		prog = new Util.ProgressBar(msg).Dump();
		prog.Percent = 0;
	}

	public void Update(int percent)
	{
		Update(percent, null);
	}

	public void Update(int percent, string msg)
	{
		prog.Percent = percent;
		if (String.IsNullOrEmpty(msg))
		{
			if (percent > 99) prog.Caption = "Done.";
		}
		else
		{
			prog.Caption = msg;
		}
	}
}
// Define other methods and classes here
