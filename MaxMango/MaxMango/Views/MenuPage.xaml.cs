using MaxMango.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            UpdateMenuList();
        }

        public async void UpdateMenuList()
        {
            collectionView.ItemsSource = await App.Database.GetMenuItemAsync();
        }
        private async void OnAddMenuClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddMenuPage());
        }

        private void OnRemoveMenuClicked(object sender, EventArgs e)
        {
            var removePage = new RemovePopupPage()
            {
                IsLightDismissEnabled = false
            };

            var button = sender as Button;
            var menu = button.BindingContext as Models.MenuItem;
            removePage.ID = menu.Id;
            removePage.Menu = this;

            Navigation.ShowPopup(removePage);
        }
    }
}