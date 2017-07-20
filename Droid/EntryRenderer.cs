using System;
using Android.Graphics.Drawables;
using ibanking.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(Entry), typeof(CustomNaviveEntryRenderer))]
namespace ibanking.Droid
{
    public class CustomNaviveEntryRenderer : EntryRenderer
    {
        public CustomNaviveEntryRenderer()
        {
            
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
            base.OnElementChanged(e);


            Control.SetBackground(Context.GetDrawable(Resource.Drawable.bottom_border));
            Control.SetTextColor(Android.Graphics.Color.ParseColor("#4E6B4C"));
            if(e.NewElement.InputTransparent)
            {
                Control.Focusable = false;
                Control.SetHorizontallyScrolling(true);
            }
        }
    }
}
