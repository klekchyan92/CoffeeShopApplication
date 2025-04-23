using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CoffeeShopApplication;

public partial class CartPage : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; } = new();
    public ICommand DeleteCommand { get; }

    public CartPage()
    {
        InitializeComponent();
        BindingContext = this;

        CartItems.Add(new CartItem { Image = "affogato.png", Name = "Affogato Coffee", Price = 800, Quantity = 1 });
        CartItems.Add(new CartItem { Image = "flat_white.png", Name = "Flat White", Price = 900, Quantity = 1 });
        DeleteCommand = new Command<CartItem>(OnDeleteItem);

        UpdateTotal();
    }

    private void OnIncreaseQuantityClicked(object sender, EventArgs e)
    {
        if ((sender as Border)?.BindingContext is CartItem item)
        {
            item.Quantity++;
            UpdateTotal();
        }
    }

    private void OnDecreaseQuantityClicked(object sender, EventArgs e)
    {
        if ((sender as Border)?.BindingContext is CartItem item)
        {
            if (item.Quantity > 1)
            {
                item.Quantity--;
                UpdateTotal();
            }
        }
    }

    private void OnDeleteItem(CartItem item)
    {
        if (item != null)
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
