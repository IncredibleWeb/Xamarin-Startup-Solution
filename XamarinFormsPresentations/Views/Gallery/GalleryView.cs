using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class GalleryView : CarouselView
	{
		public GalleryView()
		{
			ItemTemplate = new DataTemplate(typeof(GalleryItemView));
			this.SetBinding(GalleryView.ItemsSourceProperty, "ImageUrls");
			HeightRequest = 250;
		}
	}
}
