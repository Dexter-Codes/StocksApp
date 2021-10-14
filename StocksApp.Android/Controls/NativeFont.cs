using System;
using Android.Util;
using StocksApp.Controls;
using StocksApp.Droid.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(NativeFont))]
namespace StocksApp.Droid.Controls
{
    public class NativeFont : INativeFont
    {
        public float GetNativeSize(float size)
        {
            var displayMetrics = Android.App.Application.Context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, size, displayMetrics);
        }
    }
}
