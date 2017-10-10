using System;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class Documento
    {
        public string ID { get; set; }
        public string DESCRIPCION { get; set; }

        public Documento()
        {
            this.ID = "";
            this.DESCRIPCION = "";
        }

        public override string ToString()
        {
            return this.DESCRIPCION;
        }

    }
}
