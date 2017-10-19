using System;
namespace ibanking.Models
{
    public class DatosRecuperarClave
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }
        public string PREGUNTA { get; set; }
        public string RESPUESTA { get; set; }
        public string EMAIL { get; set; }

        public DatosRecuperarClave()
        {
            this.CODIGO = "";
            this.DESCRIPCION = "";
            this.PREGUNTA = "";
            this.RESPUESTA = "";
            this.EMAIL = "";
        }
    }
}
