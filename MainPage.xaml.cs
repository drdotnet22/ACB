namespace ACB;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
        webView.Navigating += WebView_Navigating;
	}

    private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
    {
        Uri requestedUri = new Uri(e.Url);
        //Uri allowedDomain = new Uri("https://codeblocks.olivetree.software/");
        //Uri allowedDomain = new Uri("https://discourse.northeastmennonite.com/");
        Uri allowedDomain = new Uri("https://www.usps.com/");

        bool allowInApp = (requestedUri.Host.Substring(requestedUri.Host.Length - 8) == allowedDomain.Host.Substring(allowedDomain.Host.Length - 8));
        if (!allowInApp)
        {
            e.Cancel = true;
            LaunchBrowser(e.Url);
        }
    }

    private async void LaunchBrowser(string url)
    {
        if (await Launcher.CanOpenAsync(url))
        {
            await Launcher.OpenAsync(url);
        }
        else
        {
            await DisplayAlert("Error", "Unable to open the link in the default browser.", "OK");
        }
    }
}

