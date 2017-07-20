using System;
using System.Collections.Generic;

namespace ibanking.Models
{
    public class HistoricoListAdapter
    {
        public decimal Balance { get; set; }
        public List<Movimiento> Movimientos { get; set; }
        public bool Mostrar_Concepto { get; set; }

        public HistoricoListAdapter()
        {
            this.Balance = 0;
            this.Movimientos = new List<Movimiento>();
            this.Mostrar_Concepto = false;
        }
    }
}
