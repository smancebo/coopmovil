using System;
namespace ibanking.OlvidoClave
{
    public class OlvidoClaveVm
    {
        public string Usuario { get; set; }
        public string DocumentoIdentidad { get; set; }
        public OlvidoClaveVm()
        {
            this.Usuario = "";
            this.DocumentoIdentidad = "";

        }
    }
}
