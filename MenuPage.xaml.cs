using CoffeeShopApplication.Controls;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoffeeShopApplication;

public partial class MenuPage : ContentPage
{

    private string _selectedCategory;
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (_selectedCategory != value)
            {
                _selectedCategory = value;
                OnPropertyChanged();
                ApplyCategoryFilter();
            }
        }
    }

    public ICommand CategoryTappedCommand => new Command<string>(category =>
    {
        SelectedCategory = category;
    });

    private ObservableCollection<MenuItemModel> _filteredMenuItems;
    public ObservableCollection<MenuItemModel> FilteredMenuItems
    {
        get => _filteredMenuItems;
        set
        {
            _filteredMenuItems = value;
            OnPropertyChanged();
        }
    }

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

            case "Coffee House":
                Theme = new Theme
                {
                    BackgroundColor = Color.FromArgb("#FFFFFF"),
                    PrimaryColor = Color.FromArgb("#D00303"),
                    TextColor = Colors.Black
                };
                Logo = "coffeehouse.png";
                BackgroundImage = "coffeehousebackground.png";
                SetCHData();
                SelectedCategory = Categories.First().Name;
                ApplyCategoryFilter();
                break;
        }
    }

    private void ApplyCategoryFilter()
    {
        if (string.IsNullOrEmpty(SelectedCategory))
        {
            FilteredMenuItems = new ObservableCollection<MenuItemModel>(MenuItems);
        }
        else
        {
            FilteredMenuItems = new ObservableCollection<MenuItemModel>(
                MenuItems.Where(item => item.Category == SelectedCategory)
            );
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

        FilteredMenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Cappuccino", Price = 2000, Image = "gotchacoco.png" },
            new MenuItemModel { Name = "Melon oolong ic...", Price = 2000, Image = "gotchaflower.png" },
            new MenuItemModel { Name = "Americano", Price = 550, Image = "gotchachocko.png" },
            new MenuItemModel { Name = "Latte", Price = 1400, Image = "gotchastraw.png" }
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

        FilteredMenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Cappuccino", Price = 2000, Image = "cappucino.png" },
            new MenuItemModel { Name = "Espresso", Price = 2000, Image = "espresso.png" },
            new MenuItemModel { Name = "Americano", Price = 1550, Image = "ameicano.png" },
            new MenuItemModel { Name = "Latte", Price = 1400, Image = "latte.png" }
        };
    }

    private void SetCHData()
    {
        Categories = new ObservableCollection<CategoryItem>
        {
            new CategoryItem { Name = "Ice Coffee" },
            new CategoryItem { Name = "Tea" },
            new CategoryItem { Name = "Lent Menu" },
            new CategoryItem { Name = "Ice Drinks" },
            new CategoryItem { Name = "Hot Coffee" },
            new CategoryItem { Name = "Sweets" }
        };

        MenuItems = new ObservableCollection<MenuItemModel>
        {
            new MenuItemModel { Name = "Affogato Coffee", Price = 800, Image = "affogato.png", Category = "Ice Coffee" },
            new MenuItemModel { Name = "Raf Strawberry", Price = 1000, Image = "rafstrawberry.png", Category = "Ice Coffee" },
            new MenuItemModel { Name = "Raf", Price = 900, Image = "raf.png", Category = "Ice Coffee" },
            new MenuItemModel { Name = "Latte", Price = 900, Image = "lattech.png", Category = "Ice Coffee" },
            new MenuItemModel { Name = "Spanish Latte", Price = 800, Image = "lattech.png", Category = "Ice Coffee" },

            new MenuItemModel { Name = "Black Tea", Price = 400, Image = "blacktea.png", Category = "Tea" },
            new MenuItemModel { Name = "Winter Punch Tea", Price = 650, Image = "winterpunch.png", Category = "Tea" },
            new MenuItemModel { Name = "Tea Strawberry", Price = 650, Image = "teastrawberry.png", Category = "Tea" },
            new MenuItemModel { Name = "Pomegranate Tea", Price = 650, Image = "pomegranate.png", Category = "Tea" },
            new MenuItemModel { Name = "Imuno Tea", Price = 650, Image = "imunotea.png", Category = "Tea" },
            new MenuItemModel { Name = "Raspberry Tea", Price = 650, Image = "raspberry.png", Category = "Tea" },
            new MenuItemModel { Name = "Ice Tea Cosmo", Price = 450, Image = "cosmo.png", Category = "Ice Drinks" },
            new MenuItemModel { Name = "Citrus Tea", Price = 650, Image = "citrus.png", Category = "Ice Drinks" },

            new MenuItemModel { Name = "Flat White", Price = 900, Image = "flatwhite.png", Category = "Ice Coffee" }
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
