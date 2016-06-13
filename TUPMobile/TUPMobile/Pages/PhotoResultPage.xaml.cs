using System;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class PhotoResultPage : ContentPage
    {
        private MediaFile _image;

        public PhotoResultPage(MediaFile image)
        {
            InitializeComponent();

            // BindingContext = ImageSource.FromStream(() => new MemoryStream(image));
            BindingContext = ImageSource.FromStream(() =>
            {
                var stream = image.GetStream();
                image.Dispose();
                return stream;
            });

            _image = image;
        }


        private void OnSendClicked(object sender, EventArgs args)
        {
            //var client = DataService.Instance;
            //await client.Login();
            //var result = await client.MakePost();
            //var res = await AzureStorageService.Instance.UploadPhoto(result.Sas, result.Id, _image);


            //await SendBtn.ScaleTo(1.25, 1000 / 3, Easing.SinInOut);
            //SendBtn.Text = "Sending...";
            //SendBtn.BackgroundColor = Color.FromHex("#64FFDA");
            //await SendBtn.ScaleTo(1, 1000 / 3, Easing.SinInOut);
            //await Navigation.PopAsync();
        }
    }
}