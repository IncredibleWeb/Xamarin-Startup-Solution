using System;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    class QrCodePage : BasePage<HomeViewModel>
    {
        private Entry entry;
        private Button button;
        private StackLayout stackLayout;
        private ZXingBarcodeImageView barcode =  new ZXingBarcodeImageView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            AutomationId = "zxingBarcodeImageView",
        };
        public QrCodePage()
        {
            Title = "Qr Code";
            
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "ZXing.Net.Mobile";
            
            var label = new Label
            {
                Text = "QR Code Generator",
                HorizontalTextAlignment = TextAlignment.Center
            };

            entry = new Entry
            {
                Placeholder = "Insert Your code here",
                HorizontalTextAlignment = TextAlignment.Center
            };
            button = new Button
            {
                Text = "Generate",
            };
            button.Clicked += Button_Clicked;
            

             stackLayout = new StackLayout
            {

                Children = {
                    label,
                    entry,
                    button
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            base.scrollView.Content = stackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                   barcode= new ZXingBarcodeImageView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        AutomationId = "zxingBarcodeImageView",
                        BarcodeFormat = ZXing.BarcodeFormat.QR_CODE,
                        HeightRequest = 300,
                        WidthRequest = 300,
                        Margin = 10,
                        BarcodeValue = entry.Text
                    };
                    stackLayout.Children.Clear();
                    stackLayout.Children.Add(barcode);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                DisplayAlert("Alert", "Enter value that want to be carried in the QR Code", "OK");
            }

        }
        private readonly IBrightnessServices brightnessServices = DependencyService.Get<IBrightnessServices>();
        float screenBrightnessValue;
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
