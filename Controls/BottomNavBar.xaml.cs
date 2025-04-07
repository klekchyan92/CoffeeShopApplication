namespace CoffeeShopApplication.Controls;

public partial class BottomNavBar : ContentView
{
    public BottomNavBar()
    {
        InitializeComponent();
        BindingContext = this;
        SetActiveTab("Home"); // default
    }

    public void SetActiveTab(string tab)
    {
        HomeColor = tab == "Home" ? Color.FromArgb("#CB8A58") : Colors.Gray;
        FavouriteColor = tab == "Favourite" ? Color.FromArgb("#CB8A58") : Colors.Gray;
        CartColor = tab == "Cart" ? Color.FromArgb("#CB8A58") : Colors.Gray;
        ProfileColor = tab == "Profile" ? Color.FromArgb("#CB8A58") : Colors.Gray;

        HomeIcon = tab == "Home" ? "vector.png" : "vectorwhite.png.png";
        FavouriteIcon = tab == "Favourite" ? "favourite_icon_active.png" : "favourite_icon.png";
        CartIcon = tab == "Cart" ? "cart_icon_active.png" : "cart_icon.png";
        ProfileIcon = tab == "Profile" ? "profile_icon_active.png" : "profile_icon.png";
        HelpIcon =  "help_icon.png";

        OnPropertyChanged(nameof(HomeColor));
        OnPropertyChanged(nameof(FavouriteColor));
        OnPropertyChanged(nameof(CartColor));
        OnPropertyChanged(nameof(ProfileColor));
        OnPropertyChanged(nameof(HomeIcon));
        OnPropertyChanged(nameof(FavouriteIcon));
        OnPropertyChanged(nameof(CartIcon));
        OnPropertyChanged(nameof(ProfileIcon));
        OnPropertyChanged(nameof(HelpIcon));
    }

    // Properties
    public Color HomeColor { get; set; }
    public Color FavouriteColor { get; set; }
    public Color CartColor { get; set; }
    public Color ProfileColor { get; set; }

    public string HomeIcon { get; set; }
    public string FavouriteIcon { get; set; }
    public string CartIcon { get; set; }
    public string ProfileIcon { get; set; }

    public string HelpIcon { get; set; }

    // Navigation (example)
    void OnHomeClicked(object sender, EventArgs e) => Shell.Current.GoToAsync("//home");
    void OnFavouriteClicked(object sender, EventArgs e) => Shell.Current.GoToAsync("//favourite");
    void OnHelpClicked(object sender, EventArgs e) => Shell.Current.GoToAsync("//help");
    void OnCartClicked(object sender, EventArgs e) => Shell.Current.GoToAsync("//cart");
    void OnProfileClicked(object sender, EventArgs e) => Shell.Current.GoToAsync("//profile");
}
