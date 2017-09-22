using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class CarouselItemView : ModelBoundContentView<CarouselViewModel>
    {
        public CarouselItemView()
        {
            var cachedImage = new CachedImage
            {
                Aspect = Aspect.AspectFill,
                DownsampleToViewSize = true,
                HeightRequest = 250,
                WidthRequest = 500,
                HorizontalOptions = LayoutOptions.Center
            };
            cachedImage.SetBinding(CachedImage.SourceProperty, ".");

            Content = cachedImage;
        }

        public static implicit operator CarouselItemView(CarouselPhotosView v)
        {
            throw new NotImplementedException();
        }
    }
}