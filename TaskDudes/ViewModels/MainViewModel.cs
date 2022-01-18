using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using TaskDudes.Controllers;
using TaskDudes.Models;
using TaskDudes.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Taski> Tasks { get; }
        public Command LoadTasksCommand { get; }
        public MainViewModel()
        {
            Tasks = new ObservableCollection<Taski>();
            List<Taski> tasks = TaskController.GetAllTasks();
            foreach (var item in tasks)
            {
                Tasks.Add(item);
            }
            Title = "Welcome to TaskMates";
            NewTaskCommand = new Command(OnAddTask);
            LoadTasksCommand = new Command(ExecuteLoadTasksCommand);

        }
        public void ExecuteLoadTasksCommand()
        {
            IsBusy = true;

            try
            {
                Tasks.Clear();
                List<Taski> tasks = TaskController.GetAllUserTasks(App.LoggedUser.Id);
                foreach (var item in tasks)
                {
                    Tasks.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async void OnAddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTaskPage));
        }

        public bool TasksNotEmpty
        {
            get { return Tasks!=null && Tasks.Count>0; }
        }

        public bool TasksIsEmpty
        {
            get { return Tasks == null | Tasks.Count == 0; }
        }

        public ICommand NewTaskCommand { get; }
    }
}