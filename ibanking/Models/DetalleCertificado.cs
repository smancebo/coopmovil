using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class DetalleCertificado
    {
        public string IDCERTIFICADO { get; set; }
        public string NOMBRE { get; set; }
        public string IDCLIENTE { get; set; }
        public string SUCURSAL { get; set; }
        public decimal MONTO_EMISION { get; set; }
        public DateTime FECHA_EMISION { get; set; }
        public string TIPO_CERTIFICADO { get; set; }
        public decimal TASA { get; set; }
        public DateTime FECHA_VENCIMIENTO { get; set; }
        public decimal BALANCE { get; set; }
        public string FORMA_PAGO_INTERES { get; set; }
        public int DURACION_MESES { get; set; }
        public string NO_TALONARIO { get; set; }
        public decimal TASA_ORIGINAL { get; set; }
        public decimal INTERESES_GANADOS { get; set; }
        public string NOMBRE_PUBLICO { get; set; }
        public List<Movimiento> MOVIMIENTOS { get; set; }


        public DetalleCertificado()
        {
            this.IDCERTIFICADO = "";
            this.NOMBRE = "";
            this.IDCLIENTE = "";
            this.SUCURSAL = "";
            this.MONTO_EMISION = 0;
            this.FECHA_EMISION = DateTime.Now;
            this.TIPO_CERTIFICADO = "";
            this.TASA = 0;
            this.FECHA_VENCIMIENTO = DateTime.Now;
            this.BALANCE = 0;
            this.FORMA_PAGO_INTERES = "";
            this.DURACION_MESES = 0;
            this.NO_TALONARIO = "";
            this.TASA_ORIGINAL = 0;
            this.INTERESES_GANADOS = 0;
            this.NOMBRE_PUBLICO = "";
        }

        public static DetalleCertificado FromJsonToken(JToken token, JArray movimiento){
            try{
                var detalleCertificado = token.ToObject<DetalleCertificado>();
                detalleCertificado.MOVIMIENTOS = Movimiento.FromJsonArray(movimiento);
                return detalleCertificado;
            }
            catch
            {
                return null;
            }
        }
    }
}
