using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MSTODOclone.Helpers {
    class ListViewItemTemplateSelector : StyleSelector {

        public Style GeneralListViewItemTemplateSelector { get; set; }
        public Style LastListViewItemTemplateSelector { get; set; }


        protected override Style SelectStyleCore(object item, DependencyObject container) {
            var lv = GetListView(container);
            if (lv != null) {
                var i = lv.Items.IndexOf(item);
                if (i < lv.Items.Count - 1) {
                    return GeneralListViewItemTemplateSelector;
                }

                return LastListViewItemTemplateSelector;

            }
            return LastListViewItemTemplateSelector;

        }

        public static ListView GetListView(DependencyObject element) {
            var parent = VisualTreeHelper.GetParent(element);
            if (parent == null) {
                return null;
            }
            var parentListView = parent as ListView;
            return parentListView ?? GetListView(parent);
        }
    }
}
