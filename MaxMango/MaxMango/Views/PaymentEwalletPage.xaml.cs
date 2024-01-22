using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaymentEwalletPage : ContentPage
	{
		public decimal TotalPrice { get; }
		public string ModeOfPayment = "E-Wallet";
		public decimal receivedAmount ;
		public decimal Change;
		public string referenceNumber;
		public DateTime CurrentDateTime;
		public PaymentEwalletPage (decimal totalPrice)
		{
			InitializeComponent ();
			TotalPrice = totalPrice;
            UpdateDateTime();

            BindingContext = this;
		}

		public void UpdateDateTime()
		{
			DateTime _currentDateTime = DateTime.Now;
			CurrentDateTime = _currentDateTime;
			DateTimeLabel.Text = CurrentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
		}
		public void ReceivedAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			if(decimal.TryParse(e.NewTextValue, out decimal newReceivedAmount))
			{
				receivedAmount = newReceivedAmount;
				decimal totalPrice = TotalPrice;

                if (receivedAmount >= totalPrice)
                {
                    Change = receivedAmount - totalPrice;
                    ChangeLabel.Text = Change.ToString();
                }
                else
                {
                    ChangeLabel.Text = "Invalid Input";
                }
            }
			else if(string.IsNullOrEmpty(e.NewTextValue))
			{
				ChangeLabel.Text = string.Empty;
			}
			else
			{
				ChangeLabel.Text = "Invalid Input";
			}
		}

		private async void OnPaymentClicked(object sender, EventArgs e)
		{

			referenceNumber = ReferenceNumber.Text;
			if (receivedAmount > 0 && referenceNumber != null)
			{
				await App.Database.SaveSalesAsync(new Models.Sales
				{
					ReferenceNumber = referenceNumber,
					ReceivedAmount = receivedAmount,
					DateTime = CurrentDateTime,
					Orders = App.SelectedOrders,
					Change = Change,
					PaymentType = ModeOfPayment
				});
			}
			else
			{
				Debug.WriteLine("Invalid Input");
			}
		}
	}
}