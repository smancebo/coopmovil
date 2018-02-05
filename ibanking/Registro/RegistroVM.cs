using System;
namespace ibanking.Registro
{
    public class RegistroVm
    {
        public string Documento { get; set; }
        public Models.Documento TipoDocumento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public Models.Documento Pregunta { get; set; }
        public string Respuesta { get; set; }
        public Models.Documento ComoSeEntero { get; set; }
        public string ComoSeEnteroOtro { get; set; }

        public RegistroVm()
        {
            this.Documento = "";
            this.Telefono = "";
            this.UserName = "";
            this.Respuesta = "";
            this.Email = "";
            this.ComoSeEntero = new Models.Documento();
            this.TipoDocumento = new Models.Documento();
            this.Pregunta = new Models.Documento();
            
        }
    }
}
