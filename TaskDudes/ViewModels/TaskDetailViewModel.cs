using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskDudes.Controllers;
using TaskDudes.Models;
using TaskDudes.Views;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class TaskDetailViewModel : BaseViewModel
    {
        private string itemId;
        private Taski task;
        private string name;
        private string description;
        private DateTime date;
        private bool isRepeating;
        private bool viewMode;
        private bool modifyMode;

        public Command DeleteCommand { get; }
        public Command ModifyCommand { get; }
        public Command CancelCommand { get; }
        public Command SaveCommand  { get; }
        public string Id { get; set; }

        public TaskDetailViewModel()
        {
            DeleteCommand = new Command(DeleteTask);
            ModifyCommand = new Command(ModifyTask);
            CancelCommand = new Command(Cancel);
            SaveCommand = new Command(Save);
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

        public string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Taski Task
        {
            get
            {
                return task;
            }
            set
            {
                task = value;
            }
        }

        public bool ViewMode
        {
            get => viewMode;
            set => SetProperty(ref viewMode, value);
        }

        public bool ModifyMode
        {
            get { return modifyMode; }
            set => SetProperty(ref modifyMode, value);
        }

        public void LoadItemId(string itemId)
        {
            try
            {
                Taski task = TaskController.GetTask(itemId);
                Task = task;
                Id = task.Id;
                Name = task.TaskName;
                Description = task.TaskDescription;
                Date = task.Date;
                IsRepeating = task.Repeating;
                ViewMode = true;
                ModifyMode = false;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }

        public async void DeleteTask()
        {
            var answer = await App.Current.MainPage.DisplayAlert("Delete", "Are you sure you want to delete this task?", "Yes", "No");
            if(answer)
            {
                TaskController.RemoveTaskAsync(Task);
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }

        }

        public void ModifyTask()
        {
            ModifyMode = true;
            ViewMode = false;
            
        }

        public void Cancel()
        {
            ModifyMode = false;
            ViewMode = true;

        }

        public void Save()
        {
            Task.TaskName = Name;
            Task.TaskDescription = Description;
            Task.Repeating = IsRepeating;
            Task.Date = Date;
            TaskController.UpdateTaskAsync(Task);
            ModifyMode = false;
            ViewMode = true;

        }
    }
}
