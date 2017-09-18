using System;
using ZXing.Net.Mobile.Forms;
using Xamarin.Forms;
using ZXing;

namespace XamarinFormsPresentations.Pages.QRCode
{
    class QrCodePage : BasePage<HomeViewModel>
    {
        private Entry entry;
        private Image imgCode;

        public QrCodePage()
        {
            Title = "Qr Code";
            var label = new Label
            {
                Text = "Insert Your code",
                HorizontalTextAlignment = TextAlignment.Center
            };
            imgCode = new Image();
            entry = new Entry
            {
                Text = "",
                Placeholder = "Insert Your code",
                HorizontalTextAlignment = TextAlignment.Center
            };
            var button = new Button
            {
                Text = "Generate",
            };
            button.Clicked += Button_Clicked;
            

            var stackLayout = new StackLayout
            {
                Children = {
                    label,
                    entry,
                    button,
                    imgCode
                },
                VerticalOptions = LayoutOptions.Center
            };

            base.scrollView.Content = stackLayout;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var QRstream = new ZXingBarcodeImageView
                {
                    BarcodeFormat = BarcodeFormat.QR_CODE,
                    BarcodeValue = entry.Text.Trim(),
                    WidthRequest = 200,
                    HeightRequest = 200
                };
                imgCode = QRstream;
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
