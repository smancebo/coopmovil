using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace ibanking.Resumen
{
    public static class ResumenService
    {
        public static async Task<Models.Resumen> 
                            cuentasPorClientes(int idinst, string idcliente){
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst",idinst);
            webMethodParams.Add("idcliente", idcliente);

            var jToken = await Services.APICaller.Call("CuentasPorCliente", webMethodParams);

            return Models.Resumen.FromJsonToken(jToken);
        } 
    }
}
