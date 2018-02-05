using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.CambioClave
{
    public partial class CambioClave : ContentPage
    {
        CambioClaveVm _vm { get; set; }
        public string USERNAME { get; set; }

        public CambioClaveVm Vm {
            get {
                return this._vm;
            }
            set {
                this._vm = value;
                OnPropertyChanged();
            }
        }

        public CambioClave()
        {
            InitializeComponent();
            Vm = new CambioClaveVm();
            this.BindingContext = this.Vm;
            this.USERNAME = "";
        }
        public CambioClave(string username) : this()
        {
            this.USERNAME = username;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async void BtnAceptar_Clicked(object sender, System.EventArgs e)
        {
            var dialog = DependencyService.Get<ILoadingDIalog>();
            try {
                if (this.Vm.ClaveNueva == this.Vm.ConfirmacionClave)
                {
                    
                    dialog.Show();
                    var response = await Registro.RegistroService.CambiarClaveMovil(Models.Shared.User.IDINSTITUCION,
                                                                                    this.USERNAME,
                                                                                    this.Vm.ClaveAnterior,
                                                                                    this.Vm.ClaveNueva,
                                                                                    Models.Shared.User.IDCLIENTE,
                                                                                    Models.Shared.User.CAMBIAR_CLAVE
                                                                                   );
                    dialog.Hide();
                    await DisplayAlert("", response.DESCRIPCION, i18n.getString("L_OK"));
                    if (response.CODIGO == "1")
                    {
                        Models.Utils.ClearNavigationStack(Navigation);
                        Application.Current.MainPage = new NavDrawerPage();
                    }
                }
                else
                {
                    await DisplayAlert("", i18n.getString("L_CLAVE_NOT_EQ"), i18n.getString("L_OK"));
                }
            }
            catch (Exception ex) {
                dialog.Hide();
                await DisplayAlert("", ex.Message, i18n.getString("L_OK"));
            }
           
        }
    }
}
