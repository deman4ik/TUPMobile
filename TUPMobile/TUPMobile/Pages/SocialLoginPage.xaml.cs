using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class SocialLoginPage : ContentPage
    {
        public string Provider { get; private set; }

        public SocialLoginPage(string provider)
        {
            InitializeComponent();
            Provider = provider;
        }
    }
}