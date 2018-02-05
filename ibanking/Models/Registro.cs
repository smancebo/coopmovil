using System;
using System.Collections.Generic;

namespace ibanking.Models
{
    public class Registro
    {
        public List<Models.Documento> ListaTiposDocumento { get; set; }
		public List<Models.Documento> ListaPreguntasSecreta { get; set; }
		public List<Models.Documento> ListaComoSeEntero { get; set; }

		public Registro()
        {
            this.ListaTiposDocumento = new List<Documento>();
            this.ListaPreguntasSecreta = new List<Documento>();
            this.ListaComoSeEntero = new List<Documento>();
        }
    }
}
