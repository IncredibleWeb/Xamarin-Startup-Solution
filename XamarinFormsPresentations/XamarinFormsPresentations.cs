using System;

using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public class App : Application
	{
		public static MasterPage MasterPage;

		public App()
		{
			// The root page of your application
			MasterPage = new MasterPage();
			MainPage = MasterPage;
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
