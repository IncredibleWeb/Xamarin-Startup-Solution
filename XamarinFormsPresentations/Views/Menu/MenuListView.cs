using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MenuListView : BaseNonPersistentSelectedItemListView
	{
		public MenuListView()
		{
			ItemTemplate = new DataTemplate(typeof(MenuCell));
			RowHeight = (int)RowSizes.MediumRowHeight;
			SeparatorVisibility = SeparatorVisibility.Default;
			SeparatorColor = Color.Transparent;
			BackgroundColor = Theme.ThemeColor3;
		}
	}
}
