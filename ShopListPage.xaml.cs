using CoffeeShopApplication.Controls;
#if ANDROID
using Android.Views;
using AndroidX.Core.View;
#endif

namespace CoffeeShopApplication;

public partial class ShopListPage : ContentPage
{
	public ShopListPage()
	{
		InitializeComponent();
	}

    private async void OnArrowTapped(object sender, EventArgs e)
    {
        var theme = new Theme
        {
            PrimaryColor = Colors.Orange,
            SecondaryColor = Colors.DarkOrange,
            BackgroundColor = Colors.White,
            TextColor = Colors.Black
        };

        await Navigation.PushAsync(new MenuPage(theme));

        //await Navigation.PushAsync(new CoffeeDetailsPage());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

#if ANDROID
        var window = Platform.CurrentActivity?.Window;
        if (window != null)
        {
            window.ClearFlags(WindowManagerFlags.LayoutNoLimits);
        }
#endif
    }
}