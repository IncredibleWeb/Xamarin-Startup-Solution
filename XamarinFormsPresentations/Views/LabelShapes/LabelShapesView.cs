using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class LabelShapesView : ModelBoundContentView<LabelShapesViewModel>
	{
		private CStarLabel starLabel;
		private CDiamondLabel diamondLabel;
		private CCircleLabel circleLabel;
		private CBoxLabel boxLabel;

		public LabelShapesView()
		{
			starLabel = new CStarLabel
			{
				Text = "Star",
				FontSize = 8
			};

			circleLabel = new CCircleLabel
			{
				Text = "Circle",
				FontSize = 8
			};

			diamondLabel = new CDiamondLabel
			{
				Text = "Diamond",
				FontSize = 8
			};

			boxLabel = new CBoxLabel
			{
				Text = "Box",
				FontSize = 8
			};

			var stackLayout = new StackLayout
			{
				Children =
				{
					starLabel,
					circleLabel,
					diamondLabel,
					boxLabel
				},
				VerticalOptions = LayoutOptions.Center
			};

			Content = stackLayout;
		}
	}
}
