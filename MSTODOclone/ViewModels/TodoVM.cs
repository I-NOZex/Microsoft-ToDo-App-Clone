using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public TodoVM() {
            _toDoModel = new ToDoModel();
        }

    }
}
