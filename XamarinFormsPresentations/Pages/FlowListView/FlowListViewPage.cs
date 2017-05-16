using System;
using System.Collections.ObjectModel;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class FlowListViewPage : BasePage<FlowListViewModel>
	{
		public FlowListViewPage()
		{
			Title = "FlowListView";

			ColumnListView listView = new ColumnListView();
			listView.SetBinding(FlowListView.FlowItemsSourceProperty, "FlowModels");

			base.scrollView.Content = listView;
		}
	}
}
