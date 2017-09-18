using System;
namespace ibanking.Registro
{
    public class RegistroVm
    {
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Respuesta { get; set; }

        public RegistroVm()
        {
            this.Documento = "";
            this.Telefono = "";
            this.UserName = "";
            this.Respuesta = "";
            
        }
    }
}
