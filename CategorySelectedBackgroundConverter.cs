using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApplication
{
    public class CategorySelectedBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collectionView = parameter as CollectionView;
            var selected = collectionView?.SelectedItem == value;
            return selected ? Color.FromArgb("#F9A825") : Colors.White; // Оранжевый если выбран
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

}
