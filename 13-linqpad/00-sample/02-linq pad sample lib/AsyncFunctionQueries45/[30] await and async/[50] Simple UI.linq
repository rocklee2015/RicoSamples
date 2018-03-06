<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
</Query>

// OK, time for a UI! Let's wrap what we just wrote into a simple WPF application. You'll
// notice that our UI remains responsive while downloading web pages - and that exceptions
// flow nicely from the asynchronous method to our catch block. In fact, our program
// follows the same structure as if it were SYNCHRONOUS - but we don't need any threads!

void Main()
{
	new DownloadWindow().Show();
}

class DownloadWindow : Window
{
	Button btnGo = new Button { Content = "Go!", Margin = new Thickness (5) };
	TextBlock txtResult = new TextBlock { Margin = new Thickness (5) };
	StackPanel stackPanel = new StackPanel();

	public DownloadWindow()
	{
		InitializeComponent();
	}
	
	async void btnGo_Click (object sender, EventArgs args)
	{
		btnGo.IsEnabled = false;
		txtResult.Text = "Working...";
		try
		{
			string[] uris =
			{
				"http://linqpad.net",
				"http://linqpad.net/downloadglyph.png",
				"http://linqpad.net/linqpadscreen.png",
				"http://linqpad.net/linqpadmed.png",
			};
			int totalLength = 0;
			foreach (string uri in uris)
			{
				string html = await new WebClient().DownloadStringTaskAsync (new Uri (uri));
				// A nice feature of await is that we end up back on the UI thread after awaiting. This
				// is possible due to the synchronization context that WPF creates for us automatically.
				txtResult.Text = "Downloaded " + uri + "...";
				totalLength += html.Length;
			}
			txtResult.Text = "Total length is: " + totalLength + " characters";
		}
		catch (Exception ex)     // Any errors from async operations get caught here
		{
			txtResult.Text = "Error: " + ex.Message;
		}
		finally        // This runs when the method finishes for good - or if we return early
		{
			btnGo.IsEnabled = true;
		}
	}
	
	void InitializeComponent()
	{
		btnGo.Click += btnGo_Click;
		Width = Height = 400;
		Padding = new Thickness (15);
		stackPanel.Children.Add (btnGo);
		stackPanel.Children.Add (txtResult);
		Content = stackPanel;
	}
}