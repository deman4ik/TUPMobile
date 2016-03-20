using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
