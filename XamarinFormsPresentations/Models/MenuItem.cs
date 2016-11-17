using System;
namespace XamarinFormsPresentations
{
	public class MenuItem
	{
		public string Title { get; set; }

		public string IconSource { get; set; }

		public Type TargetType { get; set; }

		public BaseViewModel ViewModel { get; set; }
	}
}
