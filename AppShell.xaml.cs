namespace CoffeeShopApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            ShowSplashScreen();
        }

        private async void ShowSplashScreen()
        {
            await GoToAsync("MainPage");
        }
    }
}
