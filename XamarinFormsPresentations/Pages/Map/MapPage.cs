using System;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace XamarinFormsPresentations
{
	public class MapPage : BasePage<MapViewModel>
	{
		public MapPage()
		{			
			var map = new Map(
			MapSpan.FromCenterAndRadius(
					new Position(35.9375, 14.3754), Distance.FromMiles(2)))
			{
				IsShowingUser = true,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			//Add PIN at MIC
			map.Pins.Add(new Pin { Position = new Position(35.8513,14.4943), Label="MIC Xamathon" });

			//Add PIN at Incredible Web
			map.Pins.Add(new Pin { Position = new Position(35.9033, 14.4843), Label = "Incredible Web Ltd" });

			//Add PIN at Bumalift
			map.Pins.Add(new Pin { Position = new Position(35.9034, 14.4844), Label = "Bumalift" });

			var stack = new StackLayout { Spacing = 0 };
			stack.Children.Add(map);


			base.relativeLayout.Children.Add(stack,
			                                 Constraint.Constant(0),
			                                 Constraint.Constant(0),
			                                 Constraint.RelativeToParent((parent) => parent.Width),
			                                 Constraint.RelativeToParent((parent) => parent.Height-10));											 
		}
	}
}

