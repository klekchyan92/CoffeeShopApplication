using Microsoft.Maui.Controls.PlatformConfiguration;
using System.ComponentModel;
#if ANDROID
using Android.Views;
using AndroidX.Core.View;
#endif

namespace CoffeeShopApplication
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _phone;

        public string Phone
        {
            get => _phone;
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
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

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // Ensure user is authenticated here (if not already handled)
            // e.g., if (!AuthService.Login(username, password)) return;

            // Replace the MainPage with AppShell if it's not already initialized
            if (App.Current.MainPage is not AppShell)
            {
                App.Current.MainPage = new AppShell();
            }

            if (Name != "Yeva" || Phone != "098806222")
                return;

            // Navigate to the Shop List page (home tab)
            await Shell.Current.GoToAsync("//shoplist");
        }


        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//shoplist");
        }


    }
}
