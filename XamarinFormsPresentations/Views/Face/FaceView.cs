using System;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FaceView : ModelBoundContentView<FaceViewModel>
	{
		public FaceView()
		{
			#region Profile Pic

			var boxBackground = new BoxView
			{
				BackgroundColor = Theme.ThemeColor2,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var profileImage = new CachedImage
			{
				Aspect = Aspect.Fill,
				HeightRequest = 180,
				WidthRequest = 180,
				DownsampleToViewSize = true,
				TransparencyEnabled = false,
				HorizontalOptions = LayoutOptions.Center,
				Transformations = {
					new CircleTransformation(10,"#FFF")
				}
			};
			profileImage.SetBinding(CachedImage.SourceProperty, "ImageUrl");

			#endregion

			#region Change Image Button

			var button = new Button
			{
				BackgroundColor = Color.Transparent,
				Text="Take Pic",
				TextColor = Theme.ThemeColor4,				
				HeightRequest = 100,
				WidthRequest = 200,
				FontFamily = "FontAwesome"
			};
			button.SetBinding(Button.CommandProperty, "TakePictureCommand");

			#endregion


			//Page relative layout
			var relativeLayout = new RelativeLayout
			{
				HeightRequest = 200,
				WidthRequest = 200
			};

			relativeLayout.Children.Add(boxBackground,
										Constraint.Constant(0),
										Constraint.Constant(0),
										Constraint.RelativeToParent(parent => parent.Width),
										Constraint.RelativeToParent(parent => parent.Height));

			relativeLayout.Children.Add(profileImage,
										Constraint.RelativeToParent(parent => (parent.Width / 2) - 90),
										Constraint.RelativeToParent(parent => (parent.Height / 2) - 90),
										Constraint.Constant(180),
										Constraint.Constant(180));

			relativeLayout.Children.Add(button,
										Constraint.RelativeToParent(parent => (parent.Width / 2) - 50),
										Constraint.RelativeToParent(parent => (parent.Height / 2) - 50),
										Constraint.Constant(100),
										Constraint.Constant(100));


			Content = relativeLayout;
		}
	}
}
