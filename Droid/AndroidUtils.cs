using System;
using ibanking.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidUtils))]
namespace ibanking.Droid
{
    public class AndroidUtils : IAdroidUtils
    {
        public AndroidUtils()
        {
            
        }

        public void Close_App()
        {
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }

        public void SetStatusBarColor(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
