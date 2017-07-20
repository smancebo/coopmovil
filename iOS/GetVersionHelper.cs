using System;
using Foundation;
using ibanking.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetVersionHelper))]
namespace ibanking.iOS
{
    public class GetVersionHelper : IVersionGet
    {
        public string GetVersion()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();
        }
    }
}
