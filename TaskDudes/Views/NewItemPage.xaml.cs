using System;
using System.Collections.Generic;
using System.ComponentModel;
using TaskDudes.Models;
using TaskDudes.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TaskDudes.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}