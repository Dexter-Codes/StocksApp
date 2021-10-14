using System;
using StocksApp.Controls;
using StocksApp.iOS.Controls;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(NativeFont))]
namespace StocksApp.iOS.Controls
{
    public class NativeFont : INativeFont
    {
        public float GetNativeSize(float size)
        {
            return size * (float)UIScreen.MainScreen.Scale;
        }
    }
}
