using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Aportacion
    {
        public string IDAportacion { get; set; }
        public string IDCliente { get; set; }
        public DateTime Fecha_Ingreso { get; set; }
        public decimal Monto_Inicial_Aportacion { get; set; }
        public decimal Monto_Actual_Aportacion { get; set; }
        public string Nombre_Publico { get; set; }

        public Aportacion()
        {
            this.IDAportacion = "";
            this.IDCliente = "";
            this.Fecha_Ingreso = new DateTime();
            this.Monto_Actual_Aportacion = 0;
            this.Monto_Actual_Aportacion = 0;
            this.Nombre_Publico = "";

           
        }

        public static Aportacion FromJsonToken(JToken token){
            try
            {
                return new Aportacion()
                {
                    IDAportacion = token["idaportacion"].Value<string>() ?? "",
                    IDCliente = token["idcliente"].Value<string>() ?? "",
                    Fecha_Ingreso = Convert.ToDateTime(token["fecha_ingreso"].Value<string>() ?? "1990/01/01"),
                    Monto_Inicial_Aportacion = Convert.ToDecimal(token["monto_inicial_aportacion"].Value<string>() ?? "0"),
                    Monto_Actual_Aportacion = Convert.ToDecimal(token["monto_actual_aportacion"].Value<string>() ?? "0"),
                    Nombre_Publico = token["nombre_publico"].Value<string>() ?? ""

                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
