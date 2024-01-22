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
    public partial class AddInventoryPage : ContentPage
    {
        public AddInventoryPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameEntry.Text) && !string.IsNullOrEmpty(quantityEntry.Text))
            {
                await App.Database.SaveInventortAsycn(new Models.InventoryItem
                {
                    Name = nameEntry.Text,
                    Description = descriptionEntry.Text,
                    Quantity = int.Parse(quantityEntry.Text)
                });
            }

            nameEntry.Text = string.Empty;
            quantityEntry.Text = string.Empty;

        }
    }
}