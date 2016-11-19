using System;

using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MapViewModel : ContentPage
	{
		public MapViewModel()
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

