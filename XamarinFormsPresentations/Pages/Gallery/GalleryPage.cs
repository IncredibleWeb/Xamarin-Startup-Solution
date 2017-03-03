using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class GalleryPage : BasePage<GalleryViewModel>
	{
		public GalleryPage()
		{
			var stackLayout = new StackLayout
			{
				Children ={
					new GalleryView()
				},
				VerticalOptions = LayoutOptions.StartAndExpand
			};

			base.scrollView.Content = stackLayout;
		}
	}
}
