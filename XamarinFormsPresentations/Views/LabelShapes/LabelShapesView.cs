using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class LabelShapesView : ModelBoundContentView<HomeViewModel>
    {
        CStarLabel star;
        CDiamondLabel diamond;
        CCircleLabel circle;
        CBoxLabel box;
         public LabelShapesView()
        {
            star = new CStarLabel
            {
                Text = "Star",
                FontSize = 8
            };
            circle = new CCircleLabel
            {
                Text = "Circle",
                FontSize = 8
            };
            diamond = new CDiamondLabel
            {
                Text = "Diamond",
                FontSize = 8
            };
            box = new CBoxLabel
            {
                Text = "Box",
                FontSize = 8
            };

            var stackLayout = new StackLayout
            {
                Children =
                {
                    star,
                    circle,
                    diamond,
                    box
                },
                VerticalOptions = LayoutOptions.Center
            };

            Content = stackLayout;
        }
    }
}
