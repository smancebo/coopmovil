using System;
namespace ibanking.Models
{


    public class ChooseTransaccionItem
    {
        public int Index { get; set; }
        public string Descripcion { get; set; }

        public ChooseTransaccionItem()
        {
            this.Index = 0;
            this.Descripcion = "";
        }
    }
}
