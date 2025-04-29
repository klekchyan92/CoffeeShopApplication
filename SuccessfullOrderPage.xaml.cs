namespace CoffeeShopApplication;
#if ANDROID
using Android.Views;
using AndroidX.Core.View;
#endif

public partial class SuccessfullOrderPage : ContentPage
{
	public SuccessfullOrderPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SetStatusBarAndNavigationBarColors();
    }

    private void SetStatusBarAndNavigationBarColors()
    {
#if ANDROID
            
                    var window = Platform.CurrentActivity!.Window;

                    if (window is not null)
                    {
                        // Статусбар и Навбар полностью прозрачные
                        window.SetStatusBarColor(Android.Graphics.Color.Transparent);
                        window.SetNavigationBarColor(Android.Graphics.Color.Transparent);

                        // Контент заходит под системные панели
                        WindowCompat.SetDecorFitsSystemWindows(window, false);

                        // Флаг: рисовать поверх всех системных панелей
                        window.AddFlags(WindowManagerFlags.LayoutNoLimits);

                        // Контроллер системных баров
                        var controller = WindowCompat.GetInsetsController(window, window.DecorView);
                        if (controller != null)
                        {
                            controller.AppearanceLightStatusBars = false; // Светлые иконки наверху
                            controller.AppearanceLightNavigationBars = false; // Светлые иконки внизу
                        }
                    }
#endif
    }

    private async void OnBackToHomeClicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}