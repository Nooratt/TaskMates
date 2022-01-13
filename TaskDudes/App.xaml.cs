using Microsoft.EntityFrameworkCore;
using System;
using TaskDudes.Services;
using TaskDudes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDudes
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            var db = new TaskMatesContext();

            db.Database.Migrate();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
