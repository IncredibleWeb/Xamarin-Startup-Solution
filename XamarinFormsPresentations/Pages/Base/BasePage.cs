using System;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
	public abstract class BasePage<TViewModel> : ContentPage where TViewModel : BaseViewModel
	{
		#region ViewModel and Binding Context

		/// <summary>
		/// Gets the generically typed ViewModel from the underlying BindingContext.
		/// </summary>
		/// <value>The generically typed ViewModel.</value>
		protected TViewModel ViewModel
		{
			get { return base.BindingContext as TViewModel; }
		}

		/// <summary>
		/// Sets the underlying BindingContext as the defined generic type.
		/// </summary>
		/// <value>The generically typed ViewModel.</value>
		/// <remarks>Enforces a generically typed BindingContext, instead of the underlying loosely object-typed BindingContext.</remarks>
		public new TViewModel BindingContext
		{
			set
			{
				base.BindingContext = value;
				base.OnPropertyChanged("BindingContext");
			}
		}

		#endregion

		#region Global Variables

		protected RelativeLayout relativeLayout;
		protected BoxView shader;
		protected ScrollView scrollView;
		protected Image backgroundImage;
		protected AbsoluteLayout loadingLayout;
		protected int startY = 0;

		#endregion

		#region Services

		//readonly IGAServices GAService = DependencyService.Get<IGAServices>();

		#endregion

		public BasePage()
		{
			//Appearing += (sender, e) => GAService.TrackPage(GetType().Name);

			if (Device.OS == TargetPlatform.iOS)
			{
				startY = 0;
				Icon = "ic_menu.png";
			}

			BaseInitUI();
		}

		public void BaseInitUI()
		{
			relativeLayout = new RelativeLayout();
			relativeLayout.BackgroundColor = Theme.ThemeColor1;
			Content = relativeLayout;

			//Add scrollview to layout
			scrollView = new ScrollView();
			scrollView.BackgroundColor = Theme.ThemeColor1;

			relativeLayout.Children.Add(
				scrollView,
				Constraint.Constant(0),
				Constraint.Constant(startY),
				Constraint.RelativeToParent(parent => parent.Width),
				Constraint.RelativeToParent(parent => parent.Height));
		}

		#region Page Lifecycle Methods

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			GC.Collect();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		#endregion

	}
}
