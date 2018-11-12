using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using databinding.ViewModels;
using MSTODOclone.Data;
using MSTODOclone.Models;

namespace MSTODOclone.ViewModels {


    public class MainVM : BaseVM {
        private ObservableCollection<NotebookVM> _notebooks = new ObservableCollection<NotebookVM>();
        public ObservableCollection<NotebookVM> Notebooks {
            get => _notebooks;
            set {
                _notebooks = value;
                OnPropertyChanged("Notebooks");
            }
        }


        private NotebookVM _activeNotebook;
        public NotebookVM ActiveNotebook {
            get {

                return _activeNotebook;
            }
            set {
                    _activeNotebook = value;
                OnPropertyChanged("ActiveNotebook");
            }
        }

        public RelayCommand AddNewToDo { get; set; }


        public MainVM() {
            Notebooks = InitalCatalog.SetInitialNotebooksData();
            ActiveNotebook = Notebooks.FirstOrDefault();
            ActiveNotebook.ToDos.Add(
                new EmptyTodoItemVM() {
                    IsDone = false,
                    IsSaved = false
                }
            );

            AddNewToDo = new RelayCommand(_addNewToDo);

        }

        private void _addNewToDo(object argument) {
            if (argument == null) return;

            if (argument is KeyRoutedEventArgs) {
                KeyRoutedEventArgs keyEvent = argument as KeyRoutedEventArgs;
                if (keyEvent.Key == VirtualKey.Enter) {
                    ActiveNotebook.ToDos.Add(new TodoVM() { Name = ActiveNotebook.ToDos.Last().Name });
                }
            } else if (argument is string) {
                string newItem = (string)argument;
                ActiveNotebook.ToDos.Add(new TodoVM() { Name = newItem });
            }


        }
    }

}
