using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class CuentaAhorro
    {
        public string IDCuenta { get; set; }
        public string IDCuenta_Estandar { get; set; }
        public string Nombre_Corto { get; set; }
        public string IDCliente { get; set; }
        public decimal Balance_Actual { get; set; }
        public decimal Balance_Disponible { get; set; }
        public string Nombre_Publico { get; set; }
        public string Estatus { get; set; }

        public CuentaAhorro()
        {
            this.IDCuenta = "";
            this.IDCuenta_Estandar = "";
            this.Nombre_Corto = "";
            this.IDCliente = "";
            this.Balance_Actual = 0;
            this.Balance_Disponible = 0;
            this.Nombre_Publico = "";
            this.Estatus = "";
        }

        public static CuentaAhorro FromJsonToken(JToken token){
            try{
                return new CuentaAhorro()
                {
                    IDCuenta = token["idcuenta"].Value<string>(),
                    IDCuenta_Estandar = token["idcuenta_estandar"].Value<string>(),
                    Nombre_Corto = token["nombre_corto"].Value<string>(),
                    IDCliente = token["idcliente"].Value<string>(),
                    Balance_Actual = Convert.ToDecimal(token["balance_actual"].Value<string>()),
                    Balance_Disponible = Convert.ToDecimal(token["balance_disponible"].Value<string>()),
                    Estatus = token["estatus"].Value<string>()

                };
            }
            catch{
                return null;
            }
        }




		/*
        "idcuenta": "0030349830",
    "idcuenta_estandar": "",
    "nombre_corto": "SAMUEL JEAN CARLOS MANCEBO PAULA",
    "idcliente": "32786",
    "balance_actual": "9153.5700",
    "balance_disponible": "9053.5700",
    "nombre_publico": "Cuenta de Ahorro",
    "estatus": "ACTIVA"

        */
	}
}
