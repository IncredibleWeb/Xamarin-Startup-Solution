using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FFImageLoading.Forms.Touch;
using Foundation;
using UIKit;

namespace XamarinFormsPresentations.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			//Navigation Bar
			UINavigationBar.Appearance.BarTintColor = UIColor.FromRGB((nfloat)Theme.ThemeColor3.R, (nfloat)Theme.ThemeColor3.G, (nfloat)Theme.ThemeColor3.B);
			UINavigationBar.Appearance.TintColor = UIColor.White;
			UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes() { TextColor = UIColor.White });

			CachedImageRenderer.Init();

			var cv = typeof(Xamarin.Forms.CarouselView);
			var assembly = Assembly.Load(cv.FullName);

			Xamarin.FormsMaps.Init();

			global::Xamarin.Forms.Forms.Init();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
