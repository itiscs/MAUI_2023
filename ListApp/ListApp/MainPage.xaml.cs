using ListApp.Data;
using ListApp.Models;

namespace ListApp;

public partial class MainPage : ContentPage
{
	//int count = 0;
	ProductsDatabase db;

	public MainPage(ProductsDatabase _db)
	{
		InitializeComponent();
		db = _db;
	}


    protected override async void OnAppearing()
    {
		lstProducts.ItemsSource = await db.GetProductsAsync();	

        base.OnAppearing();
    }

    

    private void btnAdd_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("itempage");
    }

    private void lstProducts_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var id = (e.Item as Product).Id;
        Shell.Current.GoToAsync($"itempage?prodid={id}");
    }
}

