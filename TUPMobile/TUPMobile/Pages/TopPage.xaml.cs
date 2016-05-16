using System.Collections.Generic;
using TUPMobile.Model;
using Xamarin.Forms;

namespace TUPMobile.Pages
{
    public partial class TopPage : ContentPage
    {
        public TopPage()
        {
            InitializeComponent();
            BindingContext = new List<GalleryItem>
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
            };
        }
    }
}