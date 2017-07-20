using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Movimiento
    {
        public int SECUENCIA { get; set; }
        public string DOCUMENTO { get; set; }
        public DateTime FECHA { get; set; }
        public string IDCUENTA { get; set; }
        public decimal MONTO { get; set; }
        public string FLAG_DEBITO_O_CREDITO { get; set; }
        public string CONCEPTO { get; set; }
        public string TRANSACCION { get; set; }
        public string SUCURSAL { get; set; }

        public Movimiento()
        {
            this.SECUENCIA = 0;
            this.DOCUMENTO = "";
            this.FECHA = DateTime.Now;
            this.IDCUENTA = "";
            this.MONTO = 0;
            this.FLAG_DEBITO_O_CREDITO = "";
            this.CONCEPTO = "";
            this.TRANSACCION = "";
            this.SUCURSAL = "";

        }

        public static Movimiento FromJsonToken(JToken token){
            try
            {
                return new Movimiento()
                {
                    SECUENCIA = token["SECUENCIA"].Value<int?>() ?? 0,
                    DOCUMENTO = token["DOCUMENTO"].Value<string>() ?? "",
                    FECHA = Convert.ToDateTime(token["FECHA"].Value<string>() ?? "1990/01/01"),
                    IDCUENTA = token["IDCUENTA"].Value<string>() ?? "",
                    MONTO = token["MONTO"].Value<decimal?>() ?? 0,
                    FLAG_DEBITO_O_CREDITO = token["FLAG_DEBITO_O_CREDITO"].Value<string>() ?? "",
                    CONCEPTO = token["CONCEPTO"].Value<string>() ?? "",
                    TRANSACCION = token["TRANSACCION"].Value<string>() ?? "",
                    SUCURSAL = token["SUCURSAL"].Value<string>() ?? ""

                };
            }
            catch
            {
                return null;
            }
        }

        public static List<Movimiento> FromJsonArray(JArray movimientos){
            var lstMovimientos = new List<Movimiento>();

            foreach(var movimiento in movimientos){
                var mov = FromJsonToken(movimiento);
                if(mov != null)
                    lstMovimientos.Add(mov);
            }

            return lstMovimientos;
        }
    }
}
