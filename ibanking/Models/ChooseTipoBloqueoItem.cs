using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class ChooseTipoBloqueoItem
    {
        public string T_TiposDeBloqueo_Codigo { get; set; }
        public string T_TiposDeBloqueo_Descripcion { get; set; }

        public ChooseTipoBloqueoItem()
        {
            this.T_TiposDeBloqueo_Codigo = "";
            this.T_TiposDeBloqueo_Descripcion = "";
        }

        public static List<ChooseTipoBloqueoItem> FromJsonArray(JArray array)
        {
            try
            {
                return array.ToObject<List<ChooseTipoBloqueoItem>>();
            }
            catch
            {
                return null;
            }

        }

    }
}
