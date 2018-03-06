<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Runtime.CompilerServices</Namespace>
</Query>

// Here's a more substantial example that lets us await a WaitHandle:

async Task Main()
{
	var resetEvent = new AutoResetEvent (false);
	new Thread (() => { Thread.Sleep(2000); resetEvent.Set(); }).Start();
	bool noTimeout = await resetEvent;
	noTimeout.Dump();
	
	new Thread (() => { Thread.Sleep(2000); resetEvent.Set(); }).Start();
	noTimeout = await resetEvent.Timeout (500);
	noTimeout.Dump();
}

static class Extensions
{
	public static WaitHandleAwaiter GetAwaiter (this WaitHandle waitHandle)
	{
		return new WaitHandleAwaiter (waitHandle);
	}

	public static WaitHandleAwaiter Timeout (this WaitHandle waitHandle, int timeout)
	{
		return new WaitHandleAwaiter (waitHandle, timeout);
	}

	public class WaitHandleAwaiter : System.Runtime.CompilerServices.INotifyCompletion
	{
		WaitHandle _waitHandle;
		bool _isCompleted;
		int _timeout;
		bool _timedOut;
		
		public WaitHandleAwaiter GetAwaiter () { return this; }
		
		public WaitHandleAwaiter (WaitHandle waitHandle, int timeout = -1)
		{
			_waitHandle = waitHandle;
			_isCompleted = waitHandle.WaitOne (0);
			_timeout = timeout;
		}
	
		public bool IsCompleted { get { return _isCompleted; } }
		
		public void OnCompleted (Action continuation)
		{		
			ThreadPool.RegisterWaitForSingleObject (
				_waitHandle, 
				(state, timedOut) => 
				{
					_timedOut = timedOut; 
					_isCompleted = true; 
					continuation(); 
				}
				, null,
				_timeout, 
				true);
		}
		
		public bool GetResult() { return !_timedOut; }
	}	
}