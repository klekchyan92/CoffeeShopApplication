namespace CoffeeShopApplication;

public partial class AnimatedSplashPage : ContentPage
{
	public AnimatedSplashPage()
	{
		InitializeComponent();
        StartTimer();
    }

    private async void StartTimer()
    {
        await Task.Delay(5000);
        await Navigation.PushAsync(new MainPage());
    }
}