using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class CartPage : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; } = new();

    public CartPage()
    {
        InitializeComponent();
        BindingContext = this;

        CartItems.Add(new CartItem { Image = "affogato_coffee.png", Name = "Affogato Coffee", Price = 800, Quantity = 1 });
        CartItems.Add(new CartItem { Image = "flat_white.png", Name = "Flat White", Price = 900, Quantity = 1 });

        UpdateTotal();
    }

    private void OnIncreaseQuantityClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is CartItem item)
        {
            item.Quantity++;
            UpdateTotal();
        }
    }

    private void OnDecreaseQuantityClicked(object sender, EventArgs e)
    {
        if ((sender as Button)?.BindingContext is CartItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                UpdateTotal();
            }
        }
    }

    private void OnDeleteItemClicked(object sender, EventArgs e)
    {
        if ((sender as ImageButton)?.BindingContext is CartItem item)
        {
            CartItems.Remove(item);
            UpdateTotal();
        }
    }

    private async void OnCheckoutClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CheckoutPage());
    }

    private void UpdateTotal()
    {
        var total = CartItems.Sum(x => x.Price * x.Quantity);
        TotalLabel.Text = $"Total: {total} AMD";
    }
}
