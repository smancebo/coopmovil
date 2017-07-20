using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Prestamo
    {
        public string IDPrestamo { get; set; }
        public string IDCliente { get; set; }
        public decimal Monto_Prestamo { get; set; }
        public decimal Balance_Prestamo { get; set; }
        public decimal Balance_Cargo { get; set; }
        public DateTime Fecha_Prestamo { get; set; }
        public decimal Valor_Cuota { get; set; }
        public string IDTipo_Prestamo { get; set; }
        public string Nombre_Publico { get; set; }
        public string Descripcion_Tipo { get; set; }
        public decimal Capital { get; set; }
        public decimal Intereses { get; set; }
        public decimal Mora { get; set; }
        public decimal Seguro { get; set; }
        public decimal Intereses_Dia { get; set; }
        public int Cant_Cuotas { get; set; }
        public decimal Total_Adeudado { get; set; }
        public decimal Total_Vencido { get; set; }
        public decimal Saldo_Proyectado { get; set; }
        public string Cuotas_Generadas_Pagadas { get; set; }



        public Prestamo()
        {
            this.IDPrestamo = "";
            this.IDCliente = "";
            this.Monto_Prestamo = 0;
            this.Balance_Prestamo = 0;
            this.Balance_Cargo = 0;
            this.Fecha_Prestamo = new DateTime();
            this.Valor_Cuota = 0;
            this.IDTipo_Prestamo = "";
            this.Nombre_Publico = "";
            this.Descripcion_Tipo = "";
            this.Capital = 0;
            this.Intereses = 0;
            this.Mora = 0;
            this.Seguro = 0;
            this.Intereses_Dia = 0;
            this.Cant_Cuotas = 0;
            this.Total_Adeudado = 0;
            this.Total_Vencido = 0;
            this.Saldo_Proyectado = 0;
            this.Cuotas_Generadas_Pagadas = "";
        }


        public static Prestamo FromJsonToken(JToken token){
            try{
                return new Prestamo()
                {
                    IDPrestamo = token["idprestamo"].Value<string>(),
                    IDCliente = token["idcliente"].Value<string>(),
                    Monto_Prestamo = Convert.ToDecimal(token["monto_prestamo"].Value<string>()),
                    Balance_Cargo = Convert.ToDecimal(token["balance_cargo"].Value<string>() ),
                    Balance_Prestamo = Convert.ToDecimal(token["balance_prestamo"].Value<string>()),
                    Fecha_Prestamo = Convert.ToDateTime(token["fecha_prestamo"].Value<string>() ),
                    Valor_Cuota = Convert.ToDecimal(token["valor_cuota"].Value<string>() ),
                    IDTipo_Prestamo = token["idtipo_prestamo"].Value<string>(),
                    Nombre_Publico = token["nombre_publico"].Value<string>(),
                    Descripcion_Tipo = token["descripciontipo"].Value<string>(),
                    Capital = Convert.ToDecimal(token["capital"].Value<string>()),
                    Intereses =  Convert.ToDecimal(token["intereses"].Value<string>()),
                    Mora = Convert.ToDecimal(token["mora"].Value<string>()),
                    Seguro = Convert.ToDecimal(token["seguro"].Value<string>()),
                    Intereses_Dia = Convert.ToDecimal(token["interes_dia"].Value<string>()),
                    Cant_Cuotas = Convert.ToInt32(token["cant_cuotas"].Value<string>() ),
                    Total_Adeudado = Convert.ToDecimal(token["totaladeudado"].Value<string>()),
                    Total_Vencido = Convert.ToDecimal(token["totalvencido"].Value<string>()),
                    Saldo_Proyectado = Convert.ToDecimal(token["saldo_proyectado"].Value<string>()),
                    Cuotas_Generadas_Pagadas = token["cuotas_generadas_pagadas"].Value<string>()

                };
            }
            catch (Exception ex){
                return null;
            }
        }
    }
}

