using MaxMango.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MaxMango.Views
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