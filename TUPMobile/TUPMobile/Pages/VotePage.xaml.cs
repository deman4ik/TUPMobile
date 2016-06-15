using System;
using System.Diagnostics;
using FFImageLoading;
using TUPMobile.States;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotePage : ContentPage
    {
        public VotePage()
        {
            InitializeComponent();
            App.Store.Subscribe((ApplicationState state) =>
            {
                BindingContext = state.VotePageState;
                foreach (var image in state.VotePageState.Items)
                {
                    ImageService.Instance.LoadUrl(image.Url).Preload();
                }
            });
        }

        private void OnThumbDownTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("##### OnThumbDownTapped");
        }

        private void OnThumbUpTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("##### OnThumbUpTapped");
        }
    }
}