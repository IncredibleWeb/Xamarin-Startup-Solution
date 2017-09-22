using System;
using UIKit;
using XamarinFormsPresentations.Services.Interfaces;
using XamarinFormsPresentations.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(BrightnessServices))]
namespace XamarinFormsPresentations.iOS
{
    public class BrightnessServices : IBrightnessServices
    {
        float IBrightnessServices.SetBrightness(float brightnessValue)
        {
            var oldValue = UIScreen.MainScreen.Brightness;
            UIScreen.MainScreen.Brightness = (nfloat)brightnessValue;//0;

            return (float)oldValue;
            //var activity = (Activity)Forms.Context;
            //var attributes = activity.Window.Attributes;

            //attributes.ScreenBrightness = brightnessValue;//1.0f;
            //activity.Window.Attributes = attributes;
        }
    }
}