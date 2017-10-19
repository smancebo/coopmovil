using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.OlvidoClave
{
    public partial class RecuperarClave : ContentPage
    {
        Models.DatosRecuperarClave _vm;
        public Models.DatosRecuperarClave Vm {
            get {
                return _vm;
            }
            set {
                _vm = value;
                OnPropertyChanged();
            }
        }
        public RecuperarClave(Models.DatosRecuperarClave vm)
        {
            InitializeComponent();
            this.Vm = vm;
            this.BindingContext = this.Vm;
        }

        async void Continuar_Clicked(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
