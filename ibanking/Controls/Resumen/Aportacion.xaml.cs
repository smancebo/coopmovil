using System;
using System.Collections.Generic;
using ibanking.Strings;

using Xamarin.Forms;

namespace ibanking.Controls.Resumen
{
    public partial class Aportacion : Grid
    {
        public Aportacion()
        {
            InitializeComponent();
           
        }

		public Aportacion(Models.Aportacion aportacion)
		{
			InitializeComponent();
			
            lblDescripcion.Text = aportacion.Nombre_Publico;
            lblAportacion.Text = aportacion.IDAportacion;
            lblBalance.Text = aportacion.Monto_Actual_Aportacion.ToString("C");
		}
    }
}
