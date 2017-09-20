using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class CarouselPage : BasePage<CarouselViewModel>
    {
        public CarouselPage()
        {
            Title = "Incredible-web photogallery";
            var stackLayout = new StackLayout
            {
                Children ={
                    new CarouselPhotosView()
        },
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            base.scrollView.Content = stackLayout;

        }
    }
}
