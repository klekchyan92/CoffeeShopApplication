using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;

namespace CoffeeShopApplication;

public partial class CheckoutPage : ContentPage
{
    public ObservableCollection<CartItem> CartItems { get; set; } = new();
    public ObservableCollection<PaymentMethod> PaymentMethods { get; set; } = new();

    public PaymentMethod SelectedPaymentMethod { get; set; }
    public bool IsPaymentMethodsExpanded { get; set; }
    public string ExpandIcon => IsPaymentMethodsExpanded ? "arrow_up.png" : "arrow_down.png";

    public CheckoutPage()
    {
        InitializeComponent();
        BindingContext = this;

        CartItems.Add(new CartItem { Image = "affogato_coffee.png", Name = "Affogato Coffee", Price = 800, Quantity = 1 });
        CartItems.Add(new CartItem { Image = "flat_white.png", Name = "Flat White", Price = 900, Quantity = 1 });

        PaymentMethods.Add(new PaymentMethod { Name = "ApplePay", Icon = "applepay_icon.png" });
        PaymentMethods.Add(new PaymentMethod { Name = "VISA/MasterCard", Icon = "visa_icon.png" });
        PaymentMethods.Add(new PaymentMethod { Name = "Cash", Icon = "cash_icon.png" });

        SelectedPaymentMethod = PaymentMethods.First();
        UpdateTotal();
    }

    private void OnExpandPaymentMethodsClicked(object sender, EventArgs e)
    {
        IsPaymentMethodsExpanded = !IsPaymentMethodsExpanded;
        OnPropertyChanged(nameof(IsPaymentMethodsExpanded));
        OnPropertyChanged(nameof(ExpandIcon));
    }

    private void OnPaymentMethodSelected(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is PaymentMethod selected)
        {
            SelectedPaymentMethod = selected;
            IsPaymentMethodsExpanded = false;
            OnPropertyChanged(nameof(SelectedPaymentMethod));
            OnPropertyChanged(nameof(IsPaymentMethodsExpanded));
            OnPropertyChanged(nameof(ExpandIcon));
        }
    }

    private void OnCreateOrderClicked(object sender, EventArgs e)
    {
    }

    private void UpdateTotal()
    {
        var total = CartItems.Sum(x => x.Price * x.Quantity);
        TotalLabel.Text = $"Total: {total} AMD";
    }
}
