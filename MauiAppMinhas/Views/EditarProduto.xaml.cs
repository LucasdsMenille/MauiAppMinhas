using MauiAppMyShopping.Models;

namespace MauiAppMinhas.Views;

public partial class EditProduct : ContentPage
{
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Product anexedProduct = BindingContext as Product;

            object productDescriptionTxt = null;
            Product product = new Product
            {
                Id = anexedProduct.Id,
                Description = productDescriptionTxt.Text,
                Amount = Convert.ToInt16(productAmountTxt.Text),
                Price = Convert.ToDouble(productUnitPrice.Text)
            };

            await App.Database.Update(product);

            await DisplayAlert("Updated", "Success", "OK");

            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("OPS!", ex.Message, "OK");
        }
    }
}