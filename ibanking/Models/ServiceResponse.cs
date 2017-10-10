using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class ServiceResponse
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }

        public ServiceResponse()
        {
            this.CODIGO = "";
            this.DESCRIPCION = "";
        }

        public static ServiceResponse fromJsonToken(JToken token) {
            try {
                return token.ToObject<ServiceResponse>();
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}
