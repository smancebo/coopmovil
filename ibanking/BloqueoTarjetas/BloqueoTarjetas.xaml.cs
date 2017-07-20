using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ibanking.BloqueoTarjetas
{
    public partial class BloqueoTarjetas : ContentPage
    {
        ILoadingDIalog dialog;
        IToast toast;
        BloqueoTarjetaVM _vm;
        Models.BloqueoTarjetaModel Tipo_Bloqueo_Info;

        public BloqueoTarjetaVM vm {
            get
            {
                return _vm;
            }

            set 
            {
                _vm = value;
                OnPropertyChanged();
            }
        }
        public BloqueoTarjetas()
        {
            InitializeComponent();
            var tarjetasTapped = new TapGestureRecognizer();
            var tipoBloqueoTapped = new TapGestureRecognizer();

            tarjetasTapped.Tapped += Tarjetas_Tapped;
            tipoBloqueoTapped.Tapped += TiposBloqueo_Tapped;

            scrollTarjeta.GestureRecognizers.Add(tarjetasTapped);
            scrollTipoBloqueo.GestureRecognizers.Add(tipoBloqueoTapped);


            dialog = DependencyService.Get<ILoadingDIalog>();
            toast = DependencyService.Get<IToast>();
            this.BindingContext = this;
            this.vm = new BloqueoTarjetaVM();
            lblTarjeta.TextColor = Color.FromHex("#ddd");
            lblTipoBloqueo.TextColor = Color.FromHex("#ddd");


            this.vm.Tarjeta = new Models.ChooseTarjetaItem()
            {
                tarjetaEncriptada = i18n.getString("L_CHOOSE_CARD")
            };
            this.vm.Tipo_Bloqueo = new Models.ChooseTipoBloqueoItem()
            {
                T_TiposDeBloqueo_Descripcion = i18n.getString("L_CHOOSE_BLOCK_TYPE")
            };

            if(Device.RuntimePlatform == Device.iOS)
            {
                ToolbarItems.Add(new ToolbarItem()
                {
                    Text = i18n.getString("L_ACEPTAR"),
                    Command = new Command(Bloquear)
                        
                });
            }
        }

        async void Bloquear()
        {

            if (string.IsNullOrEmpty(this.vm.Tarjeta.tarjeta))
            {
                await DisplayAlert("", i18n.getString("L_CARD_REQUIRED"), i18n.getString("L_ACEPTAR"));
                return;
            }
            if (string.IsNullOrEmpty(this.vm.Tipo_Bloqueo.T_TiposDeBloqueo_Codigo))
            {
                await DisplayAlert("", i18n.getString("L_BLOCK_TYPE_REQUIRED"), i18n.getString("L_ACEPTAR"));
                return;
            }

            var msg = i18n.getString("L_CONFIRM_BLOQUEO_TARJETA")
                          .Replace("{tarjeta}", vm.Tarjeta.tarjetaEncriptada);
            
            var blockAnswer = await DisplayAlert(i18n.getString("L_CONFIRM_COOPMOVIL"),
                                                 msg,
                                                 i18n.getString("L_ACEPTAR"),
                                                 i18n.getString("L_CANCELAR"));
            if (blockAnswer)
            {
                dialog.Show();
                var msgBlock = await this.vm.Bloquear();
                dialog.Hide();

                var resumen = new Resumen.Resumen();
                await Navigation.PushAsync(resumen);
                Models.Utils.ClearNavigationStack(this.Navigation);
                await resumen.refresh(true);
                toast.LongAlert(msgBlock.DESCRIPCION);
            }
        }

        async void Tarjetas_Tapped(object sender, System.EventArgs e)
        {
            var chooseTarjeta = new Utils.ChooseTarjeta(Tipo_Bloqueo_Info.Tarjetas);
            chooseTarjeta.OnItemSelected += (item) => 
            {
                this.vm.Tarjeta = item;
                lblTarjeta.TextColor = Color.FromHex("#4e6b4c");
            };

            await Navigation.PushModalAsync(new NavigationPage(chooseTarjeta));
        }


        async void TiposBloqueo_Tapped(object sender, System.EventArgs e)
        {
            var tipoBloqueo = new Utils.ChooseTipoBloqueo(Tipo_Bloqueo_Info.TiposBloqueos);
            tipoBloqueo.OnItemSelected += (item) => {
                this.vm.Tipo_Bloqueo = item;
                lblTipoBloqueo.TextColor = Color.FromHex("#4e6b4c");
            };
            await Navigation.PushModalAsync(new NavigationPage(tipoBloqueo));
        }

      
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if(Tipo_Bloqueo_Info == null)
            {
				dialog.Show();
				Tipo_Bloqueo_Info = await BloqueoTarjetasService.BuscarClienteTdMovil(Models.Shared.User.IDINSTITUCION, Models.Shared.User.DOC_IDENTIFICACION);
				dialog.Hide();
            }
           
        }

        void Buscar_Clicked(object sender, System.EventArgs e)
        {
            Bloquear();
        }

        void Concepto_Tapped(object sender, System.EventArgs e)
        {
            txtConcepto.Focus();
        }
    }
}
