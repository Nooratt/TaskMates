using System;
using System.Collections.Generic;
using TaskDudes.ViewModels;
using TaskDudes.Views;
using Xamarin.Forms;

namespace TaskDudes
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(TaskDetailPage), typeof(TaskDetailPage));
            Routing.RegisterRoute(nameof(NewTaskPage), typeof(NewTaskPage));
            Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
