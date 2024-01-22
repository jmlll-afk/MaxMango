using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MaxMango.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMenuPage : ContentPage
    {
        public string imagePath;
        public AddMenuPage()
        {
            InitializeComponent();
        }

        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(nameEntry.Text))
            {
                await App.Database.SaveMenuAsync(new Models.MenuItem
                {
                    Name = nameEntry.Text,
                    menuImage = imagePath
                });

                nameEntry.Text = string.Empty;
            }
        }

        async void OnUploadClicked(object sender, EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync();

            if (result != null)
            {
                imagePath = result.FullPath;
                resultImage.Source = ImageSource.FromFile(imagePath);
            }
        }
    }
}