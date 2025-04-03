namespace CoffeeShopApplication;

public partial class ShopListPage : ContentPage
{
	public ShopListPage()
	{
		InitializeComponent();
	}

    private async void OnArrowTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CoffeeDetailsPage());
    }
}