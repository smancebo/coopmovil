using System;
using Xamarin.Forms;
namespace ibanking.Services
{
    public static class Config
    {
        //public static Uri ServiceUrl = new Uri("https://www.cosefi.com/CoopBueno/coopmovil/a_ibanking.asmx");
        public static Uri OtherInfo = new Uri("https://www.cosefi.com/CoopBueno/coopmovil/info.html");
        public static Uri ServiceUrl = new Uri("http://10.172.0.170/ibankingparser/a_ibanking.asmx");
        public static string Version = $"v{DependencyService.Get<IVersionGet>().GetVersion()}";
        public static string DBName = "cosefi.coopmovil.new.db3";
        public static int GetCurrentAppVersion()
        {
            return Convert.ToInt32(Version.Replace(".", "").Replace("v", ""));
        }

    }
}
