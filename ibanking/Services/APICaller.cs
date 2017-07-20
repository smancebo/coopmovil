using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace ibanking.Services
{
    public static class APICaller
    {
        public static async Task<JContainer> Call(string webMethod, ApiParams p){

            return await SoapClient.Post(Config.ServiceUrl, webMethod, p.ToJson());
        }
    }
}
