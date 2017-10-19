using System;
namespace ibanking.CambioClave
{
    public class CambioClaveVm
    {
        public string ClaveAnterior { get; set; }
        public string ClaveNueva { get; set; }
        public string ConfirmacionClave { get; set; }

        public CambioClaveVm()
        {
            this.ClaveNueva = "";
            this.ClaveAnterior = "";
            this.ConfirmacionClave = "";
        }
    }
}
