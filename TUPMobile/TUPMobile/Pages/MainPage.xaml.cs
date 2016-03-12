using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TUPMobile.Model;
using TUPMobile.Services;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class MainPage : ContentPage
    {
        public List<string> SocialImageGalleryItems;
        /// <summary>
		/// The picture chooser.
		/// </summary>
		private IMediaPicker _mediaPicker;
        /// <summary>
		/// The _scheduler.
		/// </summary>
		private readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        public static BindableProperty ImageProperty =
            BindableProperty.Create("Image", typeof(ImageSource),
                typeof(MainPage),
                null, BindingMode.OneWay
                );

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
        private bool _animate;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new List<GalleryItem>
            {
                new GalleryItem
                {
                    Image = "social_album_1.jpg",
                    UserName = "Andrew",
                    Likes = "1450"
                },
                new GalleryItem
                {
                    Image = "social_album_2.jpg",
                    UserName = "Daniel",
                    Likes = "1289"
                },
                new GalleryItem
                {
                    Image = "social_album_3.jpg",
                    UserName = "Mary",
                    Likes = "1167"
                },
                new GalleryItem
                {
                    Image = "social_album_4.jpg",
                    UserName = "Ariel",
                    Likes = "983"
                },
                new GalleryItem
                {
                    Image = "social_album_5.jpg",
                    UserName = "Falcom",
                    Likes = "856"
                },
                new GalleryItem
                {
                    Image = "social_album_6.jpg",
                    UserName = "Petr",
                    Likes = "814"
                },
                new GalleryItem
                {
                    Image = "social_album_7.jpg",
                    UserName = "Kate",
                    Likes = "791"
                },
                new GalleryItem
                {
                    Image = "social_album_8.jpg",
                    UserName = "Mike",
                    Likes = "750"
                },
                new GalleryItem
                {
                    Image = "social_album_9.jpg",
                    UserName = "Tim",
                    Likes = "623"
                }
            };
        }

        private async void OnCameraTapped(Object sender, EventArgs e)

        {
            await AnimateItem(MakePhoto, 1000);
            
            if (_mediaPicker != null)
            {
                return;
            }


            _mediaPicker = DependencyService.Get<IMediaPicker>();

             await _mediaPicker.TakePhotoAsync(
                 new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }
                 ).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {

                    Debug.WriteLine(t.Exception);
                }
                else if (t.IsCanceled)
                {
                    Debug.WriteLine("Canceled");
                }
                else
                {
                    var mediaFile = t.Result;

                    Image = ImageSource.FromStream(() => mediaFile.Source);
                    Debug.WriteLine("OK");
                    

                }


            }, _scheduler);
            if (Image != null)
            {
                await Navigation.PushAsync(new PhotoPage(Image));
            }
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