using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Refractored.XamForms.PullToRefresh.iOS;

namespace ibanking.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            PullToRefreshLayoutRenderer.Init();

            LoadApplication(new App());
            UINavigationBar.Appearance.TintColor = UIColor.FromRGB(0, 128, 128);
            UINavigationBar.Appearance.Translucent = true;

            return base.FinishedLaunching(app, options);
        }
    }
}
