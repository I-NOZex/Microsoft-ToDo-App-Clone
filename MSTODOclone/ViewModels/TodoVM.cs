using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databinding.ViewModels;
using MSTODOclone.Models;

namespace MSTODOclone.ViewModels {
    public class TodoVM : BaseVM {

        private ToDoModel _toDoModel;
        public string Name {
            get => _toDoModel.Name;
            set {
                _toDoModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public bool IsDone {
            get => _toDoModel.IsDone;
            set {
                _toDoModel.IsDone = value;
                OnPropertyChanged("IsDone");
            }
        }

        public TodoVM() {
            _toDoModel = new ToDoModel();
        }

    }


    public class EmptyTodoItemVM : TodoVM {
        public bool IsSaved;
    }
}
