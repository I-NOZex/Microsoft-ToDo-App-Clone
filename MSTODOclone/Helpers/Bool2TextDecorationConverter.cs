using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MSTODOclone.Helpers {
    class Bool2TextDecorationConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is bool) {
                bool inverted = false;
                if (parameter != null)
                    return (bool) value ? parameter : "";
            }
            throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
