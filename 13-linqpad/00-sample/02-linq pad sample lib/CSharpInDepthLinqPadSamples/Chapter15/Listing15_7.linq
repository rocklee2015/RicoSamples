<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Drawing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
  <Namespace>System.Drawing</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows.Forms</Namespace>
</Query>

void Main()
{
    Task task = ThrowCancellationException();
    Console.WriteLine(task.Status);    
}

static async Task ThrowCancellationException()
{
    throw new OperationCanceledException();
}
