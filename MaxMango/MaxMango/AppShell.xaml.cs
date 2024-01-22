using MaxMango.ViewModels;
using MaxMango.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MaxMango
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddMenuPage), typeof(AddMenuPage));
            Routing.RegisterRoute(nameof(AddInventoryPage), typeof(AddInventoryPage));
            Routing.RegisterRoute(nameof(CheckOutPage), typeof(CheckOutPage));
            Routing.RegisterRoute(nameof(AddOrderPage), typeof(AddOrderPage));
            Routing.RegisterRoute(nameof(PaymentPage), typeof(PaymentPage));
            Routing.RegisterRoute(nameof(PaymentEwalletPage), typeof(PaymentEwalletPage));
        }

    }
}
