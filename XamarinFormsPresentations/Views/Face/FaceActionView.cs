using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FaceActionView : ModelBoundContentView<FaceViewModel>
	{
		public FaceActionView()
		{
			var button = new Button
			{
				Text="Identify",
				BackgroundColor= Theme.ThemeColor3,
				TextColor = Theme.ThemeColor4
			};
			button.SetBinding(Button.CommandProperty, "RecognizePictureCommand");

			this.Padding = new Thickness(10);

			Content = button;
		}
	}
}
