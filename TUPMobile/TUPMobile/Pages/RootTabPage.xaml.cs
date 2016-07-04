using System;
using System.Diagnostics;
using TUPMobile.Actions;
using TUPMobile.States;
using TUPMobile.Utils;
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

            App.Store.Subscribe((ApplicationState state) =>
            {
                if (!state.CurrentUser.IsAuthenticated && state.NavigationState.CurrentPage != typeof (LoginPage))
                {
                    Debug.WriteLine("### NOT AUTHENTICATED GOIN TO LOGIN PAGE");
                    App.Store.Dispatch(ActionCreators.Push(Navigation, typeof (RootTabPage), typeof (LoginPage),
                        new LoginPage(), true, false));
                }
            });
        }
    }
}