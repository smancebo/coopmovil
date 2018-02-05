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
            vm.RESPUESTA = "";
            this.Vm = vm;
            this.BindingContext = this.Vm;
        }

        async void Continuar_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var datos = await Registro.RegistroService.RecuperarClaveMovil(this.Vm.USUARIO,
                                                                         this.Vm.RESPUESTA,
                                                                          this.Vm.EMAIL);
                await DisplayAlert("", datos.DESCRIPCION, i18n.getString("L_OK"));
                Models.Utils.LogOff();
            }
            catch(Exception ex) {
                await DisplayAlert("", ex.Message, i18n.getString("L_OK"));
            }
           
            
        }
    }
}
