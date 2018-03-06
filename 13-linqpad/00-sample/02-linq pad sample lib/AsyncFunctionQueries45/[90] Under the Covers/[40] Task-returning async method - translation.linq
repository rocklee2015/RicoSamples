<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
</Query>

// The compiler must create a TaskCompletionSource in the StateMachine and signal it with
// the return value when the method's logic is complete. It must also catch any exceptions
// and signal the Task with these, too, so they can be caught by the caller.

void Main()
{
	ABC().ContinueWith (ant => Console.WriteLine (ant.Result));
}

Task<string> ABC()
{
	var sm = new StateMachine(this);
	sm.ABC();
	return sm.Task;
}

class StateMachine   // Not code you'd want to write yourself!!
{
	UserQuery _host;
	int _state;
	Task<string> _taskA, _taskB, _taskC;
	string s1, s2, s3;
	TaskCompletionSource<string> _tcs = new TaskCompletionSource<string>();
	public Task<string> Task { get { return _tcs.Task; } }
	
	public StateMachine (UserQuery host) { _host = host; }

	public void ABC()
	{
		try
		{		
			switch (_state++)
			{
				case 0:
					_taskA = _host.A();
					_taskA.ContinueWith (ant => ABC());
					return;
				case 1:
					s1 = _taskA.Result;
					_taskB = _host.B();
					_taskB.ContinueWith (ant => ABC());
					return;
				case 2:
					s2 = _taskB.Result;
					_taskC = _host.C();
					_taskC.ContinueWith (ant => ABC());
					return;
				case 3:
					s3 = _taskC.Result;				
					_tcs.SetResult (s1 + s2 + s3);
					return;
			}
		}
		catch (Exception ex)
		{
			_tcs.SetException (ex);
		}
	}
}

Task<string> A() { return Task.Delay (1000).ContinueWith (ant => "A"); }
Task<string> B() { return Task.Delay (1000).ContinueWith (ant => "B"); }
Task<string> C() { return Task.Delay (1000).ContinueWith (ant => "C"); }