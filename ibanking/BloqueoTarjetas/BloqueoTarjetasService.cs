using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ibanking.BloqueoTarjetas
{
    public static class BloqueoTarjetasService
    {
        public static async Task<Models.BloqueoTarjetaModel> BuscarClienteTdMovil(int idinst, string docIdentificacion)
        {
            var apiParams = new Services.ApiParams();
            apiParams.Add("idinst", idinst);
            apiParams.Add("docIdentificacion", docIdentificacion);

            var result = (JArray)await Services.APICaller.Call("BuscarClienteTdMovil", apiParams);

            return Models.BloqueoTarjetaModel.FromJsonArray(result);
        }

        public static async Task<Models.TransferenciaMsj> BloquearTdMovil(string numeroTarjeta, string idTipoBloqueo, string comentario)
        {
            var apiParams = new Services.ApiParams();
            apiParams.Add("numeroTarjeta", numeroTarjeta);
            apiParams.Add("idTipo", idTipoBloqueo);
            apiParams.Add("comentario", comentario);

            var result = await Services.APICaller.Call("BloquearTdMovil", apiParams);

            return result.ElementAt(0).ToObject<Models.TransferenciaMsj>();
        }
    }
}
