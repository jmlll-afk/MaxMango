using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        public OrderPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetMenuItemAsync();
        }
        private async void OnViewOrderClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CheckOutPage());
        }

        private async void OnAddOrderClicked(object sender, EventArgs e)
        {
            var addOrder = new AddOrderPage();

            var button = sender as Button;
            var menu = button.BindingContext as Models.MenuItem;
            addOrder.Name = menu.Name;

            await Navigation.PushAsync(addOrder);
        }
    }
}