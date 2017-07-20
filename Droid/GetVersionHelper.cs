using System;
using ibanking.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(GetVersionHelper))]
namespace ibanking.Droid
{
    public class GetVersionHelper : IVersionGet
    {
       
        public string GetVersion()
        {
            return Forms.Context.ApplicationContext.PackageManager.GetPackageInfo(Forms.Context.ApplicationContext.PackageName, 0).VersionName;
        }
    }
}
