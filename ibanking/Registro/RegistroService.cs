using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ibanking.Registro
{
    public static class RegistroService
    {
        public static async Task<List<Models.Documento>> GetDocumentos()
        {
            return await Task.Run(() => new List<Models.Documento>()
            {
                new Models.Documento(){ ID ="CED", Descripcion="Cédula"},
                new Models.Documento(){ ID ="RNC", Descripcion="Registro Nacional Contribuyente"},
                new Models.Documento(){ ID ="PAS", Descripcion="Pasaporte"},
                new Models.Documento(){ ID ="LIC", Descripcion="Licencia"}
            });
        }


    }
}
