using System;
using System.Net;
using System.Threading.Tasks;

namespace ibanking.Services
{
    public static class CheckConnection
    {
        public static async Task<bool> IsOnline(){
            string checkUrl = "http://google.com";

            try{
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(checkUrl);

                using(var response = await iNetRequest.GetResponseAsync()){
                    return true;
                }
               

            }
            catch{
                return false;
            }
        }
    }
}
