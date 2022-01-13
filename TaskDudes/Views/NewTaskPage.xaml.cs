using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaskDudes.Models;
using TaskDudes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDudes.Views
{
    public partial class NewTaskPage : ContentPage
    {
        public Taski Item { get; set; }

        public NewTaskPage()
        {
            InitializeComponent();
            BindingContext = new NewTaskViewModel();
        }
    }
}