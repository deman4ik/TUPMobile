using System;
using Xamarin.Forms;

namespace TUPMobile.Templates
{
    public partial class ArticleItemTemplate : ContentView
    {
        public ArticleItemTemplate()
        {
            InitializeComponent();
        }

        private void OnTapGestureRecognizerTapped(object sender, EventArgs e)
        {
            Element current = this;

            while (current.Parent != null)
            {
                current = current.Parent;
                if (current.GetType().Name == "CarouselView")
                {
                    break;
                }
            }

            //CarouselView carousel = (CarouselView) current;
            //carousel.Position = carousel.Position + 1;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
        }
    }
}