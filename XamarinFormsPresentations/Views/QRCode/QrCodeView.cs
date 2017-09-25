using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace XamarinFormsPresentations
{
    class QrCodeView : ModelBoundContentView<QrCodeViewModel>
    {
        private Entry entry;
        private StackLayout stackLayout;
        private ZXingBarcodeImageView barcodeImageView = new ZXingBarcodeImageView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            AutomationId = "zxingBarcodeImageView",
        };
        public QrCodeView()
        {
            barcodeImageView.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcodeImageView.BarcodeOptions.Width = 300;
            barcodeImageView.BarcodeOptions.Height = 300;
            barcodeImageView.BarcodeOptions.Margin = 10;
            barcodeImageView.BarcodeValue = "ZXing.Net.Mobile";

            #region label
            var label = new Label
            {
                Text = "QR Code Generator",
                HorizontalTextAlignment = TextAlignment.Center,
                FontSize = 25
            };
            #endregion

            #region entry
            entry = new Entry
            {
                Placeholder = "Insert Your code here",
                HorizontalTextAlignment = TextAlignment.Center
            };            
            entry.SetBinding(Entry.TextProperty, "QrCodeValue");
            #endregion          

            #region barcode ImageView
            barcodeImageView = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                BarcodeFormat = ZXing.BarcodeFormat.QR_CODE,
                HeightRequest = 300,
                WidthRequest = 300,
                Margin = 10                
            };
            barcodeImageView.SetBinding(ZXingBarcodeImageView.BarcodeValueProperty, "QrCodeValue");
            #endregion

            stackLayout = new StackLayout
            {
                Children = {
                    label,
                    entry,
                    barcodeImageView                    
                },
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Content = stackLayout;
        }
    }
}