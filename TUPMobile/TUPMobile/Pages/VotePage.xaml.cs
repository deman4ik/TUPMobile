using System;
using System.Collections.Generic;
using TUPMobile.Model;
using TUPMobile.States;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotePage : ContentPage
    {
        private bool _animate;
        private VotePageState State { get; set; }

        public VotePage()
        {
            InitializeComponent();
            State = new VotePageState
            {
                Position = 1,
                Items = new List<GalleryItem>
                {
                    new GalleryItem
                    {
                        Image = "article_image_0.jpg",
                        UserName = "Andrew",
                        Likes = "1450"
                    },
                    new GalleryItem
                    {
                        Image = "article_image_1.jpg",
                        UserName = "Daniel",
                        Likes = "1289"
                    },
                    new GalleryItem
                    {
                        Image = "article_image_2.jpg",
                        UserName = "Mary",
                        Likes = "1167"
                    },
                    new GalleryItem
                    {
                        Image = "article_image_3.jpg",
                        UserName = "Ariel",
                        Likes = "983"
                    },
                    new GalleryItem
                    {
                        Image = "article_image_4.jpg",
                        UserName = "Falcom",
                        Likes = "856"
                    },
                    new GalleryItem
                    {
                        Image = "article_image_5.jpg",
                        UserName = "Petr",
                        Likes = "814"
                    }
                }
            };
            BindingContext = State;
        }

        /// <summary>
        ///     Called when the Position changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CarouselView_PositionSelected(object sender, SelectedPositionChangedEventArgs e)
        {
            // Why its an object I don't know, but it comes through as an int.
            var position = Convert.ToInt32(e.SelectedPosition);
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
        private void Button_OnClicked(object sender, EventArgs e)
        {
            State.Position = State.Position + 1;
            Carousel.Position = Carousel.Position + 1;
        }
    }
}