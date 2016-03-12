using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class PhotoPage : ContentPage
    {
        public PhotoPage(ImageSource image)
        {
            InitializeComponent();
            BindingContext = image;
            FilterList.ItemsSource = new List<string>
            {
                "filter_1.png",
                "filter_2.png",
                "filter_3.png",
                "filter_4.png",
                "filter_5.png",
                "filter_6.png",
            };
        }

        

            async void OnSendClicked(object sender, EventArgs args)
            {
            await SendBtn.ScaleTo(1.25, 1000 / 3, Easing.SinInOut);
            SendBtn.Text = "Sending...";
            SendBtn.BackgroundColor = Color.FromHex("#64FFDA");
            await SendBtn.ScaleTo(1, 1000 / 3, Easing.SinInOut);
            await Navigation.PopAsync();
        }
    }
}
