using ListApp.Data;
using ListApp.Models;

namespace ListApp;

[QueryProperty(nameof(ProdId), "prodid")]
public partial class ItemPage : ContentPage
{
    ProductsDatabase db;

    Product prod;// = new Product();

    public int ProdId
    {
        set
        {
           LoadProd(value);           
        }
    }


    private async void LoadProd(int id)
    {
        prod = await db.GetProductAsync(id);
        BindingContext = prod;
        btnDelete.IsVisible = true;
    }

    public ItemPage(ProductsDatabase _db)
    {
        InitializeComponent();
        db = _db;
        prod = new Product();
        BindingContext = prod;
       // btnDelete.IsVisible = false;
    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        prod = (Product) BindingContext;
        await db.SaveProductAsync(prod);
        await Shell.Current.GoToAsync("..");
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void btnDelete_Clicked(object sender, EventArgs e)
    {
        var prod = (Product) BindingContext;
        if (prod.Id == 0)
            return;

        bool answer = await DisplayAlert("Question?", $"Are you sure to delete {prod.Name}", "Yes", "No");

        if (answer)
        {
            await db.DeleteProductAsync(prod);
            await Shell.Current.GoToAsync("..");
        }

    }
}