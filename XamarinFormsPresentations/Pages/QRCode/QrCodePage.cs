using System;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    class QrCodePage : BasePage<QrCodeViewModel>
    {
        private readonly IBrightnessServices brightnessServices = DependencyService.Get<IBrightnessServices>();
        private float screenBrightnessValue;

        public QrCodePage()
        {
            Title = "Qr Code";
            base.scrollView.Content = new QrCodeView();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            screenBrightnessValue = brightnessServices.SetBrightness(1);

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //brightnessServices.SetBrightness(-1);
            brightnessServices.SetBrightness(screenBrightnessValue);
        }
        
    }
}
