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
using MSTODOclone.Models;

namespace MSTODOclone.ViewModels {


    public class TodoCatalog : BaseVM {

        private string _name;
        private ObservableCollection<TodoItem> _items;


        public string Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<TodoItem> Items {
            get; set;
        }

        public TodoCatalog() {

        }

        public void Insert(TodoItem item) {
            Items.Insert(this.Items.Count-1, item);
            OnPropertyChanged("Items");
        }


    }

    public class MainVM : BaseVM {

        public RelayCommand ActivateItem {
            get;
            private set;
        }

        public RelayCommand AddNewToDo {
            get;
            private set;
        }

        public RelayCommand stuff {
            get;
            private set;
        }

        private ObservableCollection<TodoCatalog> _toDos;

        public ObservableCollection<TodoCatalog> ToDos {
            get => _toDos;
            set {
                _toDos = value;
                OnPropertyChanged("ToDos");
            }
        }

        private TodoCatalog _activeItem;
        public TodoCatalog ActiveItem {
            get {

                return _activeItem;
            }
            set {
                _activeItem = value;
                OnPropertyChanged("ActiveItem");
            }
        }


        public MainVM() {
            TodoCatalog todos = new TodoCatalog();

            TodoItem t1 = new TodoItem();
            t1.Name = "item 1";
            t1.IsDone = false;


            TodoItem t2 = new TodoItem();
            t2.Name = "item 2";
            t2.IsDone = true;


            TodoItem t3 = new TodoItem();
            t3.Name = "item 3";
            t3.IsDone = false;

            TodoItem t4 = new TodoItem();
            t4.Name = "item 4";
            t4.IsDone = false;

            TodoItem t5 = new TodoItem();
            t5.Name = "item 5";
            t5.IsDone = true;

            TodoItem t6 = new TodoItem();
            t6.Name = "item 6";
            t6.IsDone = true;

            todos.Name = "List 1";
            todos.Items = new ObservableCollection<TodoItem>(){
                    t1, t2, t3, t4, t5, t6
                };

            /* =============================== */

            TodoCatalog todos2 = new TodoCatalog();

            TodoItem ta = new TodoItem();
            ta.Name = "item a";
            ta.IsDone = false;


            TodoItem tb = new TodoItem();
            tb.Name = "item b";
            tb.IsDone = true;


            TodoItem tc = new TodoItem();
            tc.Name = "item c";
            tc.IsDone = false;

            todos2.Name = "List ABC";
            todos2.Items = new ObservableCollection<TodoItem>(){
                ta, tb, tc
            };
            ToDos = new ObservableCollection<TodoCatalog>() {
                todos,
                todos2
            };

            ActivateItem = new RelayCommand(SetActiveItem);
            AddNewToDo = new RelayCommand(_addNewToDo);
            ActiveItem = ToDos.First();
            ActiveItem.Items.Add(
                new EmptyTodoItem() {
                    IsDone = false,
                    IsSaved = false
                }
            );

            stuff = new RelayCommand(_stuff);
        }

        private void _stuff(object obj) {
            this.ToDos.First().Name = "new name";
        }

        public void SetActiveItem(object arguments) {
            if (arguments != null) {
                TodoCatalog item = arguments as TodoCatalog;
                _activeItem = ToDos.FirstOrDefault(x => x.Name == item.Name);
                OnPropertyChanged("ActiveItem");
            }

        }

        private void _addNewToDo(object argument) {
            if (argument == null) return;

            if (argument is KeyRoutedEventArgs) {
                KeyRoutedEventArgs keyEvent = argument as KeyRoutedEventArgs;
                if (keyEvent.Key == VirtualKey.Enter) {
                    ActiveItem.Insert(new TodoItem() { Name = ActiveItem.Items.Last().Name });
                }
            } else if ( argument is string ) {
                string newItem = (string) argument;
                ActiveItem.Insert(new TodoItem() { Name = newItem });
            }


        }
    }

}
