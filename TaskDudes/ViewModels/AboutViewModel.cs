using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TaskDudes.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Welcome to TaskMates";
            NewTaskCommand = new Command(async () => await Browser.OpenAsync("https://fi.wikipedia.org/wiki/Kana"));
        }

        public ICommand NewTaskCommand { get; }
    }
}