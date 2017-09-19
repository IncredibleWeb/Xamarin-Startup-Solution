using System;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;

namespace XamarinFormsPresentations
{
    class QrCodePage : BasePage<HomeViewModel>
    {
        private Entry entry;
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
                Text = "Insert Your code",
                HorizontalTextAlignment = TextAlignment.Center
            };

            entry = new Entry
            {
                Placeholder = "Insert Your code",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var button = new Button
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
                    //if(stackLayout.Children.Count>=4)
                    //{ stackLayout.Children.RemoveAt(3); }
                    stackLayout.Children.Add(barcode);
                });
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                DisplayAlert("Alert", "Enter value that want to be carried in the QR Code", "OK");
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
