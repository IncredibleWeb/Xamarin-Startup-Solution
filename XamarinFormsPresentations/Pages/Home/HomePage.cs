using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class HomePage : BasePage<HomeViewModel>
	{
		public HomePage()
		{
			Title = "Home";

			var label = new Label
			{
				Text="Welcome to the Xamathon",
				HorizontalTextAlignment=TextAlignment.Center
			};

			var stackLayout = new StackLayout{
				Children = {
					label
				},
				VerticalOptions= LayoutOptions.Center
			};

			base.scrollView.Content = stackLayout;
		}
	}
}
