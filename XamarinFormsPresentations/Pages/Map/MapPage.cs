using System;

using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MapPage : ContentPage
	{
		public MapPage()
		{
			Content = new StackLayout
			{
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}

