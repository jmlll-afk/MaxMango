using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemovePopupPage : Popup
	{
		public RemovePopupPage ()
		{
			InitializeComponent ();
		}

		public int ID { get; set; }
		public MenuPage Menu { get; set; }

		public async void OnYesClicked(object sender, EventArgs e)
		{
			await App.Database.DeleteMenuAsync(new Models.MenuItem
			{
				Id = ID
			});

			Dismiss(null);
			Menu.UpdateMenuList();
		}
		void OnNoClicked(object sender, EventArgs e)
		{
			Dismiss(null);
		}
	}
}