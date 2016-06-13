using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class RootTabPage : TabbedPage
    {
        public RootTabPage()
        {
            InitializeComponent();
            Children.Add(new NavigationPage(new MainPage()) {Title = "Top"});
            Children.Add(new NavigationPage(new VotePage()) {Title = "Vote"});
            Children.Add(new NavigationPage(new PhotoPage()) {Title = "Photo"});
            Children.Add(new NavigationPage(new UserPage()) {Title = "User"});
        }
    }
}