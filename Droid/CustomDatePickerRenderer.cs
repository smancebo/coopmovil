using System;
using ibanking.Droid;
using Xamarin.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DatePicker), typeof(CustomDatePickerRenderer))]
namespace ibanking.Droid
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
			Control.SetBackground(Context.GetDrawable(Resource.Drawable.bottom_border));
			Control.SetTextColor(Android.Graphics.Color.ParseColor("#4E6B4C"));

        }
        public CustomDatePickerRenderer()
        {
        }
    }
}
