using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ibanking.Transferencias
{
    public static class TransferenciasService
    {
        public static async Task<List<Models.ChooseCuentaItem>> ListaDeCuentasTxMovil(int idinst, string idcliente)
        {
            var webMethodParams = new Services.ApiParams();

            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idcliente", idcliente);

			var cuentas = await Services.APICaller.Call("ListaDeCuentasTxMovil", webMethodParams);

			return Models.ChooseCuentaItem.FromJsonArray((JArray)cuentas);
        }

        public static async Task<Models.TransferenciaMsj> TransferenciaAhorrosMovil(int idinst, 
                                                                       string idcliente, 
                                                                       string cuenta_origen, 
                                                                       decimal monto, 
                                                                       string cuenta_destino, 
                                                                       string concepto, 
                                                                       string tipo)
        {
            var apiParams = new Services.ApiParams();
            apiParams.Add("idInst", idinst);
            apiParams.Add("idClienteOrigen", idcliente);
            apiParams.Add("idCuentaOrigen", cuenta_origen);
            apiParams.Add("dblMonto", monto);
            apiParams.Add("idCuentaDestino", cuenta_destino);
            apiParams.Add("Concepto", concepto);
            apiParams.Add("idTipoProductoDestino", tipo);

            var result = (await Services.APICaller.Call("TransferenciaAhorrosMovil", apiParams)).ElementAt(0).ToObject<Models.TransferenciaMsj>();

            return result;
        }

		public static async Task<Models.TransferenciaMsj> DesembolsoLineaMovil(int idinst,
																	   string idprestamo,
																	   decimal monto,
																	   string idcuenta)
		{
			var apiParams = new Services.ApiParams();
			apiParams.Add("idInst", idinst);
			apiParams.Add("idPrestamo", idprestamo);
			apiParams.Add("Monto", monto);
			apiParams.Add("idCuenta", idcuenta);
			

			var result = (await Services.APICaller.Call("DesembolsoLineaMovil", apiParams)).ElementAt(0).ToObject<Models.TransferenciaMsj>();

			return result;
		}

		public static async Task<Models.TransferenciaMsj> TransferenciaPrestamosMovil(int idinst,
																	   string idcuenta,
																	   decimal monto,
																	   string idprestamo)
		{
			var apiParams = new Services.ApiParams();
			apiParams.Add("idInst", idinst);
			apiParams.Add("idCuenta", idcuenta);
			apiParams.Add("Monto", monto);
			apiParams.Add("idPrestamo", idprestamo);
			

			var result = (await Services.APICaller.Call("TransferenciaPrestamosMovil", apiParams)).ElementAt(0).ToObject<Models.TransferenciaMsj>();

			return result;
		}
    }
}
