using CarouselView.FormsPlugin.Abstractions;
using FFImageLoading.Forms;
using Xamarin.Forms;


namespace XamarinFormsPresentations
{

    public class CarouselPhotosView : CarouselViewControl
    {
        public CarouselPhotosView()
        {
            ItemTemplate = new DataTemplate(typeof(CarouselItemView));
            this.SetBinding(CarouselPhotosView.ItemsSourceProperty, "ImageUrls");
            ItemTemplate = new DataTemplate(typeof(CarouselItemView));
			HeightRequest = 220;
            WidthRequest = 500;
            Orientation = CarouselViewOrientation.Horizontal;
			InterPageSpacing = 20;
			Position = 0;
			ShowArrows = true;
			BackgroundColor = Theme.ThemeColor1;
			CurrentPageIndicatorTintColor = Theme.ThemeColor5;
			IndicatorsTintColor = Theme.ThemeColor2;
			ShowIndicators = true;
		
        }
    }
}
