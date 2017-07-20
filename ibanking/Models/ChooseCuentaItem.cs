using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class ChooseCuentaItem
    {
        public string IDCUENTA { get; set; }
        public string NOMBRE_PUBLICO { get; set; }
        public string TITULAR { get; set; }
        public string DESCRIPCION { get; set; }
        public string TIPO { get; set; }
        public decimal BALANCE { get; set; }
        public DateTime FECHA_APERTURA { get; set; }
        public string POSITION { get; set; }

        public ChooseCuentaItem()
        {
            this.IDCUENTA = "";
            this.NOMBRE_PUBLICO = "";
            this.TITULAR = "";
            this.DESCRIPCION = "";
            this.TIPO = "";
            this.BALANCE = 0;
            this.FECHA_APERTURA = DateTime.Now;
            this.POSITION = "";
        }

        public static ChooseCuentaItem FromJsonToken(JToken token){
            try
            {
                return token.ToObject<ChooseCuentaItem>();
            }
            catch
            {
                return null;
            }
        }

        public static List<ChooseCuentaItem> FromJsonArray(JArray array)
        {
            return array.ToObject<List<ChooseCuentaItem>>();
        }
    }
}
