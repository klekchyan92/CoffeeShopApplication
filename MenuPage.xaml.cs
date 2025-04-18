using CoffeeShopApplication.Controls;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class MenuPage : ContentPage
{
    public Theme Theme { get; set; }
    private ObservableCollection<MenuItemModel> _menuItems;
    private ObservableCollection<CategoryItem> _categories;
    public ObservableCollection<MenuItemModel> MenuItems
    {
        get => _menuItems;
        set
        {
            if (_menuItems != value)
            {
                _menuItems = value;
                OnPropertyChanged();
            }
        }
    }

    public ObservableCollection<CategoryItem> Categories
    {
        get => _categories;
        set
        {
            if (_categories != value)
            {
                _categories = value;
                OnPropertyChanged();
            }
        }
    }


    public MenuPage(Theme theme)
    {
        InitializeComponent();
        Theme = theme;
        Categories = new ObservableCollection<CategoryItem>
        {
            new CategoryItem { Name = "Beverages"},
            new CategoryItem { Name = "Bowls", Icon = "bowls_icon.png" },
            new CategoryItem { Name = "Breakfast", Icon = "breakfast_icon.png" },
            new CategoryItem { Name = "Cold Press Juices", Icon = "coldpress_icon.png" },
            new CategoryItem { Name = "Desserts", Icon = "desserts_icon.png" }
        };

        MenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Cappuccino", Price = 2, Image = "cappucino.png" },
            new MenuItemModel { Name = "Espresso", Price = 2, Image = "cappucino.png" },
            new MenuItemModel { Name = "Americano", Price = 2.55, Image = "cappucino.png" },
            new MenuItemModel { Name = "Latte", Price = 4, Image = "cappucino.png" }
        };

        BindingContext = this;
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}
