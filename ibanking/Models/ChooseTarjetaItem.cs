using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class ChooseTarjetaItem
    {
        public string idCliente { get; set; }
        public string idDocumento { get; set; }
        public string tarjeta { get; set; }
        public string tarjetaEncriptada { get; set; }
        public bool activa { get; set; }
        public bool vigente { get; set; }
        public string cuentaDeAhorros { get; set; }
        public DateTime fechaVencimeinto { get; set; }
        public string T_Tarjeta_Nombre_Titular { get; set; }

        public ChooseTarjetaItem()
        {
            this.idCliente = "";
            this.idDocumento = "";
            this.tarjeta = "";
            this.tarjetaEncriptada = "";
            this.activa = false;
            this.vigente = false;
            this.cuentaDeAhorros = "";
            this.fechaVencimeinto = DateTime.Now;
            this.T_Tarjeta_Nombre_Titular = "";
        }

        public static List<ChooseTarjetaItem> FromJsonArray(JArray array)
        {
            try
            {
                return array.ToObject<List<ChooseTarjetaItem>>();
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
