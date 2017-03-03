﻿using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;

namespace XamarinFormsPresentations.Droid
{
	[Activity(Label = "XamarinFormsPresentations.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
		    Xamarin.FormsMaps.Init(this, bundle);

			FFImageLoading.Forms.Droid.CachedImageRenderer.Init();

			//Init User Dialogs
			UserDialogs.Init(this);

			LoadApplication(new App());
		}
	}
}
