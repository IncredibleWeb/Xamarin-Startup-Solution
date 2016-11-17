using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MenuHeaderView : ModelBoundContentView<MenuViewModel>
	{
		public MenuHeaderView()
		{
			var menuImage = new Image
			{
				Source = "menu_Image.jpg",
				Aspect = Aspect.AspectFit
			};

			var menuImageStackLayout = new StackLayout
			{
				Padding = new Thickness(0),
				Children = { menuImage },
				Orientation = StackOrientation.Vertical,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.Fill,
				Spacing = 0
			};

			var boxView = new BoxView
			{
				BackgroundColor = Theme.ThemeColor3.MultiplyAlpha(0.7)
			};

			var label = new Label
			{
				Text = "Xamathon Menu",
				TextColor = Theme.ThemeColor4,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
			};

			var relativeLayout = new RelativeLayout();
			relativeLayout.Children.Add(menuImageStackLayout,
				Constraint.Constant(0),
				Constraint.Constant(0),
				Constraint.RelativeToParent(parent => parent.Width),
				Constraint.Constant(160));


			relativeLayout.Children.Add(boxView,
				Constraint.Constant(0),
				Constraint.Constant(110),
				Constraint.RelativeToParent(parent => parent.Width),
				Constraint.Constant(50));

			relativeLayout.Children.Add(label,
				Constraint.Constant(0),
				Constraint.Constant(110),
				Constraint.RelativeToParent(parent => parent.Width),
				Constraint.Constant(50));



			//View Layout
			Content = relativeLayout;
		}
	}
}
