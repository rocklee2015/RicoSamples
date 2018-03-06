<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

/* The compiler uses the same approach that it does with iterators: it rewrites the method
into a class that implements a STATE MACHINE: What were local variables are now fields in a
private nested class. After each call to await, the _state field is incremented, so we get
called back later in the method: */

void Main()
{
	var sm = new StateMachine(this);
	sm.MoveNext();
}

class StateMachine   // This is a simplification, as we'll see later...
{
	UserQuery _host;
	int _state;
	Task<string> _taskA, _taskB, _taskC;
	string s1, s2, s3;
	
	public StateMachine (UserQuery host) { _host = host; }

	public void MoveNext()
	{
		switch (_state++)
		{
			case 0:
				_taskA = _host.A();
				_taskA.ContinueWith (ant => MoveNext());
				return;
			case 1:
				s1 = _taskA.Result;
				_taskB = _host.B();
				_taskB.ContinueWith (ant => MoveNext());
				return;
			case 2:
				s2 = _taskB.Result;
				_taskC = _host.C();
				_taskC.ContinueWith (ant => MoveNext());
				return;
			case 3:
				s3 = _taskC.Result;				
				Console.WriteLine (s1 + s2 + s3);
				return;
		}
	}
}

Task<string> A() { return Task.Delay (1000).ContinueWith (ant => "A"); }
Task<string> B() { return Task.Delay (1000).ContinueWith (ant => "B"); }
Task<string> C() { return Task.Delay (1000).ContinueWith (ant => "C"); }