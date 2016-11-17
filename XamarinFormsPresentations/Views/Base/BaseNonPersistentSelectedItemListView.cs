using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public abstract class BaseNonPersistentSelectedItemListView : ListView
	{
		protected BaseNonPersistentSelectedItemListView() : base(ListViewCachingStrategy.RecycleElement)
		{
			// This prevents the ugly default highlighting of the selected cell upon navigating back to a list view.
			ItemSelected += (sender, e) => SelectedItem = null;
		}
	}
}
