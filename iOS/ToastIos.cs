using System;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ibanking.iOS.ToastiOS))]
namespace ibanking.iOS
{
    public class ToastiOS :IToast
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 2.0;

        NSTimer alertDelay;
        UIAlertController alert;

        public ToastiOS()
        {
        }

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            alertDelay = NSTimer.CreateScheduledTimer(seconds, (obj) =>
            {
                dissmissMessage();
            });

            alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);
            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void dissmissMessage()
        {
            if(alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if(alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
