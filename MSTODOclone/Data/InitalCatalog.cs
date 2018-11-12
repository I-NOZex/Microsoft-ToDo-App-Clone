using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSTODOclone.ViewModels;

namespace MSTODOclone.Data {
    public static class InitalCatalog {
        public static ObservableCollection<NotebookVM> SetInitialNotebooksData() {
            Random r = new Random();

            NotebookVM Notebooks1 = new NotebookVM();
            Notebooks1.Name = "List 1";
            foreach (var idx in Enumerable.Range(0, 10)) {
                Notebooks1.InsertToDo(
                    new TodoVM() {
                        Name = $"Item 1.{idx}",
                        IsDone = r.NextDouble() > 0.5
                    }
                );
            }


            NotebookVM Notebooks2 = new NotebookVM();
            Notebooks2.Name = "List 2";
            foreach (var idx in Enumerable.Range(0, 7)) {
                Notebooks2.InsertToDo(
                    new TodoVM() {
                        Name = $"Item 2.{idx}",
                        IsDone = r.NextDouble() > 0.5
                    }
                );
            }


            NotebookVM Notebooks3 = new NotebookVM();
            Notebooks3.Name = "List 3";
            foreach (var idx in Enumerable.Range(0, 13)) {
                Notebooks3.InsertToDo(
                    new TodoVM() {
                        Name = $"Item 3.{idx}",
                        IsDone = r.NextDouble() > 0.5
                    }
                );
            }

            return new ObservableCollection<NotebookVM>() {
                Notebooks1,
                Notebooks2,
                Notebooks3,
            };

        }
    }
}
