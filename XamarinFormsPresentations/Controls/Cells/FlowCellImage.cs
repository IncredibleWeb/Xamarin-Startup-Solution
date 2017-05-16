using System;
using DLToolkit.Forms.Controls;
using FFImageLoading.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FlowCellImage : FlowViewCell
	{
		public FlowCellImage()
		{
			var cachedImage = new CachedImage
			{
				Aspect = Aspect.AspectFill,
				DownsampleToViewSize = true,
				HeightRequest = 100,
			};
			cachedImage.SetBinding(CachedImage.SourceProperty, "ThumbnailUrl");

			var title = new Label
			{
				TextColor = Theme.ThemeColor3,
			};
			title.SetBinding(Label.TextProperty, "Title");

			var stackLayout = new StackLayout
			{
				Children ={
					title,
					cachedImage
				}
			};

			Content = stackLayout;
		}
	}
}
