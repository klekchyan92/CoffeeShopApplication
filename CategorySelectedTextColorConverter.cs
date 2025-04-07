using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopApplication
{
    public class CategorySelectedTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var collectionView = parameter as CollectionView;
            var selected = collectionView?.SelectedItem == value;
            return selected ? Colors.White : Colors.Brown; // Белый если выбран, коричневый если нет
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }

}
