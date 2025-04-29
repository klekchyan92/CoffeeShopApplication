using CoffeeShopApplication.Controls;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class MenuPage : ContentPage
{
    public Theme Theme { get; set; }
    public string Logo { get; set; }
    public string BackgroundImage { get; set; }
    public ObservableCollection<MenuItemModel> MenuItems { get; set; }
    public ObservableCollection<CategoryItem> Categories { get; set; }

    public string CafeName { get; }

    public MenuPage(string cafeName)
    {
        CafeName = cafeName;
        InitializeComponent();

        SetupPage();
        BindingContext = this;
    }

    private void SetupPage()
    {
        switch (CafeName)
        {
            case "Prepa":
                Theme = new Theme
                {
                    BackgroundColor = Color.FromArgb("#FFF6EF"),
                    PrimaryColor = Color.FromArgb("#F2994A"),
                    TextColor = Colors.Black
                };
                Logo = "prepa.png";
                BackgroundImage = "prepabackground.png";
                SetPrepaData();
                break;

            case "Gotcha":
                Theme = new Theme
                {
                    BackgroundColor = Color.FromArgb("#FFF1F7"),
                    PrimaryColor = Color.FromArgb("#FF9DBB"),
                    TextColor = Colors.Black
                };
                Logo = "gotcha.png";
                BackgroundImage = "gotchabackground.png";
                SetGotchaData();
                break;
        }
    }

    private void SetGotchaData()
    {

        Categories = new ObservableCollection<CategoryItem>
        {
            new CategoryItem { Name = "Spring specials" },
            new CategoryItem { Name = "Gotcha specials" },
            new CategoryItem { Name = "Coffee"},
            new CategoryItem { Name = "Fresh fruit tea"},
            new CategoryItem { Name = "Smoothie"}
        };

        MenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Cappuccino", Price = 2, Image = "gotchacoco.png" },
            new MenuItemModel { Name = "Melon oolong ic...", Price = 2, Image = "gotchaflower.png" },
            new MenuItemModel { Name = "Americano", Price = 2.55, Image = "gotchachocko.png" },
            new MenuItemModel { Name = "Latte", Price = 4, Image = "gotchastraw.png" }
        };
    }

    private void SetPrepaData()
    {
        Categories = new ObservableCollection<CategoryItem>
        {
            new CategoryItem { Name = "Beverages" },
            new CategoryItem { Name = "Bowls" },
            new CategoryItem { Name = "Breakfast" },
            new CategoryItem { Name = "Cold Press Juices" },
            new CategoryItem { Name = "Desserts"}
        };

        MenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Cappuccino", Price = 2, Image = "cappucino.png" },
            new MenuItemModel { Name = "Espresso", Price = 2, Image = "espresso.png" },
            new MenuItemModel { Name = "Americano", Price = 2.55, Image = "ameicano.png" },
            new MenuItemModel { Name = "Latte", Price = 4, Image = "latte.png" }
        };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Shell.SetTabBarIsVisible(this, true);
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
