using System;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ibanking.DetalleAhorro
{
    public static class DetalleAhorroService
    {
        public static async Task<Models.DetalleAhorro> BuscarAhorrosMovil(int idisnt, string idcuenta){
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idisnt);
            webMethodParams.Add("idcuenta", idcuenta);

            var Ahorros = ((JArray)(await Services.APICaller.Call("BuscarAhorrosMovil", webMethodParams))).Children<JArray>();

            var detalleAhorro = Ahorros.ElementAt(0).FirstOrDefault();
            var movimientos = Ahorros.ElementAt(1);

            return Models.DetalleAhorro.FromJsonToken(detalleAhorro, movimientos);

        }
    }
}
