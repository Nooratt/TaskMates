using System.ComponentModel;
using TaskDudes.ViewModels;
using Xamarin.Forms;

namespace TaskDudes.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}