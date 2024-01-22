using MaxMango.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckOutPage : ContentPage
	{
		public ObservableCollection<SelectedOrder> Orders { get; set; }
		private decimal _totalPrice;
		public decimal TotalPrice
		{
			get=> _totalPrice;
			set
			{
				if (_totalPrice != value)
				{
					_totalPrice = value;
					OnPropertyChanged(nameof(TotalPrice));
				}
			}
		}

		public CheckOutPage ()
		{
			InitializeComponent ();
			Orders = new ObservableCollection<SelectedOrder> (App.SelectedOrders);
			orderCollectionView.ItemsSource = App.SelectedOrders;

			CalculateTotalPrice ();
			BindingContext = this;
		}
		public void CalculateTotalPrice()
		{
			decimal totalPrice = 0;
			foreach (var order in Orders)
			{
				totalPrice += order.OrderSizePrice;

				if(order.OrderAddOns != null)
				{
                    foreach (var addOn in order.OrderAddOns)
                    {
                        totalPrice += addOn.Price;
                    }
                }
			}
			TotalPrice = totalPrice;
		}

		private void OnRemoveOrderClicked(object sender, EventArgs e)
		{
			var button = sender as Button;
			if(button != null)
			{
				if(button.BindingContext is SelectedOrder selectedOrder)
				{
					App.SelectedOrders.Remove(selectedOrder);
					orderCollectionView.ItemsSource = null;
                    orderCollectionView.ItemsSource = App.SelectedOrders;
					UpdateTotalPrice();
				}
			}
		}

        private void UpdateTotalPrice()
        {
            // Calculate the total price and update the TotalPrice label
            decimal totalPrice = App.SelectedOrders.Sum(order => order.OrderSizePrice + order.OrderAddOns.Sum(addOn => addOn.Price));
        }

        public async void OnPayClicked(object sender, EventArgs e)
		{
			var paymentPage = new PaymentPage(_totalPrice);
			await Navigation.PushAsync(paymentPage);
		}

        public async void OnPayWithEWalletClicked(object sender, EventArgs e)
        {
            var paymentEWalletPage = new PaymentEwalletPage(_totalPrice);
            await Navigation.PushAsync(paymentEWalletPage);
        }
    }
}