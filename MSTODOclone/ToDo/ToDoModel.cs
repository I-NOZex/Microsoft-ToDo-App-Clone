using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MSTODOclone.Models {

    public class ToDoModel {

        public class Step {
            public string Text;
            public string IsDone;
        }
    
        private string _name;
        private bool _isDone;
        private List<Step> _steps;
        private DateTime _reminder;
        private DateTime _creationDate;
        private DateTime _deadline;
        private DateTime? _repeat;
        private string _note;


        public string Name {
            get => _name;
            set {
                _name = value;
                Debug.WriteLine("ToDo model name changed to -> "+value);
            }
        }

        public bool IsDone {
            get => _isDone;
            set => _isDone = value;
        }

        public List<Step> Steps {
            get => _steps;
            set => _steps = value;
        }

        public DateTime Reminder {
            get => _reminder;
            set => _reminder = value;
        }

        public DateTime CreationDate {
            get => _creationDate;
            set => _creationDate = value;
        }

        public DateTime Deadline {
            get => _deadline;
            set => _deadline = value;
        }

        public DateTime? Repeat {
            get => _repeat;
            set => _repeat = value;
        }

        public string Note {
            get => _note;
            set => _note = value;
        }


    }

}
