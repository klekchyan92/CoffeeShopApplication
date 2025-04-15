using CoffeeShopApplication.Controls;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class FavoritePage : ContentPage
{
    public FavoritePage(string activeTab)
    {
        TabService.CurrentActiveTab = activeTab;
        InitializeComponent();
    }

    private ObservableCollection<MenuItemModel> _menuItems;

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

   
}
