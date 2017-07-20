using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Resumen
    {
        public DateTime FechaProceso { get; set; }
        public List<CuentaAhorro> CuentasdeAhorro { get; set; }
        public List<Prestamo> Prestamos { get; set; }
        public List<Certificado> Certificados { get; set; }
        public List<Aportacion> Aportaciones { get; set; }

        public Resumen()
        {
            this.CuentasdeAhorro = new List<CuentaAhorro>();
            this.Prestamos = new List<Prestamo>();
            this.Certificados = new List<Certificado>();
            this.Aportaciones = new List<Aportacion>();
        }

        public static Resumen FromJsonToken(JToken token){
            try
            {
                var resumen = new Resumen();

                //Parse account from JToken provided by service
                resumen.FechaProceso = Convert.ToDateTime(token["cuentas"].Value<JArray>().First["fecha_proceso"].Value<string>());
                var CuentasAhorro = token["cuentas2"].Value<JArray>();
                var Prestamos = token["cuentas3"].Value<JArray>();
                var Certificados = token["cuentas4"].Value<JArray>();
                var Aportaciones = token["cuentas5"].Value<JArray>();

                foreach (var cuenta in CuentasAhorro)
                {
                    resumen.CuentasdeAhorro.Add(CuentaAhorro.FromJsonToken(cuenta));
                }

                //Prestamos

                foreach (var prestamo in Prestamos)
                {
                    resumen.Prestamos.Add(Prestamo.FromJsonToken(prestamo));
                }

                //Certificados
                foreach (var certificado in Certificados)
                {
                    resumen.Certificados.Add(Certificado.FromJsonToken(certificado));
                }

                //Aportaciones 

                foreach (var aportacion in Aportaciones)
                {
                    resumen.Aportaciones.Add(Aportacion.FromJsonToken(aportacion));
                }


                return resumen;


                //Todo Parse Aportaciones

            }
            catch 
            {
                return null;
            }
        }
    }
}
