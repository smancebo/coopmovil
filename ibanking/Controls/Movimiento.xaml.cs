using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace ibanking.Controls
{
    [Preserve(AllMembers = true)]
    public partial class Movimiento : StackLayout, INotifyPropertyChanged
    {
        bool _mostrarConcepto = false;

        public bool MostrarConcepto { 
            get{
                return _mostrarConcepto;
            } 
            set{
                _mostrarConcepto = value;
                OnPropertyChanged();
            } 
        }
        public string TipoProducto { get; set; }

       
        public Movimiento()
        {
            InitializeComponent();
        }

        public Movimiento(Models.Movimiento movimiento, string tipoProducto, bool MostrarConcepto){
            InitializeComponent();

            this.BindingContext = movimiento;
            if(MostrarConcepto && !string.IsNullOrEmpty(movimiento.CONCEPTO)){
                concepto.IsVisible = true;
            }
            else{
                concepto.IsVisible = false;
            }

            if(tipoProducto == "pr"){
                lblTipoMovimiento.Text = movimiento.FLAG_DEBITO_O_CREDITO == "1" ? i18n.getString("L_DESEMBOLSO") : i18n.getString("L_PAGO");
            }else{
                lblTipoMovimiento.Text = movimiento.FLAG_DEBITO_O_CREDITO == "1" ? i18n.getString("L_RETIRO") : i18n.getString("L_DEPOSITO");
            }
        }
    }
}
