using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MenuCell : ImageCell
	{
		public MenuCell() : base()
		{
			this.StyleId = "disclosure";
			this.TextColor = Theme.ThemeColor4;
			this.SetBinding(MenuCell.TextProperty, "Title");
			this.SetBinding(MenuCell.ImageSourceProperty, "IconSource");
		}
	}
}
