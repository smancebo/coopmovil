using System;
using Android.Views;
using ibanking.Controls;
using ibanking.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ibanking.Droid
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);

            Control.SetBackground(Context.GetDrawable(Resource.Drawable.bottom_border));
            Control.SetTextColor(Android.Graphics.Color.ParseColor("#4E6B4C"));
            if (e.NewElement.InputTransparent)
            {
                Control.Focusable = false;
                Control.SetHorizontallyScrolling(true);
            }

            var customEntry = (CustomEntry)e.NewElement;
            Control.SetSelectAllOnFocus(customEntry.SelectAllOnFocus);

            Control.Click += customEntry.Click;
        }
    }
}
