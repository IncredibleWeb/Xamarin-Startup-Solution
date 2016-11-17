using System;
using System.Collections.ObjectModel;

namespace XamarinFormsPresentations
{
public class MenuViewModel : BaseViewModel
	{
		ObservableCollection<MenuItem> menuItems;

		public ObservableCollection<MenuItem> MenuItems
		{
			get { return menuItems; }
			set
			{
				menuItems = value;
				OnPropertyChanged("MenuItems");
			}
		}

		public MenuViewModel()
		{
			this.menuItems = new ObservableCollection<MenuItem>();
			initMenuItems();
		}

		private void initMenuItems()
		{
			menuItems.Add(new MenuItem
			{
				Title = "Home",
				IconSource = "ic_home",
				TargetType = typeof(HomePage),
				ViewModel = new HomeViewModel() { IsInitialized = false }
			});

			menuItems.Add(new MenuItem
			{
				Title = "News",
				IconSource = "ic_news",
				TargetType = typeof(NewsPage),
				ViewModel = new NewsViewModel()
			});

			menuItems.Add(new MenuItem
			{
				Title = "Contact Us",
				IconSource = "ic_contactus",
				TargetType = typeof(ContactUsPage),
				ViewModel = new ContactUsViewModel()
			});
		}
	}
}
