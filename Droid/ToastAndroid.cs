using System;
using Android;
using Android.Widget;
using ibanking.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(ToastAndroid))]
namespace ibanking.Droid
{
    public class ToastAndroid : IToast
    {
        public ToastAndroid()
        {
            
        }

        public void LongAlert(string message)
        {
            Toast.MakeText(Forms.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Forms.Context, message, ToastLength.Short).Show();
        }
    }
}
