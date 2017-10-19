using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.OlvidoClave
{
    public partial class OlvidoClave : ContentPage
    {
        OlvidoClaveVm _vm;
        public OlvidoClaveVm Vm {
            get {
                return _vm;
            }
            set {
                _vm = value;
                OnPropertyChanged();
            }
        }
        public OlvidoClave()
        {
            InitializeComponent();
            this.BindingContext = this.Vm;
        }

        async void Continuar_Clicked(object sender, System.EventArgs e)
        {
            if(this.Vm.Usuario == "") {
                await DisplayAlert("", i18n.getString("L_USUARIO_REQUERIDO"), i18n.getString("L_OK"));
                return;
            }
            if(this.Vm.DocumentoIdentidad == "") {
                await DisplayAlert("", i18n.getString("L_DOCUMENTO_REQUERIDO"), i18n.getString("L_OK"));
                return;
            }


        }
    }
}
