using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;

namespace CoffeeShopApplication;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (handler, view) =>
        {
#if ANDROID
            handler.PlatformView.Background = null;
#endif
        });

        SetStatusBarAndNavigationBarColors();
    }

    private void SetStatusBarAndNavigationBarColors()
    {
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
    }
}


