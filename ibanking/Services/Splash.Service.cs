using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;
using ibanking.Models;

namespace ibanking.Services
{
    public static class Splash
    {
        public static async Task<Institucion> GetDatosInstitucion()
        {
            try
            {
                var p = new ApiParams();
                p.Add("version", Config.Version.Replace("v", ""));

                var datosInst = await APICaller.Call("DatosInstitucionMovil", p);

                return Institucion.FromJToken(datosInst.Children().FirstOrDefault());
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
