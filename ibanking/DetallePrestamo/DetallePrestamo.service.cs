using System;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ibanking.DetallePrestamo
{
    public static class DetallePrestamoService
    {
        public static async Task<Models.DetallePrestamo> BuscarPrestamoMovil(
            int idinst, 
            string idprestamo){

            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idprestamo", idprestamo);

            var Prestamo = ((JArray) (await Services.APICaller.Call("BuscarPrestamosMovil", webMethodParams))).Children<JArray>();
            var detallePrestamo = Prestamo.ElementAt(0).FirstOrDefault();
            var movimientos = Prestamo.ElementAt(1);

            return Models.DetallePrestamo.FromJsonToken(detallePrestamo, movimientos);

        }
    }
}
