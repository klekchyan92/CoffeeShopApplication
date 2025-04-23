using CoffeeShopApplication.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CoffeeShopApplication;

public partial class CheckoutPage : ContentPage, INotifyPropertyChanged
{
    public ObservableCollection<CartItem> CartItems { get; set; } = new();
    public ObservableCollection<PaymentMethod> PaymentMethods { get; set; } = new();

    private PaymentMethod _selectedPaymentMethod;
    public PaymentMethod SelectedPaymentMethod
    {
        get => _selectedPaymentMethod;
        set
        {
            if (_selectedPaymentMethod != value)
            {
                _selectedPaymentMethod = value;
                OnPropertyChanged(nameof(SelectedPaymentMethod));
            }
        }
    }

    public bool IsPaymentMethodsExpanded { get; set; }
    public string ExpandIcon => IsPaymentMethodsExpanded ? "arrow_up.png" : "arrow_down.png";

    public CheckoutPage()
    {
        InitializeComponent();
        BindingContext = this;

        CartItems.Add(new CartItem { Image = "affogato.png", Name = "Affogato Coffee", Price = 800, Quantity = 1 });
        CartItems.Add(new CartItem { Image = "flat_white.png", Name = "Flat White", Price = 900, Quantity = 1 });

        PaymentMethods.Add(new PaymentMethod { Name = "ApplePay", Icon = "applepay.png" });
        PaymentMethods.Add(new PaymentMethod { Name = "VISA/MasterCard", Icon = "mastercard.png" });
        PaymentMethods.Add(new PaymentMethod { Name = "Cash", Icon = "cash.png" });

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

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    private void OnCreateOrderClicked(object sender, EventArgs e)
    {
    }

    private void UpdateTotal()
    {
        var total = CartItems.Sum(x => x.Price * x.Quantity);
        TotalLabel.Text = $"Total: {total} AMD";
    }

    private void OnDecreaseQuantityTapped(object sender, EventArgs e)
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

    private void OnIncreaseQuantityTapped(object sender, EventArgs e)
    {
        if ((sender as Border)?.BindingContext is CartItem item)
        {
            item.Quantity++;
            UpdateTotal();
        }
    }
}
