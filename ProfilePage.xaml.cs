using System.ComponentModel;

namespace CoffeeShopApplication;

public partial class ProfilePage : ContentPage, INotifyPropertyChanged
{
    private bool _isPushEnabled;

    public bool IsPushEnabled
    {
        get => _isPushEnabled;
        set
        {
            if (_isPushEnabled != value)
            {
                _isPushEnabled = value;
                OnPropertyChanged();
            }
        }
    }

    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = this;
        IsPushEnabled = true; // or load from user settings
    }

    private void OnEditProfileClicked(object sender, EventArgs e)
    {
        // Navigate to edit profile page
    }

    private void OnBankCardsClicked(object sender, EventArgs e)
    {
        // Navigate to bank cards
    }

    private void OnOrderHistoryClicked(object sender, EventArgs e)
    {
        // Navigate to orders
    }

    private void OnLanguageClicked(object sender, EventArgs e)
    {
        // Open language selection
    }

    private void OnLogoutClicked(object sender, TappedEventArgs e)
    {
        App.Current.MainPage = new NavigationPage(new MainPage());
    }
}
