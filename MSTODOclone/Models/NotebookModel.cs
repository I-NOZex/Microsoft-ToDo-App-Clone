using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSTODOclone.Models {
    class NotebookModel {
        private string _name;
        public string Name {
            get => _name;
            set {
                _name = value;

            }
        }

        private List<ToDoModel> _toDos;
        public List<ToDoModel> ToDos {
            get => _toDos;
            set {
                _toDos = value;
            }
        }
    }
}
