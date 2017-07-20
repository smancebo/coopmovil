using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class DetalleAhorro
    {
        public string IDCUENTA { get; set; }
        public string IDCUENTA_ESTANDAR { get; set; }
        public string TIPO_CUENTA { get; set; }
        public decimal TASA_INTERES { get; set; }
        public string SUCURSAL { get; set; }
        public string NOMBRE_CORTO { get; set; }
        public string IDCLIENTE { get; set; }
        public DateTime FECHA_APERTURA { get; set; }
        public decimal MONTO_INICIAL { get; set; }
        public decimal BALANCE_ACTUAL { get; set; }
        public decimal MONTO_EMBARGO_PIGNORACION { get; set; }
        public decimal BALANCE_EN_TRANSITO { get; set; }
        public decimal BALANCE_DISPONIBLE { get; set; }
        public DateTime FECHA_ULT_DEPOSITO { get; set; }
        public decimal MONTO_ULT_DEPOSITO { get; set; }
        public DateTime FECHA_ULT_RETIRO { get; set; }
        public decimal MONTO_ULT_RETIRO { get; set; }
        public string ESTATUS { get; set; }
        public string NOMBRE_PUBLICO { get; set; }
        public string E_MAIL { get; set; }
        public List<Movimiento> MOVIMIENTOS { get; set; }

        public DetalleAhorro()
        {
            this.IDCUENTA = "";
            this.IDCUENTA_ESTANDAR = "";
            this.TIPO_CUENTA = "";
            this.TASA_INTERES = 0;
            this.SUCURSAL = "";
            this.NOMBRE_CORTO = "";
            this.IDCLIENTE = "";
            this.FECHA_APERTURA = DateTime.Now;
            this.MONTO_INICIAL = 0;
            this.BALANCE_ACTUAL = 0;
            this.MONTO_EMBARGO_PIGNORACION = 0;
            this.BALANCE_EN_TRANSITO = 0;
            this.BALANCE_DISPONIBLE = 0;
            this.FECHA_ULT_DEPOSITO = DateTime.Now;
            this.MONTO_ULT_DEPOSITO = 0;
            this.FECHA_ULT_RETIRO = DateTime.Now;
            this.MONTO_ULT_RETIRO = 0;
            this.ESTATUS = "";
            this.NOMBRE_PUBLICO = "";
            this.E_MAIL = "";
            this.MOVIMIENTOS = new List<Movimiento>();
        }

        public static DetalleAhorro FromJsonToken(JToken token, JArray movimientos)
        {
            try
            {
                return new DetalleAhorro()
                {
                    IDCUENTA = token["IDCUENTA"].Value<string>() ?? "",
                    IDCUENTA_ESTANDAR = token["IDCUENTA_ESTANDAR"].Value<string>() ?? "",
                    TIPO_CUENTA = token["TIPO_CUENTA"].Value<string>() ?? "",
                    TASA_INTERES = token["TASA_INTERES"].Value<decimal?>() ?? 0,
                    SUCURSAL = token["SUCURSAL"].Value<string>() ?? "",
                    NOMBRE_CORTO = token["NOMBRE_CORTO"].Value<string>() ?? "",
                    IDCLIENTE = token["IDCLIENTE"].Value<string>() ?? "",
                    FECHA_APERTURA = Convert.ToDateTime(token["FECHA_APERTURA"].Value<string>() ?? "1990/01/01"),
                    MONTO_INICIAL = token["MONTO_INICIAL"].Value<decimal?>() ?? 0,
                    BALANCE_ACTUAL = token["BALANCE_ACTUAL"].Value<decimal?>() ?? 0,
                    MONTO_EMBARGO_PIGNORACION = token["MONTO_EMBARGO_PIGNORACION"].Value<decimal?>() ?? 0,
                    BALANCE_EN_TRANSITO = token["BALANCE_EN_TRANSITO"].Value<decimal?>() ?? 0,
                    BALANCE_DISPONIBLE = token["BALANCE_DISPONIBLE"].Value<decimal?>() ?? 0,
                    FECHA_ULT_DEPOSITO = Convert.ToDateTime(token["FECHA_ULT_DEPOSITO"].Value<string>() ?? "1990/01/01"),
                    MONTO_ULT_DEPOSITO = token["MONTO_ULT_DEPOSITO"].Value<decimal?>() ?? 0,
                    FECHA_ULT_RETIRO = Convert.ToDateTime(token["FECHA_ULT_RETIRO"].Value<string>() ?? "1990/01/01"),
                    MONTO_ULT_RETIRO = token["MONTO_ULT_RETIRO"].Value<decimal?>() ?? 0,
                    ESTATUS = token["ESTATUS"].Value<string>() ?? "",
                    NOMBRE_PUBLICO = token["NOMBRE_PUBLICO"].Value<string>() ?? "",
                    E_MAIL = token["E_MAIL"].Value<string>() ?? "",
                    MOVIMIENTOS = Movimiento.FromJsonArray(movimientos)
				};
            }
            catch
            {
                return null;
            }

        }
    }
}
