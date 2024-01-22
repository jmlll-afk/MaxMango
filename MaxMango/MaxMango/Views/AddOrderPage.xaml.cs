using MaxMango.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddOrderPage : ContentPage
	{

		public AddOrderPage ()
		{
			InitializeComponent ();
			selectedAddOns = new List<SelectedAddOns> ();
		}

		public string Name { get; set; }
		public Models.Sizes SelectedSize { get; set; }
		public string selectedSize { get; set; }
		public decimal selectedSizePrice { get; set; }
		public List<SelectedAddOns> selectedAddOns;

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			var sizes = await App.Database.GetSizesAsync ();
			if (sizes == null || sizes.Count == 0)
			{
                await PopulateSizesAsync ();
				sizesCollectionView.ItemsSource = sizes;
			}
			else
			{
                sizesCollectionView.ItemsSource = sizes;
			}

			var addOns = await App.Database.GetAddOnsAsync ();
			if (addOns == null || addOns.Count == 0)
			{
				await PopulateAddOnsAsync();
				AddOnsCollectionView.ItemsSource = addOns;
			} 
			else
			{
                AddOnsCollectionView.ItemsSource = addOns;
            }
        }

		private async Task PopulateSizesAsync()
		{
			await App.Database.SaveSizeAsync(new Models.Sizes { Size = "Medium", Price = 70 });
            await App.Database.SaveSizeAsync(new Models.Sizes { Size = "Large", Price = 80 });
            await App.Database.SaveSizeAsync(new Models.Sizes { Size = "Bogo", Price = 100 });
        }

		private async Task PopulateAddOnsAsync()
		{
			await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Pearls", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Nata", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Grahams", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Crushed Oreo", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Choco Kisses", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Strawberry Syrup", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Blueberry Syrup", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Caramel Syrup", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Ube Syrup", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Chocolate Syrup", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Ice Cream", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Mango Bits", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Shredded Cheese", AddOnPrice = 10 });
            await App.Database.SaveAddOnsAsync(new Models.AddOns { AddOn = "Mango Puree", AddOnPrice = 10 });

        }

		public void SizeCheckbox_CheckedChanged(object sender, EventArgs e)
		{
            var selectedCheckBox = sender as CheckBox;
            if (selectedCheckBox != null && selectedCheckBox.IsChecked)
            {
                SelectedSize = selectedCheckBox.BindingContext as Models.Sizes;
            }
        }

		public void AddOnCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			var checkbox = sender as CheckBox;
			var addOn = checkbox.BindingContext as AddOns;

			decimal addOnPrice = addOn.AddOnPrice;

			var addOnItem = new SelectedAddOns
			{
				AddOn = addOn.AddOn,
				Price = addOnPrice,
			};
			if (checkbox.IsChecked)
			{
				selectedAddOns.Add(addOnItem);
			}
			else
			{
				selectedAddOns.Remove(addOnItem);
			}
		}

        public void OnAddClicked(object sender, EventArgs e)
		{
			var selectedOrder = new SelectedOrder
			{
				OrderName = Name,
				OrderSize = SelectedSize?.Size,
				OrderSizePrice = SelectedSize?.Price??0,
				OrderAddOns = selectedAddOns
            };
			App.SelectedOrders.Add(selectedOrder);
			Navigation.PopAsync();
		}
    }

	public class SelectedAddOns
	{
		public string AddOn { get; set; }
		public decimal Price { get; set; }
	}
	public class SelectedOrder
	{
		public string OrderName { get; set; }
		public string OrderSize { get; set; }
		public decimal OrderSizePrice { get; set; }
		public List<SelectedAddOns> OrderAddOns { get; set; }
	}
}