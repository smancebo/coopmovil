using System;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using ModernHttpClient;

namespace ibanking.Services
{
    public static class SoapClient
    {
        public static async Task<JContainer> Post(Uri url, string webMethod, string parameters){

            var soapString = MakeSoapRequest(webMethod, parameters);
            try{

                //var httpClientHandler = new HttpClientHandler
                //{
                //    Proxy = new WebProxy("10.172.0.7:8082", false),
                //    UseProxy = true
                //};
				using (var client = new HttpClient(new NativeMessageHandler()))
				{
					var content = new StringContent(soapString, Encoding.UTF8, "application/soap+xml");

                    var response = await client.PostAsync(url, content);
					var soapResponse = await response.Content.ReadAsStringAsync();
                    return ParseSoapResponse(soapResponse, webMethod);
				}
            }
            catch(Exception ex){
                var obj = new { error = ex };
                return JObject.Parse(JsonConvert.SerializeObject(obj));
            }
           
        }

        static string MakeSoapRequest(string webMethod, string  parameters){

            var soap = new StringBuilder();
            soap.Append(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            soap.Append(@"<soap12:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap12=""http://www.w3.org/2003/05/soap-envelope"">");
            soap.Append("<soap12:Body>");
            soap.Append(@"<executeWebMethod xmlns=""http://ibankingmobile.org/"">");
            soap.Append("<methodName>{0}</methodName>");
            soap.Append("<p>{1}</p>");
            soap.Append("</executeWebMethod>");
            soap.Append("</soap12:Body>");
            soap.Append("</soap12:Envelope>");

            return String.Format(soap.ToString(), webMethod, parameters);
        }

        static JContainer ParseSoapResponse(string response, string webMethod){
            var xdocument = XDocument.Parse(response);


           var result = JObject.Parse(xdocument.Root.Value)["result"] ?? JObject.Parse(xdocument.Root.Value);

            try
            {
                return JArray.Parse(result.Value<string>());
            }
            catch
            {
                if(result.Type == JTokenType.Object){
                    return (JObject)result;
                }
                return JObject.Parse(result.Value<string>());
            }

        }
    }
}



