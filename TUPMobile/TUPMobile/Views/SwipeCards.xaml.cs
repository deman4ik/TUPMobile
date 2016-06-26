using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MR.Gestures;
using tupapi.Shared.DataObjects;
using Xamarin.Forms;
using ContentView = Xamarin.Forms.ContentView;

namespace TUPMobile.Views
{
    public partial class SwipeCards : ContentView
    {
        public SwipeCards()
        {
            InitializeComponent();
        }

        public VotePhotoView Current => FirstItem.IsEnabled ? FirstItem : SecondItem;
        public VotePhotoView Next => FirstItem.IsEnabled ? SecondItem : FirstItem;

        public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source",
            typeof (IList<QueuePost>),
            typeof (SwipeCards), null, propertyChanged: (bindable, oldValue, newValue) =>
            {
                Debug.WriteLine("SourceProperty CHANGED!");
                SwipeCards swipeCards = (SwipeCards) bindable;
                var items = (IList<QueuePost>) newValue;
                var count = items.Count;
                Debug.WriteLine(count);
                if (count == 0)
                {
                    swipeCards.Current.IsVisible = false;
                    swipeCards.LoadingItems.IsVisible = true;
                }
                else
                {
                    if (count > 0 && !swipeCards.Current.IsVisible)
                    {
                        swipeCards.Current.Source = items[0].Url;
                        swipeCards.Current.IsVisible = true;
                        swipeCards.LoadingItems.IsVisible = false;
                    }
                    if (count > 1 && !swipeCards.Next.IsVisible)
                    {
                        swipeCards.Next.Source = items[1].Url;
                        swipeCards.Next.IsVisible = true;
                    }
                }
            });

        public IList<QueuePost> Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (IList<QueuePost>) GetValue(SourceProperty); }
        }

        private void SetNextCurrent()
        {
            Current.Position = 0;
            if (FirstItem.IsEnabled)
            {
                FirstItem.IsEnabled = false;
                SecondItem.IsEnabled = true;
            }
            else
            {
                FirstItem.IsEnabled = true;
                SecondItem.IsEnabled = false;
            }
            Container.RaiseChild(Current);

            Debug.WriteLine("### SetNextCurrent ###");
            Debug.WriteLine(Source.Count);
            if (Source.Count > 0)
                Source.RemoveAt(0);
            else
            {
                Current.IsVisible = false;
                LoadingItems.IsVisible = true;
            }
            Debug.WriteLine(Source.Count);
            if (Source.Count == 0)
                Next.IsVisible = false;
            else
            {
                Next.Source = Source[0].Url;
                Next.Scale = 0.9;
                Next.TranslationX = 0;
                Next.TranslationY = 0;
            }
        }

        private void Container_OnPanning(object sender, PanEventArgs e)
        {
            if (Current.IsEnabled)
            {
                Current.TranslationX += e.DeltaDistance.X;
                Current.TranslationY += e.DeltaDistance.Y;
                Current.Position = Current.TranslationY;
            }
        }

        private async void Container_OnPanned(object sender, PanEventArgs e)
        {
            if (Current.IsEnabled)
            {
                double step = Current.Height/4;
                if (Current.Position > step)
                {
                    await Current.TranslateTo(0, 600, 500, Easing.CubicIn);
                    await Next.ScaleTo(1, 500, Easing.SinIn);
                    SetNextCurrent();
                }
                else
                {
                    if (Current.Position < -step)
                    {
                        await Task.WhenAll(Current.TranslateTo(0, -600, 500, Easing.CubicOut));
                        await Next.ScaleTo(1, 500, Easing.SinIn);
                        SetNextCurrent();
                    }
                    else
                    {
                        Current.Position = 0;
                        await Current.TranslateTo(0, 0, 1000, Easing.BounceOut);
                    }
                }
            }
        }
    }
}