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
        private string text;
        private string description;

        public NewTaskViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(text)
                && !String.IsNullOrWhiteSpace(description);
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
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
                TaskName = Text,
                TaskDescription = Description
            };

            TaskController.AddNewTask(newItem);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
