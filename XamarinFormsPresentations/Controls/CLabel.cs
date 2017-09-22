using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    public class CLabel : Label
    {
        public CLabel()
        {
            TextColor = Color.Gray;
            VerticalTextAlignment = TextAlignment.Center;
        }
        public CLabel(string text, Color color, int fontsize)
        {
            TextColor = color;
            Text = text;
            FontSize = fontsize;
        }
    }
}
