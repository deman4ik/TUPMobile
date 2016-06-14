using Xamarin.Forms;

namespace TUPMobile.Views
{
    public partial class VotePhotoView : ContentView
    {
        public VotePhotoView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty SourceProperty = BindableProperty.Create("Source", typeof (ImageSource),
            typeof (VotePhotoView), null, propertyChanged: (bindable, oldValue, newValue) =>
            {
                VotePhotoView votePhotoView = (VotePhotoView) bindable;
                votePhotoView.ItemImage.Source = (ImageSource) newValue;
            });


        public static readonly BindableProperty PositionProperty = BindableProperty.Create("Position", typeof (double),
            typeof (VotePhotoView), (double) 0, propertyChanged: (bindable, oldValue, newValue) =>
            {
                VotePhotoView votePhotoView = (VotePhotoView) bindable;
                if (votePhotoView.IsEnabled)
                {
                    if (votePhotoView.Position == 0)
                    {
                        votePhotoView.DownInd.IsVisible = false;
                        votePhotoView.UpInd.IsVisible = false;
                    }
                    else
                    {
                        double opacity;
                        double step = votePhotoView.Height/4;
                        if (votePhotoView.Position > 0)
                        {
                            //Down
                            votePhotoView.DownInd.IsVisible = true;
                            votePhotoView.UpInd.IsVisible = false;
                            opacity = votePhotoView.Position/step;
                            if (opacity > 1)
                            {
                                opacity = 1;
                            }
                            votePhotoView.DownInd.Opacity = opacity;
                        }
                        else
                        {
                            //Up
                            votePhotoView.UpInd.IsVisible = true;
                            votePhotoView.DownInd.IsVisible = false;
                            opacity = votePhotoView.Position/-step;
                            if (opacity > 1)
                            {
                                opacity = 1;
                            }
                            votePhotoView.UpInd.Opacity = opacity;
                        }
                    }
                }
            });

        public ImageSource Source
        {
            set { SetValue(SourceProperty, value); }
            get { return (ImageSource) GetValue(SourceProperty); }
        }

        public double Position
        {
            set { SetValue(PositionProperty, value); }
            get { return (double) GetValue(PositionProperty); }
        }
    }
}