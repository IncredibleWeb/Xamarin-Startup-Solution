using CarouselView.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class GalleryView : CarouselViewControl
	{
		public GalleryView()
		{
			ItemTemplate = new DataTemplate(typeof(GalleryItemView));
			this.SetBinding(GalleryView.ItemsSourceProperty, "ImageUrls");
			HeightRequest = 250;
		}
	}
}
