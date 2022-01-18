using System;
using System.Collections.Generic;
using System.Text;
using TaskDudes.Controllers;
using TaskDudes.Models;
using TaskDudes.Views;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class RegisterViewModel: BaseViewModel
    {
        private string userName;
        private string email;
        private string password;
        private string passwordConf;
        public Command LoginCommand { get; }
        public Command SaveRegistrationCommand { get; }


        public RegisterViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            SaveRegistrationCommand = new Command(OnSave);
            
        }

        private async void OnLoginClicked(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(userName)
                && !String.IsNullOrWhiteSpace(email)
                && !String.IsNullOrWhiteSpace(password)
                && !String.IsNullOrWhiteSpace(passwordConf)
                && password == passwordConf;
        }

        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        public string PasswordConf
        {
            get => passwordConf;
            set => SetProperty(ref passwordConf, value);
        }

        private async void OnSave()
        {
            if (ValidateSave())
            {
                User newUser = new User()
                {
                    UserName = UserName,
                    Email = Email,
                    Password = Password,
                    Settings = new Settings(NotificationType.All),
                    Tasks = new List<Taski>()
                };

                var registered = UserController.AddNewUserAsync(newUser);
                
                    string title = $"Register complete!";
                    string message = $"You have now registered to TaskMates and can login!";
                    await App.Current.MainPage.DisplayAlert(title, message, "OK");

                // This will pop the current page off the navigation stack
                    await Shell.Current.GoToAsync("..");
                    await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
                
            }
            else 
            {

            }
        }

    }
}
