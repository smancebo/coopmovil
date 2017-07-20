using System;
using System.Collections.Generic;

using Xamarin.Forms;


namespace ibanking.Historico
{
    [Preserve(AllMembers = true)]
    public partial class Historico : ContentPage
    {
        HistoricoVm _vm;

        public HistoricoVm vm {
            get  {
                return _vm;
            }

            set {
                _vm = value;
                OnPropertyChanged("vm");
            }
        }
        List<Models.ChooseCuentaItem> cuentas;
        ILoadingDIalog dialog;

        public Historico()
        {
            InitializeComponent();
            this.BindingContext = this;
            lblFechaDesde.Text = DateTime.Now.ToString("dd-MM-yyyy");
            lblFechaHasta.Text = DateTime.Now.ToString("dd-MM-yyyy");

            vm = new HistoricoVm()
            {
                Transaccion = new Models.ChooseTransaccionItem() { Index = 0, Descripcion = i18n.getString("L_TODAS") }
            };
            var tap = new TapGestureRecognizer();
            var tapTrs = new TapGestureRecognizer();

            tap.Tapped += Cuentas_Tapped;
            tapTrs.Tapped += Transacciones_Tapped;

            scrollCuentas.GestureRecognizers.Add(tap);
            scrollTransacciones.GestureRecognizers.Add(tapTrs);
            lblCuenta.TextColor = Color.FromHex("#ddd");
            lblTransaccion.TextColor = Color.FromHex("#ddd");

            if (Device.RuntimePlatform == Device.iOS)
            {
                btnBuscar.IsVisible = false;
                ToolbarItems.Add(new ToolbarItem()
                {
                    Text = i18n.getString("L_BUSCAR"),
                    Order = ToolbarItemOrder.Primary,
                    Command = new Command((obj) =>
                    {
                        Search();
                    })

                });
            }
            lblTransaccion.Text = vm.Transaccion.Descripcion;
            dialog = DependencyService.Get<ILoadingDIalog>();

        }


        async void Search()
        {
            if(string.IsNullOrEmpty(vm.Cuenta.IDCUENTA))
            {
                await DisplayAlert("", i18n.getString("L_CUENTA_REQUERIDA"),i18n.getString("L_ACEPTAR"));
                return;
            }
            dialog.Show();
            var movimientos = await vm.Buscar();
            movimientos.Mostrar_Concepto = this.vm.Mostrar_Detalle;
            dialog.Hide();
            await Navigation.PushAsync(new HistoricoList.Historicolist(movimientos));
        }

        void Open_Fecha_Desde(object sender, System.EventArgs e)
        {
            txtFechaDesde.Focus();
        }

        void Open_Fecha_Hasta(object sender, System.EventArgs e)
        {
            txtFechaHasta.Focus();
        }


        void Fecha_Hasta_Selected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            lblFechaHasta.Text = e.NewDate == null ? e.OldDate.ToString("dd-MM-yyyy") : e.NewDate.ToString("dd-MM-yyyy");
            vm.Fecha_Hasta = e.NewDate == null ? e.OldDate : e.NewDate;
        }

        void Fecha_Desde_Selected(object sender, Xamarin.Forms.DateChangedEventArgs e)
        {
            lblFechaDesde.Text = e.NewDate == null ? e.OldDate.ToString("dd-MM-yyyy") : e.NewDate.ToString("dd-MM-yyyy");
            vm.Fecha_Desde = e.NewDate == null ? e.OldDate : e.NewDate;
        }


        void Buscar_Clicked(object sender, System.EventArgs e)
        {
            Search();

        }

        async void Cuentas_Tapped(object sender, System.EventArgs e)
        {
            dialog.Show();
            cuentas = await Utils.UtilService.ListaDeCuentasMovil(
              Models.Shared.User.IDINSTITUCION,
              Models.Shared.User.IDCLIENTE);
            dialog.Hide();
            var chooseAccount = new Utils.ChooseAccount(cuentas);
            chooseAccount.OnItemSelected += (SelectedItem) =>
            {
                //Navigation.PopModalAsync();
                vm.Cuenta = SelectedItem;
                lblCuenta.Text = SelectedItem.NOMBRE_PUBLICO;
                lblCuenta.TextColor = Color.FromHex("#4e6b4c");
            };


            await Navigation.PushModalAsync(new NavigationPage(chooseAccount));
        }

       
       
        void Transacciones_Tapped(object sender, System.EventArgs e)
        {
            var chooseTransaccion = new Utils.ChooseTransaccion();
            chooseTransaccion.OnTransaccionChoosed += (SelectedItem) => 
            {
                vm.Transaccion = SelectedItem;
                lblTransaccion.Text = SelectedItem.Descripcion;
                lblTransaccion.TextColor = Color.FromHex("#4e6b4c");

            };

            Navigation.PushModalAsync(new NavigationPage(chooseTransaccion));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = false;
        }

       protected override void OnDisappearing()
        {
            base.OnDisappearing();
			(Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = true;
        }


        void Solo_TX_OnChanged(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            vm.Solo_Transferencias = e.Value;
        }

		void Mostrar_detalle_changed(object sender, Xamarin.Forms.ToggledEventArgs e)
		{
            vm.Mostrar_Detalle = e.Value;
		}


    }
}
