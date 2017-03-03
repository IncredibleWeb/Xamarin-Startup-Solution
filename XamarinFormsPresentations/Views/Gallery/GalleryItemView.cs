using System;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class GalleryItemView : ContentView
	{
		public GalleryItemView()
		{
			var cachedImage = new CachedImage
			{
				Aspect = Aspect.AspectFill,
				DownsampleToViewSize = true,
				HeightRequest = 500,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};
			cachedImage.SetBinding(CachedImage.SourceProperty, ".");

			Content = cachedImage;
		}
	}
}
