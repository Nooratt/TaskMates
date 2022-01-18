using System;
using System.Collections.Generic;
using System.Text;
using TaskDudes.Controllers;
using TaskDudes.Models;
using TaskDudes.Views;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _username;
        private string _password;

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(OnRegisterClicked);
        }

        private bool ValidateLogin()
        {
            var notNull = Username != null && Password != null;
            if (notNull)
            {
                User user = UserController.GetUserWithName(Username);
                if(user == null)
                {
                    return false;
                }
                else
                {
                    if(user.Password == Password)
                    {
                        return true;
                    }
                    else { return false;}
                }
            }
            else { return false; }
        }

        private async void OnLoginClicked(object obj)
        {
            var canLogin = ValidateLogin();
            if (canLogin)
            {
                App.LoggedUser = UserController.GetUserWithName(Username);
                await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Login failed!", "Wrong username or password", "OK");
            }
        }

        private async void OnRegisterClicked(object obj)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            await Shell.Current.GoToAsync(nameof(RegisterPage));
        }
    }
}
