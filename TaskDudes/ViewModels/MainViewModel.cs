using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
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
        private Taski _selectedTask;
        public ObservableCollection<Taski> Tasks { get; } = new ObservableCollection<Taski>();
        public Command LoadTasksCommand { get; }
        public Command TaskTapped { get; }

        public DateTime Today { get; }= DateTime.Now.Date;
        public MainViewModel()
        {
            Title = "Welcome to Task Mates";
            NewTaskCommand = new Command(OnAddTask);
            LoadTasksCommand = new Command(ExecuteLoadTasksCommand);
            TaskTapped = new Command<Taski>(OnTaskSelected);
            ExecuteLoadTasksCommand();

        }           
        
        public void ExecuteLoadTasksCommand()
        {
            IsBusy = true;

            try
            {
                if (Tasks != null)
                {
                    Tasks.Clear();
                }
                List<Taski> tasks = TaskController.GetAllUserTasks(App.LoggedUser.Id);
                foreach (var item in tasks)
                {
                    if(item.Date.Date == Today) { Tasks.Add(item); }
                        
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

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
            
        }

        public Taski SelectedItem
        {
            get => _selectedTask;
            set
            {
                SetProperty(ref _selectedTask, value);
                OnTaskSelected(value);
            }
        }

        async void OnTaskSelected(Taski item)
        {
            if (item == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TaskDetailPage)}?{nameof(TaskDetailViewModel.ItemId)}={item.Id}");
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