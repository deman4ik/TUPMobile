using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class RootTabPage : TabbedPage
    {
        public RootTabPage()
        {
            InitializeComponent();
            this.Children.Add(new NavigationPage(new MainPage ()) { Title = "Top" });
            this.Children.Add(new NavigationPage(new VotePage()) { Title = "Vote" });
            this.Children.Add(new NavigationPage(new PhotoPage ()) { Title = "Photo" });
            this.Children.Add(new NavigationPage(new UserPage ()) { Title = "User" });
        }
    }
}
