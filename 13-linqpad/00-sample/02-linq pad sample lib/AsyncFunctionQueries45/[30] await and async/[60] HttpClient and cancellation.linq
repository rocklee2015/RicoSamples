<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\Accessibility.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationCore.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\WPF\PresentationFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\PresentationUI.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\ReachFramework.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Deployment.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\System.Printing.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Xaml.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationProvider.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\UIAutomationTypes.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\wpf\WindowsBase.dll</Reference>
  <Namespace>System.ComponentModel</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Windows</Namespace>
  <Namespace>System.Windows.Controls</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

// Rather than using WebClient to download the data, you can use Framework 4.5's new
// HttpClient class. HttpClient was designed in response to the growth of HTTP-based web
// APIs and REST services, to provide a better experience than WebClient when dealing with
// protocols more elaborate than simply fetching a web page.

// In this example, we're calling an overload of GetAsync on HttpClient which accepts
// a CancellationToken. This is the same CancellationToken introduced in Framework 4.0,
// and lets us cancel the request part-way through.

void Main()
{
	new DownloadWindow().Show();
}

class DownloadWindow : Window
{
	Button btnGo = new Button { Content = "Go!", Margin = new Thickness (5) };
	Button btnCancel = new Button { Content = "Cancel", Margin = new Thickness (5), IsEnabled = false };
	TextBlock txtResult = new TextBlock { Margin = new Thickness (5) };
	StackPanel stackPanel = new StackPanel();
	CancellationTokenSource cancelSource;

	public DownloadWindow()
	{
		InitializeComponent();
	}
	
	async void btnGo_Click (object sender, EventArgs args)
	{
		btnGo.IsEnabled = false;
		btnCancel.IsEnabled = true;
		cancelSource = new CancellationTokenSource();
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
			var client = new HttpClient();
			foreach (string uri in uris)
			{
				var response = await client.GetAsync (uri, cancelSource.Token);
				response.EnsureSuccessStatusCode();
				string html = await response.Content.ReadAsStringAsync();
				txtResult.Text = "Downloaded " + uri + "...";
				totalLength += html.Length;
			}
			txtResult.Text = "Total length is: " + totalLength + " characters";
		}
		catch (OperationCanceledException)		
		{
			txtResult.Text = "Canceled!";
		}
		catch (Exception ex)
		{
			txtResult.Text = "Error: " + ex.Message;
		}
		finally
		{
			btnGo.IsEnabled = true;
			btnCancel.IsEnabled = false;
		}
	}
	
	void InitializeComponent()
	{
		btnGo.Click += btnGo_Click;
		btnCancel.Click += (sender, args) => cancelSource.Cancel();
		Width = Height = 400;
		Padding = new Thickness (15);
		stackPanel.Children.Add (btnGo);
		stackPanel.Children.Add (btnCancel);
		stackPanel.Children.Add (txtResult);
		Content = stackPanel;
	}
}