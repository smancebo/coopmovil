using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ibanking.Registro
{
    public static class RegistroService
    {
        public static async Task<Models.Registro> GetListaRegistroMovil()
        {
            var webMethodParams = new Services.ApiParams();
            //Verificar
            webMethodParams.Add("idinst", 1);

            var ListaRegistro = ((JArray)(await Services.APICaller.Call("ListaRegistroMovil", webMethodParams))).Children<JArray>();

            return new Models.Registro()
            {
                ListaTiposDocumento = ListaRegistro.ElementAt(0).ToObject<List<Models.Documento>>(),
                ListaPreguntasSecreta = ListaRegistro.ElementAt(1).ToObject<List<Models.Documento>>(),
                ListaComoSeEntero = ListaRegistro.ElementAt(2).ToObject<List<Models.Documento>>()
            };

        }

        public static async Task<Models.ServiceResponse> CrearAccesoMovil(int idinst,
                                                                          string idTipoDocumento,
                                                                          string idDocumento,
                                                                          string telCelular,
                                                                          string eMail,
                                                                          string idUsuario,
                                                                          string idPregunta,
                                                                          string respuesta,
                                                                          string idComoSeEntero,
                                                                          string comoSeEnteroOtro
                                                                         )
        {
            try
            {
                var webMethodParams = new Services.ApiParams();
                webMethodParams.Add("idInst", 1);
                webMethodParams.Add("idTipoDocumento", idTipoDocumento);
				webMethodParams.Add("idDocumento", idDocumento);
                webMethodParams.Add("telCelular", telCelular);
                webMethodParams.Add("eMail", eMail);
                webMethodParams.Add("idUsuario", idUsuario);
                webMethodParams.Add("idPregunta", Convert.ToInt32(idPregunta));
                webMethodParams.Add("respuesta", respuesta);
                webMethodParams.Add("idComoSeEntero", idComoSeEntero);
                webMethodParams.Add("comoSeEnteroOtro", comoSeEnteroOtro);

                var response = await Services.APICaller.Call("CrearAccesoMovil", webMethodParams);

                return response.ElementAt(0).ToObject<Models.ServiceResponse>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
