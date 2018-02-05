using System;
namespace ibanking.Models
{
    public class Respuesta
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public Respuesta()
        {
            this.CODIGO = "";
            this.DESCRIPCION = "";
        }
    }
}
