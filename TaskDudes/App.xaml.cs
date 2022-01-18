using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TaskDudes.Models;
using TaskDudes.Services;
using TaskDudes.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDudes
{
    public partial class App : Application
    {
        private static User loggedUser;

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            var db = new TaskMatesContext();

            db.Database.EnsureCreated();

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

        public static User LoggedUser 
        { 
            get { return loggedUser; }
            set { loggedUser = value; }

        }
    }
}
