using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CoffeeShopApplication.Controls
{
    // Make sure this is included

    public class MenuItemModel : INotifyPropertyChanged
    {
        private string _name;
        private double _price;
        private string _image;
        private bool _isFavorite;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(); // Notify that Name has changed
                }
            }
        }

        public double Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    OnPropertyChanged(); // Notify that Price has changed
                }
            }
        }

        public string Image
        {
            get => _image;
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged(); // Notify that Image has changed
                }
            }
        }

        public bool IsFavorite
        {
            get => _isFavorite;
            set
            {
                if (_isFavorite != value)
                {
                    _isFavorite = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FavoriteImage));
                }
            }
        }

        public string FavoriteImage => IsFavorite ? "ic_roundfavoriteyellow.png" : "ic_roundfavorite.png";

        public ICommand ToggleFavoriteCommand => new Command(() => IsFavorite = !IsFavorite);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand DeleteCommand { get; set; }

    }
}

