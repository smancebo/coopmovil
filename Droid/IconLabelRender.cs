using System;

using Xamarin.Forms;
using Xamarin.Android;
using Xamarin.Forms.Platform.Android;
using ibanking.Controls;
using ibanking.Droid;
using Android.Graphics;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]
namespace ibanking.Droid
{
    public class IconLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var label = Control;
            Typeface font;
            try
            {
                font = Typeface.CreateFromAsset(Forms.Context.Assets, "FontAwesome.ttf");
                label.Typeface = font;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Not Font Found");
            }


        }
    }
}

