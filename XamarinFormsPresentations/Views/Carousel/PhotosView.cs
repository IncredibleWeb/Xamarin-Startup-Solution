using System;
using FFImageLoading.Forms;
using Xamarin.Forms;
using CarouselView.FormsPlugin.Abstractions;

namespace XamarinFormsPresentations
{
    public class PhotosView : ModelBoundContentView<HomeViewModel>
    {
        private CarouselPhotosView carouselPhotos;
        private CarouselViewModel carouselViewModel;
        private CachedImage arrowLeftImage, arrowRightImage;
        private CLabel label, positionLabel, photoCountLabel;
        private int imageUrlsListSize;

        public PhotosView()
        {
            carouselPhotos = new CarouselPhotosView();
            carouselViewModel= new CarouselViewModel();
            imageUrlsListSize = carouselViewModel.ImageUrls.GetCount();
            carouselPhotos.PropertyChanged += carouselPhotosProperty_PropertyChanged;
            label = new CLabel()
            {
                Text = "Photogallery",
                FontSize = 35
            };
            positionLabel = new CLabel
            {
                Text = (carouselPhotos.Position + 1).ToString(),
                
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Theme.ThemeColor5,
                FontAttributes = FontAttributes.Bold,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                LineBreakMode = LineBreakMode.WordWrap
            };

            photoCountLabel = new CLabel
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Theme.ThemeColor5,
                FontAttributes = FontAttributes.None,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                LineBreakMode = LineBreakMode.WordWrap,
               
            };

            StackLayout labelStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.Center,
                Spacing = 0,
                Margin = new Thickness(0, 20, 0, 20),
                Children = {
                    positionLabel,
                    photoCountLabel,

                }
            };

            arrowLeftImage = new CachedImage
            {
                Source = "ic_arrow_left_black.png",
                Aspect = Aspect.Fill,
                HeightRequest = 50,
                WidthRequest = 50,
                Margin = new Thickness(0, 15, 0, 15),
                DownsampleToViewSize = true,
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            arrowRightImage = new CachedImage
            {
                Source = "ic_arrow_right_black.png",
                Aspect = Aspect.Fill,
                HeightRequest = 50,
                WidthRequest = 50,
                Margin = new Thickness(0, 15, 0, 15),
                DownsampleToViewSize = true,
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (s == arrowLeftImage)
                {
                    
                    carouselPhotos.Position = carouselPhotos.Position - 1;
                }
                if (s == arrowRightImage)
                {
                    carouselPhotos.Position = carouselPhotos.Position + 1;
                }
            };
            arrowLeftImage.GestureRecognizers.Add(tapGestureRecognizer);
            arrowRightImage.GestureRecognizers.Add(tapGestureRecognizer);

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

            arrowsGridLayout.Children.Add(arrowLeftImage, 0, 1, 0, 1);
            arrowsGridLayout.Children.Add(labelStackLayout, 1, 2, 0, 1);
            arrowsGridLayout.Children.Add(arrowRightImage, 2, 3, 0, 1);

            var contentStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.Fill,
                Margin = new Thickness(10, 10, 10, 10),
                Spacing = 0,
                Children = {
                    label,
                    carouselPhotos,
                    arrowsGridLayout
                
                }
            };
            Content = contentStackLayout; 
        }
        
        void carouselPhotosProperty_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Hide/Show arrows
            if (carouselPhotos.Position == 0)
            {
                arrowLeftImage.IsVisible = false;
            }
            else
            {
                arrowLeftImage.IsVisible = true;
            }
            if (carouselPhotos.Position == imageUrlsListSize - 1)
            {
                arrowRightImage.IsVisible = false;
            }
            else
            {
                arrowRightImage.IsVisible = true;
            }
            positionLabel.Text = (carouselPhotos.Position + 1).ToString()+ " of " +(imageUrlsListSize).ToString();
            
        }
    }
}



