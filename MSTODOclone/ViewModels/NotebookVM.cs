using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databinding.ViewModels;
using MSTODOclone.Models;

namespace MSTODOclone.ViewModels {
    public class NotebookVM : BaseVM {
        private NotebookModel _notebookModel;
        public string Name {
            get => _notebookModel.Name;
            set {
                _notebookModel.Name = value;
                OnPropertyChanged("Name");
            }
        }

        private ObservableCollection<TodoVM> _toDos;
        public ObservableCollection<TodoVM> ToDos {
            get => _toDos;
            set {
                _toDos = value;
                OnPropertyChanged("ToDos");
            }
        }

        public NotebookVM() {
            _notebookModel = new NotebookModel();
            ToDos = new ObservableCollection<TodoVM>();
        }
    }
}
