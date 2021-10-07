using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace ToDo
{
    class ToDoViewModel
    {   
        //prop double tab
        public ObservableCollection<String> ToDos { get; }

        public string ToDo { get; set; }

        public string SelectedToDo { get; set; }
        //ctor double tab
        public ToDoViewModel()
        {
            ToDos = new ObservableCollection<string>();
            AddCommand = new DelegateCommand(Add);
            RemoveCommand =new DelegateCommand(Remove);
        }

        private void Remove()
        {
            ToDos.Remove(ToDo);
        }

        private void Add()
        {
            ToDos.Add(ToDo);
        }

        public ICommand AddCommand { get; }
        public ICommand RemoveCommand { get; }
    }
}
