using System;
namespace ibanking.Models
{
    public class TransferenciaMsj
    {
        public string CODIGO { get; set; }
        public string DESCRIPCION { get; set; }

        public TransferenciaMsj()
        {
            this.CODIGO = "";
            this.DESCRIPCION = "";
        }
    }
}
