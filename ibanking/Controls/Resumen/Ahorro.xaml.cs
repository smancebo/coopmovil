using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ibanking.Strings;

namespace ibanking.Controls.Resumen
{
    public partial class Ahorro : Grid
    {
       
        public Models.CuentaAhorro Cuenta { get; set; }
        public Ahorro()
        {
            InitializeComponent();
           
            this.Cuenta = new Models.CuentaAhorro();
           
        }

        public Ahorro(ibanking.Models.CuentaAhorro cuenta){
			InitializeComponent();
			
            lblCuenta.Text = cuenta.IDCuenta;
            lblEstatus.Text = cuenta.Estatus;
            lblBalance.Text = cuenta.Balance_Actual.ToString("C");
            lblDisponible.Text = cuenta.Balance_Disponible.ToString("C");
           
        }
    }
}
