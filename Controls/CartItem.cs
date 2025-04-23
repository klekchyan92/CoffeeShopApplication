using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CoffeeShopApplication.Controls
{
    public class CartItem : INotifyPropertyChanged
    {
        private int _quantity;

        public string Image { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
