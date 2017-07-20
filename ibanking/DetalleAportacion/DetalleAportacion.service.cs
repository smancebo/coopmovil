using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ibanking.DetalleAportacion
{
    public static class DetalleAportacionService
    {
        public static async Task<Models.DetalleAportacion> BuscarAccionesMovil(int idinst, string idaportacion){
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idaportacion", idaportacion);

			var Aportacion = ((JArray)(await Services.APICaller.Call("BuscarAccionesMovil", webMethodParams))).Children<JArray>();

			var detalleAportacion = Aportacion.ElementAt(0).FirstOrDefault();
			var movimientos = Aportacion.ElementAt(1);

            return Models.DetalleAportacion.FromJsonToken(detalleAportacion, movimientos);

		}
    }
}
