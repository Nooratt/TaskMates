using System.ComponentModel;
using TaskDudes.ViewModels;
using Xamarin.Forms;

namespace TaskDudes.Views
{
    public partial class TaskDetailPage : ContentPage
    {
        public TaskDetailPage()
        {
            InitializeComponent();
            BindingContext = new TaskDetailViewModel();
        }
    }
}