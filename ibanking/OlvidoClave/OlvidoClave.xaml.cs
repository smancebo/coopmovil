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
            this.Vm = new OlvidoClaveVm();
            this.BindingContext = this.Vm;
        }

        async void Continuar_Clicked(object sender, System.EventArgs e)
        {
            if(this.Vm.Usuario == "") {
                await DisplayAlert("", i18n.getString("L_USERNAME_REQ"), i18n.getString("L_OK"));
                return;
            }
            if(this.Vm.DocumentoIdentidad == "") {
                await DisplayAlert("", i18n.getString("L_DOCUMENTO_REQ"), i18n.getString("L_OK"));
                return;
            }

            var datos = await Registro.RegistroService.DatosRecuperarClaveMovil(this.Vm.Usuario, this.Vm.DocumentoIdentidad);
            if(datos.PREGUNTA == "") {
                await DisplayAlert("", datos.DESCRIPCION, i18n.getString("L_OK"));
                return;
            }
            datos.USUARIO = this.Vm.Usuario;
            var recuperarClave = new RecuperarClave(datos);

            await Navigation.PushAsync(recuperarClave);

        }
    }
}
