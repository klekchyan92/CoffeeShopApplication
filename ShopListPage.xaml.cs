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
        if (sender is Image image && image.GestureRecognizers.FirstOrDefault() is TapGestureRecognizer tap &&
            tap.CommandParameter is string cafeName)
        {
            await Navigation.PushAsync(new MenuPage(cafeName));
        }

        //await Navigation.PushAsync(new CoffeeDetailsPage());
    }

    async void OnHelpClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ChatPage());
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