using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace MSTODOclone.Helpers {
    class Bool2VisibilityConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            if (value is FocusState) {
                bool inverted = false;
                if (parameter != null && parameter.ToString().Contains("InvertBool"))
                    inverted = true;
                return ((!inverted && ((FocusState)value == FocusState.Unfocused))  || (inverted && ((FocusState)value) != FocusState.Unfocused)) ? Visibility.Collapsed : Visibility.Visible;
            }
            throw new InvalidCastException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }
}
