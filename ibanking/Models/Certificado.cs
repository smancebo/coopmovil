using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Certificado
    {

        public string IDCertificado { get; set; }
        public string IDCliente { get; set; }
        public decimal Monto_Emision { get; set; }
        public DateTime Fecha_Emision { get; set; }
        public decimal Balance { get; set; }
        public string Nombre_Publico { get; set; }

        public Certificado()
        {
            this.IDCertificado = "";
            this.IDCliente = "";
            this.Monto_Emision = 0;
            this.Fecha_Emision = new DateTime();
            this.Balance = 0;
            this.Nombre_Publico = "";
        }

        public static Certificado FromJsonToken(JToken token){
            try
            {
                return new Certificado()
                {
                    IDCertificado = token["idcertificado"].Value<string>() ?? "",
                    IDCliente = token["idcliente"].Value<string>() ?? "",
                    Monto_Emision = Convert.ToDecimal(token["monto_emision"].Value<string>() ?? "0"),
                    Fecha_Emision = Convert.ToDateTime(token["fecha_emision"].Value<string>() ?? "1990/01/01"),
                    Balance = Convert.ToDecimal(token["balance"].Value<string>() ?? "0"),
                    Nombre_Publico = token["nombre_publico"].Value<string>() ?? ""
                };
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
