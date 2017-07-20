using System;
using ibanking.Controls;
using ibanking.iOS;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Foundation;
using UIKit;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace ibanking.iOS
{
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Entry> e)
        {
			base.OnElementChanged(e);

            Control.BorderStyle = UIKit.UITextBorderStyle.None;
			var customEntry = (CustomEntry)e.NewElement;
            if (customEntry != null)
            {
                
                Control.AccessibilityScroll(UIAccessibilityScrollDirection.Left);
                Control.AutoresizingMask = UIViewAutoresizing.FlexibleWidth;
                if (customEntry.SelectAllOnFocus)
                {
                    Control.EditingDidBegin += (sender, ev) =>
                    {
                        this.BeginInvokeOnMainThread(delegate {
                           Control.SelectAll(this);
                        });
                    };
                }

                Control.TouchDown += customEntry.Click;
            }
             
          

        }


    }
}
