using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoffeeShopApplication;

public partial class FavoritePage : ContentPage
{
    public ObservableCollection<MenuItemModel> MenuItems { get; set; }

    public FavoritePage()
    {
        InitializeComponent();
        TabService.CurrentActiveTab = "Favourite";

        MenuItems = new ObservableCollection<MenuItemModel>();

        //AddItem("Melon Oolong Iced Tea", 2350, "melon_oolong.png");
        AddItem("Chicken Bowl", 3000, "chicken_bowl.png");
        AddItem("Affogato Coffee", 800, "affogato.png");
        AddItem("Flat White", 900, "flat_white.png");

        void AddItem(string name, int price, string image)
        {
            var item = new MenuItemModel
            {
                Name = name,
                Price = price,
                Image = image
            };

            item.DeleteCommand = new Command(() => OnDelete(item));
            MenuItems.Add(item);
        }

        BindingContext = this;
    }

    private void OnDelete(MenuItemModel item)
    {
        if (MenuItems.Contains(item))
            MenuItems.Remove(item);
    }

}
