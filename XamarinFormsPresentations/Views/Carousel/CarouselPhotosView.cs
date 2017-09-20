using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations { 
    
    public class CarouselPhotosView : CarouselView
    {
        CachedImage arrowLeft, arrowRight;
        //CLabel positionLabel, photoCountLabel;
        

        public CarouselPhotosView()
        {
            ItemTemplate = new DataTemplate(typeof(GalleryItemView));
            this.SetBinding(GalleryView.ItemsSourceProperty, "ImageUrls");
             HeightRequest = 250;
             VerticalOptions = LayoutOptions.FillAndExpand;
             Position = 0;
             

            arrowLeft = new CachedImage
            {
                Source = "ic_arrow_left_black.png",
                Aspect = Aspect.Fill,
                HeightRequest = 50,
                WidthRequest = 50,
                Margin = new Thickness(0, 15, 0, 15),
                DownsampleToViewSize = true,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };
            arrowRight= new CachedImage
            {
                Source = "ic_arrow_right_black.png",
                Aspect = Aspect.Fill,
                HeightRequest = 50,
                WidthRequest = 50,
                Margin = new Thickness(0, 15, 0, 15),
                DownsampleToViewSize = true,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
              {
                  if (s == arrowLeft)
                  {
                      Position -= 1;
                  }
                  if (s == arrowRight)
                  {
                      Position += 1;
                  }
              };
            arrowLeft.GestureRecognizers.Add(tapGestureRecognizer);
            arrowRight.GestureRecognizers.Add(tapGestureRecognizer);
            var arrowsGridLayout = new Grid
            {
                Margin = 0,
                Padding = 0,
                RowSpacing = 0,
                ColumnSpacing = 0,
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)},
                    new ColumnDefinition{Width=new GridLength(1, GridUnitType.Star)}
                }
            };

            arrowsGridLayout.Children.Add(arrowLeft, 0, 1, 0, 1);
            arrowsGridLayout.Children.Add(arrowRight, 2, 3, 0, 1);

            var contentStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Margin = new Thickness(10, 10, 10, 10),
                Spacing = 0,
                
                
            };

            contentStackLayout.Children.Add(arrowsGridLayout);
            //Content = contentStackLayout;

        }
    }
}


