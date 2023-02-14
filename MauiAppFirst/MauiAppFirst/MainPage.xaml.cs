namespace MauiAppFirst;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		lblHello.Text = "New hello";

		Random r = new Random();
		lblHello.TextColor = Color.FromRgb(r.Next(255), r.Next(255), r.Next(255));

		var box = new BoxView()
		{
			HeightRequest = 100,
			WidthRequest = 100,
			Color = Color.FromRgb(r.Next(255), r.Next(255), r.Next(255))
        };

		stk.Children.Add(box);

	}

    private void btnNext_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("secondpage");
    }
}

