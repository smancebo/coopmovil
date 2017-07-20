using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class DetallePrestamo
    {
        public string IDPRESTAMO { get; set; }
        public string IDCLIENTE { get; set; }
        public string DESCRIPCION {get; set; }
        public decimal MONTO_PRESTAMO { get; set; }
        public decimal BALANCE_PRESTAMO { get; set; }
        public decimal TASA_INTERES { get; set; }
        public decimal TASA_MORA { get; set; }
        public DateTime FECHA_PRESTAMO { get; set; }
        public DateTime FECHA_DESEMBOLSO { get; set; }
        public int PLAZO { get; set; }
        public string EXPRESION_PLAZO { get; set; }
        public string TIPO_CUOTA { get; set; }
        public DateTime FECHA_VENCIMIENTO { get; set; }
        public int PERIODICIDAD_PAGO_CAPITAL { get; set; }
        public int PERIODICIDAD_PAGO_INTERES { get; set; }
        public DateTime FECHA_PROXIMO_CAPITAL { get; set; }
        public decimal VALOR_CUOTA { get; set; }
        public string NOMBRE_PUBLICO {get; set; }
        public decimal INTERESES_VIGENTES { get; set; }
        public string SUCURSAL { get; set; }
        public decimal MONTO_PAGO_ANTICIPADO { get; set; }
        public decimal BALANCE_CARGO { get; set; }
        public decimal CAPITAL_VENCIDO { get; set; }
        public decimal INTERES_VENCIDO { get; set; }
        public decimal MORA { get; set; }
        public decimal SEGURO { get; set; }
        public decimal TOTAL_VENCIDO { get; set; }
        public bool LEGAL { get; set; }
        public decimal DISPONIBLE_LINEA { get; set; }
        public decimal TOTAL_DEUDA { get; set; }
        public List<Models.Movimiento> MOVIMIENTOS { get; set; }

        public DetallePrestamo()
        {
            this.IDPRESTAMO = "";
            this.IDCLIENTE = "";
            this.DESCRIPCION = "";
            this.MONTO_PRESTAMO = 0;
            this.BALANCE_PRESTAMO = 0;
            this.TASA_INTERES = 0;
            this.TASA_MORA = 0;
            this.FECHA_PRESTAMO = DateTime.Now;
            this.FECHA_DESEMBOLSO = DateTime.Now;
            this.PLAZO = 0;
            this.EXPRESION_PLAZO = "";
            this.TIPO_CUOTA = "";
            this.FECHA_VENCIMIENTO = DateTime.Now;
            this.PERIODICIDAD_PAGO_CAPITAL = 0;
            this.PERIODICIDAD_PAGO_INTERES = 0;
            this.FECHA_PROXIMO_CAPITAL = DateTime.Now;
            this.VALOR_CUOTA = 0;
            this.NOMBRE_PUBLICO = "";
            this.INTERESES_VIGENTES = 0;
            this.SUCURSAL = "";
            this.MONTO_PAGO_ANTICIPADO = 0;
            this.BALANCE_CARGO = 0;
            this.CAPITAL_VENCIDO = 0;
            this.INTERES_VENCIDO = 0;
            this.MORA = 0;
            this.SEGURO = 0;
            this.TOTAL_VENCIDO = 0;
            this.LEGAL = false;
            this.DISPONIBLE_LINEA = 0;
            this.TOTAL_DEUDA = 0;
        }

        public static DetallePrestamo FromJsonToken(JToken token, JArray movimientos){
            try
            {
                var detalle = new DetallePrestamo()
                {
                    IDPRESTAMO = token["IDPRESTAMO"].Value<string>() ?? "",
                    IDCLIENTE = token["IDCLIENTE"].Value<string>() ?? "",
                    DESCRIPCION = token["DESCRIPCION"].Value<string>() ?? "",
                    MONTO_PRESTAMO = token["MONTO_PRESTAMO"].Value<decimal?>() ?? 0,
                    BALANCE_PRESTAMO = token["BALANCE_PRESTAMO"].Value<decimal?>() ?? 0,
                    TASA_INTERES = token["TASA_INTERES"].Value<decimal?>() ?? 0,
                    TASA_MORA = token["TASA_MORA"].Value<decimal?>() ?? 0,
                    FECHA_PRESTAMO = Convert.ToDateTime(token["FECHA_PRESTAMO"].Value<string>() ?? "1990/01/01"),
                    FECHA_DESEMBOLSO = Convert.ToDateTime(token["FECHA_DESEMBOLSO"].Value<string>() ?? "1990/01/01"),
                    PLAZO = token["PLAZO"].Value<int?>() ?? 0,
                    EXPRESION_PLAZO = token["EXPRESION_PLAZO"].Value<string>() ?? "",
                    TIPO_CUOTA = token["TIPO_CUOTA"].Value<string>() ?? "",
                    FECHA_VENCIMIENTO = Convert.ToDateTime(token["FECHA_VENCIMIENTO"].Value<string>() ?? "1990/01/01"),
                    PERIODICIDAD_PAGO_CAPITAL = token["PERIODICIDAD_PAGO_CAPITAL"].Value<int?>() ?? 0,
                    PERIODICIDAD_PAGO_INTERES = token["PERIODICIDAD_PAGO_INTERES"].Value<int?>() ?? 0,
                    FECHA_PROXIMO_CAPITAL = Convert.ToDateTime(token["FECHA_PROXIMO_CAPITAL"].Value<string>() ?? "1990/01/01"),
                    VALOR_CUOTA = token["VALOR_CUOTA"].Value<decimal?>() ?? 0,
                    NOMBRE_PUBLICO = token["NOMBRE_PUBLICO"].Value<string>() ?? "",
                    INTERESES_VIGENTES = token["INTERESES_VIGENTES"].Value<decimal?>() ?? 0,
                    SUCURSAL = token["SUCURSAL"].Value<string>() ?? "",
                    MONTO_PAGO_ANTICIPADO = token["MONTO_PAGO_ANTICIPADO"].Value<decimal?>() ?? 0,
                    BALANCE_CARGO = token["BALANCE_CARGO"].Value<decimal?>() ?? 0,
                    CAPITAL_VENCIDO = token["CAPITAL_VENCIDO"].Value<decimal?>() ?? 0,
                    INTERES_VENCIDO = token["INTERES_VENCIDO"].Value<decimal?>() ?? 0,
                    MORA = token["MORA"].Value<decimal?>() ?? 0,
                    SEGURO = token["SEGURO"].Value<decimal?>() ?? 0,
                    TOTAL_VENCIDO = token["TOTAL_VENCIDO"].Value<decimal?>() ?? 0,
                    LEGAL = token["LEGAL"].Value<bool?>() ?? false,
                    DISPONIBLE_LINEA = token["DISPONIBLE_LINEA"].Value<decimal?>() ?? 0,
                    MOVIMIENTOS = Movimiento.FromJsonArray(movimientos)
                                                            
                };

                detalle.TOTAL_DEUDA = detalle.BALANCE_PRESTAMO +
					                  detalle.INTERESES_VIGENTES +
					                  detalle.INTERES_VENCIDO +
					                  detalle.SEGURO +
					                  detalle.MORA +
					                  detalle.BALANCE_CARGO;
					                
                return detalle;


            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
