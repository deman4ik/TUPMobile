using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MR.Gestures;
using TUPMobile.States;
using Xamarin.Forms;
using ContentPage = Xamarin.Forms.ContentPage;

namespace TUPMobile.Pages
{
    // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VotePage : ContentPage
    {
        // private bool _animate;
        private double step;

        public VotePage()
        {
            InitializeComponent();
            App.Store.Subscribe((ApplicationState state) => { BindingContext = state.VotePageState; });
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            step = CurrentImage.Height/3;

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
            double x, y;
            double opacity = 0;
            CurrentImage.TranslationX += e.DeltaDistance.X;
            CurrentImage.TranslationY += e.DeltaDistance.Y;
            x = CurrentImage.TranslationX;
            y = CurrentImage.TranslationY;

            if (y > 0)
            {
                //Dislike
                ThumbDownInd.IsVisible = true;
                opacity = y/step;
                if (opacity > 1)
                {
                    opacity = 1;
                }
                ThumbDownInd.Opacity = opacity;
            }
            else
            {
                //Like
                ThumbUpInd.IsVisible = true;
                opacity = y/-step;
                ThumbUpInd.Opacity = opacity;
            }
        }

        private async void AbsoluteLayout_OnPanned(object sender, PanEventArgs e)
        {
            double x, y;
            ImageSource source;
            x = CurrentImage.TranslationX;
            y = CurrentImage.TranslationY;
            Debug.WriteLine("X: " + x + " Y: " + y);

            if (y > step)
            {
                //Dislike
                Debug.WriteLine("DOWN!!!!");
                source = CurrentItemImage.Source;
                await CurrentImage.TranslateTo(0, 600, 1000, Easing.CubicIn);

                CurrentItemImage.Source = NextItemImage.Source;

                ThumbDownInd.IsVisible = false;

                await NextImage.ScaleTo(1, 1000, Easing.SinIn);
                CurrentImage.TranslationX = 0;
                CurrentImage.TranslationY = 0;

                NextItemImage.Source = source;
                NextImage.Scale = 0.9;
            }
            else
            {
                if (y < -step)
                {
                    //Like
                    Debug.WriteLine("UP!!!!");
                    source = CurrentItemImage.Source;
                    await Task.WhenAll(CurrentImage.TranslateTo(0, -600, 1000, Easing.CubicOut));

                    CurrentItemImage.Source = NextItemImage.Source;

                    ThumbUpInd.IsVisible = false;

                    await NextImage.ScaleTo(1, 1000, Easing.SinIn);
                    CurrentImage.TranslationX = 0;
                    CurrentImage.TranslationY = 0;

                    NextItemImage.Source = source;
                    NextImage.Scale = 0.9;
                }
                else
                {
                    //Return

                    Debug.WriteLine("RETURN INITIAL");
                    ThumbDownInd.IsVisible = false;
                    ThumbUpInd.IsVisible = false;
                    await CurrentImage.TranslateTo(0, 0, 1000, Easing.BounceOut);
                }
            }
        }

        private void OnThumbDownTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("##### OnThumbDownTapped");
            CurrentImage.TranslateTo(0, 0, 1000, Easing.BounceOut);
            ThumbDownInd.IsVisible = false;
            ThumbUpInd.IsVisible = false;
            ThumbDownInd.Opacity = 0;
            ThumbUpInd.Opacity = 0;
        }

        private void OnThumbUpTapped(object sender, EventArgs e)
        {
            Debug.WriteLine("##### OnThumbUpTapped");
        }
    }
}