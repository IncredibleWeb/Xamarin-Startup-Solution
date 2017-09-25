using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class CarouselPage : BasePage<MenuViewModel>
    {
        public CarouselPage()
        {
            Title = "Incredible-web photogallery";

            base.scrollView.Content = new PhotosView();
        }
    }
}
