using System;
using System.Diagnostics;
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
            App.Store.Subscribe((ApplicationState state) => { BindingContext = state.VotePageState; });
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