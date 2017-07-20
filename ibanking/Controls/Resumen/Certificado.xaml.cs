using System;
using System.Collections.Generic;
using Xamarin.Forms;
using ibanking.Strings;
namespace ibanking.Controls.Resumen
{
    public partial class Certificado : Grid
    {
        public Certificado()
        {
            InitializeComponent();
           
        }

		public Certificado(Models.Certificado certificado)
		{
			InitializeComponent();
			

            lblCertificado.Text = certificado.IDCertificado;
            lblMonto.Text = certificado.Monto_Emision.ToString("C");
            lblBalance.Text = certificado.Balance.ToString("C");
            lblDescription.Text = certificado.Nombre_Publico;
		}
    }
}
