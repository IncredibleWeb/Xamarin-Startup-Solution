using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class CarouselItemView : ContentView
    {
        public CarouselItemView()
        {
            var cachedImage = new CachedImage
            {
                Aspect = Aspect.AspectFill,
                DownsampleToViewSize = true,
                //HeightRequest = 500,
                HorizontalOptions = LayoutOptions.Center
            };
            cachedImage.SetBinding(CachedImage.SourceProperty, ".");

            Content = cachedImage;
        }
    }
}