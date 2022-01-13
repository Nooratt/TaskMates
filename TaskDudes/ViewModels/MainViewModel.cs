using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskDudes.Models;
using TaskDudes.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private Taski _selectedTask;
        public ObservableCollection<Taski> Tasks { get; }
        public MainViewModel()
        {
            Tasks = new ObservableCollection<Taski>();
            Title = "Welcome to TaskMates";
            NewTaskCommand = new Command(OnAddTask);
        }

        private async void OnAddTask(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTaskPage));
        }

        public ICommand NewTaskCommand { get; }
    }
}