using System;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class ColumnListView : FlowListView
	{
		public ColumnListView()
		{
			FlowColumnCount = 2;
			FlowColumnTemplate = new DataTemplate(typeof(FlowCellImage));
			SeparatorVisibility = SeparatorVisibility.Default;
			HasUnevenRows = true;
		}
	}
}
