using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFShapeView;

namespace XamarinFormsPresentations
{
    class CDiamondLabel : ShapeView
    {
        private CLabel contentText = new CLabel
        {
            Text = "",
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
            HorizontalOptions = LayoutOptions.Fill,
            VerticalOptions = LayoutOptions.Fill,
            VerticalTextAlignment = TextAlignment.Center,
            HorizontalTextAlignment = TextAlignment.Center
        };

        public string Text
        {
            get
            {
                return contentText.Text;
            }
            set
            {
                contentText.Text = value;
            }
        }

        public double FontSize
        {
            get
            {
                return contentText.FontSize;
            }
            set
            {
                contentText.FontSize = value;
            }

        }
        public CDiamondLabel()
        {
            ShapeType = ShapeType.Diamond;
            Color = Color.Blue;
            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;
            BorderWidth = 0f;
            HeightRequest = 100;
            WidthRequest = 100; ;
            Content = contentText;
        }
        public static implicit operator Label(CDiamondLabel ccl)
        {
            throw new NotImplementedException();
        }
    }
}
