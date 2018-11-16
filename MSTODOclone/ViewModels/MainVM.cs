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
using MSTODOclone.Helpers;
using MSTODOclone.Models;

namespace MSTODOclone.ViewModels {


    public class MainVM : BaseVM {
        private ObservableCollection<NotebookVM> _notebooks { get; set; }
        public ObservableCollection<NotebookVM> Notebooks {
            get => _notebooks;
            set {
                _notebooks = value;
                OnPropertyChanged("Notebooks");
            }
        }


        private NotebookVM _activeNotebook;
        public NotebookVM ActiveNotebook {
            get { return _activeNotebook; }
            set {
                _activeNotebook = value;
                OnPropertyChanged("ActiveNotebook");
            }
        }

        public RelayCommand AddNewToDo { get; set; }
        public RelayCommand SaveAll { get; set; }

        private bool _isLoading { get; set; }
        public bool IsLoading {
            get => _isLoading;
            set {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }

        public MainVM() {
            LoadData();

            AddNewToDo = new RelayCommand(_addNewToDo);
            SaveAll = new RelayCommand(o => _saveAll(o));
        }

        private async Task LoadData() {
            IsLoading = true;
            Notebooks = await NotebookService.FetchDataAsync();

            ActiveNotebook = Notebooks?.FirstOrDefault();

            foreach (var notebook in Notebooks) {
                notebook.ToDos.Add(new EmptyTodoItemVM());
            }

            IsLoading = false;
        }


        private void _addNewToDo(object argument) {
            if (argument == null) return;

            if (argument is KeyRoutedEventArgs) {
                KeyRoutedEventArgs keyEvent = argument as KeyRoutedEventArgs;
                if (keyEvent.Key == VirtualKey.Enter) {
                    var lastItem = ActiveNotebook.ToDos.Last();
                    ActiveNotebook.InsertToDo(new TodoVM() {Name = lastItem.Name});
                    lastItem.Name = "";
                }
            }
            else {
                var lastItem = ActiveNotebook.ToDos.Last();
                ActiveNotebook.InsertToDo(new TodoVM() {Name = lastItem.Name});
                lastItem.Name = "";
            }


        }

        private async Task _saveAll(object argument) {
            IsLoading = true;
            await NotebookService.SaveDataASync(Notebooks);
            IsLoading = false;
            foreach (var notebook in Notebooks) {
                notebook.ToDos.Add(new EmptyTodoItemVM());
            }
        }
    }

}
