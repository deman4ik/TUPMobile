using System;
using System.Collections.Generic;
using System.Diagnostics;
using MR.Gestures;
using tupapi.Shared.DataObjects;
using TUPMobile.States;
using Xamarin.Forms;
using ContentPage = Xamarin.Forms.ContentPage;

namespace TUPMobile.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotePage : ContentPage
    {
       // private bool _animate;
      //  double x, y;
        public VotePage()
        {
            InitializeComponent();
            App.Store.Subscribe((ApplicationState state) =>
            {
                BindingContext = state.VotePageState;
            });
            
        }



        protected override void OnAppearing()
        {
            base.OnAppearing();


            //_animate = true;

            //AnimateIn().Forget();
        }

        //public async Task AnimateIn()
        //{
        //    await AnimateItem(img, 10500);
        //}

        //private async Task AnimateItem(View uiElement, uint duration)
        //{
        //    while (_animate)
        //    {
        //        await uiElement.ScaleTo(1.05, duration, Easing.SinInOut);

        //        await Task.WhenAll(
        //            uiElement.FadeTo(1, duration, Easing.SinInOut),
        //            uiElement.LayoutTo(new Rectangle(new Point(0, 0), new Size(uiElement.Width, uiElement.Height))),
        //            uiElement.FadeTo(.9, duration, Easing.SinInOut),
        //            uiElement.ScaleTo(1.15, duration, Easing.SinInOut)
        //            );
        //    }
        //}

        //private async void OnThumbTapped(Object sender, EventArgs e)

        //{
        //    await thumb.ScaleTo(1.25, 1000/3, Easing.SinInOut);

        //    BackIcon.TextColor = Color.FromHex("#00E676");
        //    await thumb.ScaleTo(0.75, 1000/3, Easing.SinInOut);
        //    await thumb.ScaleTo(1, 1000/3, Easing.SinInOut);
        //    await Navigation.PopAsync();
        //}

       

        private void AbsoluteLayout_OnPanning(object sender, PanEventArgs e)
        {
            CurrentImage.TranslationX += e.DeltaDistance.X;
            CurrentImage.TranslationY += e.DeltaDistance.Y;
        }

        private void AbsoluteLayout_OnPanned(object sender, PanEventArgs e)
        {
            Debug.WriteLine("X: " + CurrentImage.X + " Y: " + CurrentImage.Y);
        }
    }
}