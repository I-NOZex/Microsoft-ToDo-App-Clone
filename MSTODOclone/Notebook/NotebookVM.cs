using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using databinding.ViewModels;
using MSTODOclone.Models;
using Newtonsoft.Json;

namespace MSTODOclone.ViewModels {
    public class NotebookVM : BaseVM {

        [JsonIgnore]
        public RelayCommand SaveMethod;

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
                // We need to know when the ObservableCollection has changed.
                // On added to-dos: hook up eventhandlers to their PropertyChanged events.
                // On removed to-dos: recalculate the total.
                _toDos.CollectionChanged += (sender, e) =>
                {
                    if (e.NewItems != null)
                        AttachToDosChangedEventHandler(e.NewItems.Cast<TodoVM>());
                    else if (e.OldItems != null)
                        CalculateTotalTodo();
                };

                CalculateTotalTodo();
            }
        }

        [JsonIgnore]
        public int TotalToDo {
            get =>  CalculateTotalTodo();
        }

        public NotebookVM() {
            _notebookModel = new NotebookModel();
            ToDos = new ObservableCollection<TodoVM>();
        }

        private void AttachToDosChangedEventHandler(IEnumerable<TodoVM> toDos) {
            // Attach eventhandler for each products PropertyChanged event.
            // When the IsDone property has changed, recalculate the total.
            foreach (var td in toDos) {
                td.PropertyChanged += (sender, e) => {
                    if (e.PropertyName == "IsDone") {
                        Debug.WriteLine("«IsDone» changed");
                        SaveMethod?.Execute(null);
                        CalculateTotalTodo();
                    }
                };
            }

            CalculateTotalTodo();
        }


        public int CalculateTotalTodo() {
            OnPropertyChanged("TotalToDo");
            return ToDos.Count(o => !o.IsDone && o.GetType() == typeof(TodoVM));
        }

        public void InsertToDo(TodoVM toDo) {
            OnPropertyChanged("TotalToDo");
            ToDos.Insert(ToDos.IndexOf(ToDos.Last()), toDo);
        }

    }
}
