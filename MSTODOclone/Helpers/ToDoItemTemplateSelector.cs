using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace MSTODOclone.Helpers {
    class ToDoItemTemplateSelector : DataTemplateSelector {
        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container) {
            var lv = GetListView(container);
            if (lv != null) {
                var i = lv.Items.IndexOf(item);
                if (i < lv.Items.Count - 1) {
                    return GeneralToDoItemTemplate;
                }

                return NewToDoItemTemplate;
                
            }
            return NewToDoItemTemplate;
        }

        public DataTemplate GeneralToDoItemTemplate { get; set; }
        public DataTemplate NewToDoItemTemplate { get; set; }

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
