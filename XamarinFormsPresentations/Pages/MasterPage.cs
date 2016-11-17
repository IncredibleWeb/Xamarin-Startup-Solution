using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class MasterPage : MasterDetailPage
	{
		MenuPage menuPage;

		public MasterPage()
		{
			menuPage = new MenuPage();
			menuPage.BindingContext = new MenuViewModel();

			menuPage.MenuListView.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

			Master = menuPage;
			SetHome();
		}

		void NavigateTo(MenuItem menu)
		{
			if (menu == null)
				return;

			Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
			displayPage.BindingContext = menu.ViewModel;

			Detail = new NavigationPage(displayPage);
			menuPage.MenuListView.SelectedItem = null;

			Device.StartTimer(new TimeSpan(0, 0, 0, 0, 300), () => { IsPresented = false; return false; });
		}

		public void SetHome()
		{
			Detail = new NavigationPage(new HomePage { BindingContext = new HomeViewModel() });
		}
	}
}
