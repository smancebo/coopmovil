using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ibanking.Strings;

namespace ibanking.Controls.Resumen
{
    public partial class Prestamo : Grid
    {
        public Prestamo()
        {
            InitializeComponent();
         
        }

        public Prestamo(Models.Prestamo prestamo){
            InitializeComponent();

            lblDescription.Text = prestamo.Descripcion_Tipo;
            lblPrestamo.Text = prestamo.IDPrestamo;
            lblMonto.Text = prestamo.Monto_Prestamo.ToString("C");
            lblBalance.Text = prestamo.Balance_Prestamo.ToString("C");
            lblVencido.Text = prestamo.Total_Vencido.ToString("C");

        }
    }
}
