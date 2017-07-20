using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ibanking.DetalleCertificado
{
    public static class DetalleCertificadoService
    {
        public async static Task<Models.DetalleCertificado> BuscarCertificadosMovil(int idinst, string idCertificado){
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idcertificado", idCertificado);


			var Certificado = ((JArray)(await Services.APICaller.Call("BuscarCertificadosMovil", webMethodParams))).Children<JArray>();

			var detalleCertificado = Certificado.ElementAt(0).FirstOrDefault();
			var movimientos = Certificado.ElementAt(1);

            return Models.DetalleCertificado.FromJsonToken(detalleCertificado, movimientos);
        }
    }
}
