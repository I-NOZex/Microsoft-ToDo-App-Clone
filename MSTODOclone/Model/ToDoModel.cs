using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTODOclone {

    public class TodoItem {

        private string _name;
        private bool _isDone;


        public string Name {
            get => _name;
            set {
                _name = value;
            }
        }

        public bool IsDone {
            get; set;
        }

        public TodoItem() {

        }

    }

    public class EmptyTodoItem : TodoItem {
        public bool IsSaved;
    }


}
