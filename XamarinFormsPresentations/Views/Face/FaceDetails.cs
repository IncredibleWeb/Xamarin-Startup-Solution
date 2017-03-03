using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FaceDetails : ModelBoundContentView<FaceViewModel>
	{
		public FaceDetails()
		{
			var nameLabel = new Label
			{
				
			};
			nameLabel.SetBinding(Label.TextProperty, "Name");

			var ageLabel = new Label
			{

			};
			ageLabel.SetBinding(Label.TextProperty, "Age");

			var glassesLabel = new Label
			{

			};
			glassesLabel.SetBinding(Label.TextProperty, "Glasses");

			var smileLabel = new Label
			{

			};
			smileLabel.SetBinding(Label.TextProperty, "Smile");

			var viewStackLayout = new StackLayout
			{
				Children ={
					nameLabel,
					ageLabel,
					glassesLabel,
					smileLabel
				},
				Padding = new Thickness(10),
				Spacing=10
			};

			Content = viewStackLayout;
		}
	}
}
