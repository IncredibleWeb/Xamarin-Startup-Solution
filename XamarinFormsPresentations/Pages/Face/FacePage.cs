using System;
using Microsoft.ProjectOxford.Face;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FacePage : BasePage<FaceViewModel>
	{
		public FacePage()
		{
			Title = "Face Recognition";

			var pageStackLayout = new StackLayout
			{
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					new FaceView(),
					new FaceActionView(),
					new FaceDetails()
				}
			};

			this.scrollView.Content = pageStackLayout;
		}
	}
}
