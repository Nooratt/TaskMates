using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TaskDudes.Controllers;
using TaskDudes.Models;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class NewTaskViewModel : BaseViewModel
    {
        private string name;
        private string description;
        private DateTime date = DateTime.Now;
        private bool isRepeating;

        public NewTaskViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public DateTime Date
        {
            get => date;
            set => SetProperty(ref date, value);
        }

        public bool IsRepeating
        {
            get => isRepeating;
            set => SetProperty(ref isRepeating, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Taski newItem = new Taski()
            {
                Id = Guid.NewGuid().ToString(),
                TaskName = Name,
                TaskDescription = Description,
                Date = Date,
                TaskIsDone = false,
                Repeating = isRepeating,
                RepeatTime = null,
                UserId=App.LoggedUser.Id
            };
          
            TaskController.AddNewTask(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
