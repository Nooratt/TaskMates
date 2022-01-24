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
        private bool isRepeating;

        public Command DeleteCommand { get; }
        public Command ModifyCommand { get; }
        public string Id { get; set; }

        public TaskDetailViewModel()
        {
            DeleteCommand = new Command(DeleteTask);
            ModifyCommand = new Command(ModifyTask);
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

        public void LoadItemId(string itemId)
        {
            try
            {
                Taski task = TaskController.GetTask(itemId);
                Task = task;
                Id = task.Id;
                Name = task.TaskName;
                Description = task.TaskDescription;
                IsRepeating = task.Repeating;
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
            
        }
    }
}
