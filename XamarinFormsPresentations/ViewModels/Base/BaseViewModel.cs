﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public bool IsInitialized { get; set; }

		bool canLoadMore;
		/// <summary>
		/// Gets or sets the "IsBusy" property
		/// </summary>
		/// <value>The isbusy property.</value>
		public const string CanLoadMorePropertyName = "CanLoadMore";

		public bool CanLoadMore
		{
			get { return canLoadMore; }
			set { SetProperty(ref canLoadMore, value, CanLoadMorePropertyName); }
		}

		bool isBusy;
		/// <summary>
		/// Gets or sets the "IsBusy" property
		/// </summary>
		/// <value>The isbusy property.</value>
		public const string IsBusyPropertyName = "IsBusy";

		public bool IsBusy
		{
			get { return isBusy; }
			set { SetProperty(ref isBusy, value, IsBusyPropertyName); }
		}

		bool isValid;
		/// <summary>
		/// Gets or sets the "IsValid" property
		/// </summary>
		/// <value>The isbusy property.</value>
		public const string IsValidPropertyName = "IsValid";

		public bool IsValid
		{
			get { return isValid; }
			set { SetProperty(ref isValid, value, IsValidPropertyName); }
		}

		string subTitle = string.Empty;
		/// <summary>
		/// Gets or sets the "Subtitle" property
		/// </summary>
		public const string SubtitlePropertyName = "Subtitle";

		public string Subtitle
		{
			get { return subTitle; }
			set { SetProperty(ref subTitle, value, SubtitlePropertyName); }
		}

		string icon = null;
		/// <summary>
		/// Gets or sets the "Icon" of the viewmodel
		/// </summary>
		public const string IconPropertyName = "Icon";

		public string Icon
		{
			get { return icon; }
			set { SetProperty(ref icon, value, IconPropertyName); }
		}

		protected void SetProperty<U>(
			ref U backingStore, U value,
			string propertyName,
			Action onChanged = null,
			Action<U> onChanging = null)
		{
			if (EqualityComparer<U>.Default.Equals(backingStore, value))
				return;

			if (onChanging != null)
				onChanging(value);

			OnPropertyChanging(propertyName);

			backingStore = value;

			if (onChanged != null)
				onChanged();

			OnPropertyChanged(propertyName);
		}

		#region INotifyPropertyChanging implementation

		public event PropertyChangingEventHandler PropertyChanging;

		#endregion

		public void OnPropertyChanging(string propertyName)
		{
			if (PropertyChanging == null)
				return;

			PropertyChanging(this, new PropertyChangingEventArgs(propertyName));
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged == null)
				return;

			PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
