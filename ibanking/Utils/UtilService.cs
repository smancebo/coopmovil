using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ibanking.Utils
{
    public static class UtilService
    {
       public static async Task<List<Models.ChooseCuentaItem>> ListaDeCuentasMovil(int idinst, string idcliente)
        {
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idcliente", idcliente);

            var cuentas = await Services.APICaller.Call("ListaDeCuentasMovil", webMethodParams);

            return Models.ChooseCuentaItem.FromJsonArray((JArray)cuentas);
        }
    }
}
