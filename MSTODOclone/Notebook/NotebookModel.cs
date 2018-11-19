using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTODOclone.Models {
    public class NotebookModel {
        public enum IconEnum : int {
            Default,
            Star,
            Heart,
        }

        public enum ThemeWatermarkEnum : int {
            Default,
            Travel,
            Groceries,
        }

        public enum ThemeColorEnum : int {
            Default,
            Red,
            Green,
        }


        private string _name;
        private IconEnum _icon;
        private Dictionary<ThemeWatermarkEnum, ThemeColorEnum> _theme;
        private List<ToDoModel> _toDos;

        public string Name {
            get => _name;
            set {
                _name = value;

            }
        }

        public IconEnum Icon {
            get => _icon;
            set {
                _icon = value;

            }
        }

        public Dictionary<ThemeWatermarkEnum, ThemeColorEnum> Theme {
            get => _theme;
            set {
                _theme = value;

            }
        }

        public List<ToDoModel> ToDos {
            get => _toDos;
            set {
                _toDos = value;
            }
        }

        public NotebookModel() {

        }
    }
}
