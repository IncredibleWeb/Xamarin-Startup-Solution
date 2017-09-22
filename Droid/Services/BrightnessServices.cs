using System;
using Android.App;
using XamarinFormsPresentations.Services.Interfaces;
using XamarinFormsPresentations.Droid;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(BrightnessServices))]
namespace XamarinFormsPresentations.Droid
{
    class BrightnessServices : IBrightnessServices
    {
        float IBrightnessServices.SetBrightness(float brightnessValue)
        {
            var activity = (Activity)Forms.Context;
            var attributes = activity.Window.Attributes;

            var oldValue = attributes.ScreenBrightness;

            attributes.ScreenBrightness = brightnessValue;//1.0f;
            activity.Window.Attributes = attributes;

            return oldValue;
        }
    }
}
