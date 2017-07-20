using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class DetalleAportacion
    {
        public string IDAPORTACION { get; set; }
        public string NOMBRE { get; set; }
        public string IDCLIENTE { get; set; }
        public string SUCURSAL { get; set; }
        public DateTime FECHA_INGRESO { get; set; }
        public decimal MONTO_INICIAL_APORTACION { set; get; }
        public decimal MONTO_ACTUAL_APORTACION { get; set; }
        public decimal BALANCE_CORTE { get; set; }
        public DateTime FECHA_CORTE { get; set; }
        public string NOMBRE_PUBLICO { get; set; }
        public List<Movimiento> MOVIMIENTOS {get;set;}

        public DetalleAportacion()
        {
            this.IDAPORTACION = "";
            this.NOMBRE = "";
            this.IDCLIENTE = "";
            this.SUCURSAL = "";
            this.FECHA_INGRESO = DateTime.Now;
            this.MONTO_INICIAL_APORTACION = 0;
            this.MONTO_ACTUAL_APORTACION = 0;
            this.BALANCE_CORTE = 0;
            this.FECHA_CORTE = DateTime.Now;
            this.NOMBRE_PUBLICO = "";
            this.MOVIMIENTOS = new List<Movimiento>();
        }


        public static DetalleAportacion FromJsonToken(JToken token, JArray movimientos)
        {
            try
            {
                var detalle = token.ToObject<DetalleAportacion>();
                detalle.MOVIMIENTOS = Movimiento.FromJsonArray(movimientos);
                return detalle;
            }
            catch
            {
                return null;
            }
        }
    }
}
