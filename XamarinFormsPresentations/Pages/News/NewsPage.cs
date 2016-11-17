using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{ 
	public class NewsPage : BasePage<NewsViewModel>
	{
		public NewsPage()
		{
			Title = "News";

			var label = new Label
			{
				Text = "News Page",
				HorizontalTextAlignment = TextAlignment.Center
			};

			var button = new Button
			{
				Text="Check Binding"
			};
			button.Clicked+= Button_Clicked;

			var stackLayout = new StackLayout
			{
				Children = {
					label,
					button
				},
				VerticalOptions = LayoutOptions.Center
			};

			base.scrollView.Content = stackLayout;
		}

		void Button_Clicked(object sender, EventArgs e)
		{
			App.MasterPage.Detail.Navigation.PushAsync(new SliderTransformPage());
		}
	}
}
