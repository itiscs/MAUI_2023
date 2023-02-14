namespace MauiAppFirst;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("secondpage", typeof(SecondPage));
    }
}
