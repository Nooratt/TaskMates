using System;
using System.Diagnostics;
using System.Threading.Tasks;
using TaskDudes.Controllers;
using TaskDudes.Models;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;
        public string Id { get; set; }

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

        public void LoadItemId(string itemId)
        {
            try
            {
                Taski task = TaskController.GetTask(itemId);
                Id = task.Id;
                Text = task.TaskName;
                Description = task.TaskDescription;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
