using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MenuPage : BasePage<MenuViewModel>
	{
		public MenuListView MenuListView;
		public MenuHeaderView MenuHeaderView;

		public MenuPage()
		{
			Title = "Xamarin";

			#region Menu list
			MenuListView = new MenuListView();
			MenuListView.SetBinding(MenuListView.ItemsSourceProperty, "MenuItems");

			MenuHeaderView = new MenuHeaderView();
			#endregion

			#region Compose view hierarchy		
			var stackLayout = new StackLayout()
			{
				Orientation = StackOrientation.Vertical,
				Children = {
					MenuHeaderView,
					MenuListView
				},
				Spacing = 0
			};

			// set the padding
			Device.OnPlatform(iOS: () =>
			{
				stackLayout.Padding = new Thickness(0, 20, 0, 0);
			}, Default: () =>
			{
				stackLayout.Padding = new Thickness(0, 0, 0, 0);
			});

			scrollView.Content = stackLayout;

			#endregion
		}
	}
}
