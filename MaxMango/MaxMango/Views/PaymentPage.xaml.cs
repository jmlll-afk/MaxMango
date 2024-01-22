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
	public partial class PaymentPage : ContentPage
	{
		public decimal TotalPrice { get; }
		public string ModeOfPayment = "Cash";
		public PaymentPage (decimal totalPrice)
		{
			InitializeComponent ();
			TotalPrice = totalPrice;
			BindingContext = this;
		}
	}
}