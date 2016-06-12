using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Plugin.Media;
using TUPMobile.States;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class MainPage : ContentPage
    {
        //private bool _animate;
        private string userId;
        public MainPage()
        {
            Debug.WriteLine("#### MAINPAGE Constr ####");
            InitializeComponent();
            App.Store.Subscribe((ApplicationState state) =>
            {
                TopPostList.ItemsSource = state.MainPageState.TopPosts;
                userId = state.CurrentUser.User.Id;
            });
        }

        private async void OnCameraTapped(Object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }
            Debug.WriteLine("#### TAKING PIC!");
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "TUP",
                SaveToAlbum = true,
                 Name = userId+DateTime.Now.ToFileTime()+".jpg"

                
            });
            Debug.WriteLine("#### PHOTO TAKED!");
            Debug.WriteLine(file.Path);
            if (file == null)
                return;
            Debug.WriteLine("#### Show alert!");
            await DisplayAlert("File Location", file.Path, "OK");
            Debug.WriteLine("#### go to photopage!");
            await Navigation.PushAsync(new PhotoResultPage(file));
           
        }

        private async void OnThumbTapped(Object sender, EventArgs e)

        {
            await AnimateItem(ThumbUp, 1000);
            await Navigation.PushAsync(new VotePage());
        }

        private async void OnTopTapped(Object sender, EventArgs e)

        {
            await Navigation.PushAsync(new TopPage());
        }

        private async Task AnimateItem(View uiElement, uint duration)
        {
            await uiElement.ScaleTo(1.25, duration/3, Easing.SinInOut);
            await uiElement.ScaleTo(0.75, duration/3, Easing.SinInOut);
            await uiElement.ScaleTo(1, duration/3, Easing.SinInOut);
        }
    }
}