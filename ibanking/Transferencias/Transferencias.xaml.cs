using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ibanking.Transferencias
{
    public enum Tipo_Cuenta
    {
        Origen = 1,
        Destino = 2
    }



    public partial class Transferencias : ContentPage
    {
        TransferenciaVM _vm;

        public TransferenciaVM vm {
			set
			{
				_vm = value;
				OnPropertyChanged("vm");
			}

            get {
                return _vm;
            }

           
        }

        ILoadingDIalog dialog;
        public string Frg_type { get; set; }
		

        public Transferencias()
        {
            InitializeComponent();
           Initialize();
        }

        void Initialize()
        {
			this.vm = new TransferenciaVM();
			dialog = DependencyService.Get<ILoadingDIalog>();
			this.BindingContext = this;
            this.Title = GetTitle();
			var onOrigenTap = new TapGestureRecognizer();
			var onDestinoTap = new TapGestureRecognizer();
			onOrigenTap.Tapped += (CuentaOrigen_Tapped);
			onDestinoTap.Tapped += (CuentaDestino_Tapped);

			if (Device.RuntimePlatform == Device.iOS)
			{
				scrollCuentaOrigen.GestureRecognizers.Add(onOrigenTap);
				scrollCuentaDestino.GestureRecognizers.Add(onDestinoTap);
				lblCuentaOrigen.TextColor = Color.FromHex("#ddd");
				lblCuentaDestino.TextColor = Color.FromHex("#ddd");

				vm.Cuenta_Origen = new Models.ChooseCuentaItem()
				{
					NOMBRE_PUBLICO = i18n.getString("L_SELECCIONE_CUENTA")
				};
				vm.Cuenta_Destino = new Models.ChooseCuentaItem()
				{
					NOMBRE_PUBLICO = i18n.getString("L_SELECCIONE_CUENTA")
				};
				ToolbarItems.Add(new ToolbarItem()
				{
					Text = i18n.getString("L_TRANSFERIR"),
					Command = new Command(Transferir)
				});

			}

			if (Device.RuntimePlatform == Device.Android)
			{

				btnCuentaOrigen.GestureRecognizers.Add(onOrigenTap);
				btnCuentaDestino.GestureRecognizers.Add(onDestinoTap);

			}
        }

        public Transferencias(string frg_type)
        {
            InitializeComponent();
            this.Frg_type = frg_type;
            Initialize();
        }

        async void ShowAlert(string msg)
        {
            await DisplayAlert("", msg, i18n.getString("L_ACEPTAR"));
        }
        async void Transferir()
        {

            if(vm.Cuenta_Origen == null || string.IsNullOrEmpty(vm.Cuenta_Origen.IDCUENTA ))
            {
                ShowAlert(i18n.getString("L_CUENTA_ORIGEN_REQUERIDA"));
                return;
            }

            if (vm.Cuenta_Destino == null || string.IsNullOrEmpty(vm.Cuenta_Destino.IDCUENTA))
			{
				ShowAlert(i18n.getString("L_CUENTA_DESTINO_REQUERIDA"));
				return;
			}

            if(vm.Cuenta_Origen.IDCUENTA == vm.Cuenta_Destino.IDCUENTA)
            {
                ShowAlert(i18n.getString("L_CUENTAS_IGUALES"));
                return;
            }

            if(vm.Cuenta_Origen.BALANCE < vm.Monto)
            {
                ShowAlert(i18n.getString("L_MONTO_MENOR"));
                return;
            }

            if(vm.Monto == 0 || vm.Monto < 0)
            {
                ShowAlert(i18n.getString("L_MONTO_REQUERIDO"));
                return;
            }
            var msgTx = i18n.getString("L_CONFIRM_TRANSFERENCIA")
                            .Replace("{monto}", String.Format("{0:C}", vm.Monto))
                            .Replace("{cuenta_origen}", vm.Cuenta_Origen.IDCUENTA)
                            .Replace("{cuenta_destino}", vm.Cuenta_Destino.IDCUENTA);

            var UserOk = await DisplayAlert("",
                                            msgTx,
                                            i18n.getString("L_ACEPTAR"),
                                            i18n.getString("L_CANCELAR"));

            if (UserOk)
            {


                dialog.Show();
                var msg = await vm.DoTransferencia(this.Frg_type);
                var toast = DependencyService.Get<IToast>();
                dialog.Hide();

                var resumen = new Resumen.Resumen();
                await Navigation.PushAsync(resumen);
                Models.Utils.ClearNavigationStack(this.Navigation);
                await resumen.refresh(true);
                toast.LongAlert(msg.DESCRIPCION);
            }

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


		void Buscar_Clicked(object sender, System.EventArgs e)
        {
            Transferir();
        }

        async void CuentaOrigen_Tapped(object sender, System.EventArgs e)
        {
            var cuentasOrigen = await GetOpenChooseAccount(Tipo_Cuenta.Origen);
            var chooseAccount = new Utils.ChooseAccount(cuentasOrigen);
            chooseAccount.OnItemSelected += (SelectedItem) =>
            {
                this.vm.Cuenta_Origen = SelectedItem;
                lblCuentaOrigen.TextColor = Color.FromHex("#4e6b4c");
               
            };
            await Navigation.PushModalAsync(new NavigationPage(chooseAccount));
        }

        async void CuentaDestino_Tapped(object sender, System.EventArgs e)
        {
			var cuentasDestino = await GetOpenChooseAccount(Tipo_Cuenta.Destino);
			var chooseAccount = new Utils.ChooseAccount(cuentasDestino);
			chooseAccount.OnItemSelected += (SelectedItem) =>
			{
                this.vm.Cuenta_Destino = SelectedItem;
                lblCuentaDestino.TextColor = Color.FromHex("#4e6b4c");
			};
            await Navigation.PushModalAsync(new NavigationPage(chooseAccount));
        }

        async Task<List<Models.ChooseCuentaItem>> GetOpenChooseAccount(Tipo_Cuenta tipo)
        {
            dialog.Show();
            var cuentas = await TransferenciasService.ListaDeCuentasTxMovil(Models.Shared.User.IDINSTITUCION, 
                                                                            Models.Shared.User.IDCLIENTE);
            if(tipo == Tipo_Cuenta.Origen)
            {
                var ret = TxAdapter.GetCuentasOrigen(cuentas, Frg_type);
                dialog.Hide();
                return ret;
            }
            else
            {
                var ret = TxAdapter.GetCuentasDestino(cuentas, Frg_type);
                dialog.Hide();
                return ret;
            }
        }

        string GetTitle()
        {
            switch (Frg_type)
            {
                case "tx":
                    return i18n.getString("L_TRANSFERENCIAS");

                case "pg":
                    return i18n.getString("L_PAGO_PRESTAMOS");

                case "dl":
                    return i18n.getString("L_DESEMBOLSO_LINEAS");

                default:
                    return i18n.getString("L_TRANSFERENCIAS");

            }
        }

        void Handle_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            var obj = (Entry)sender;
            obj.Text = String.Format("{0:C}", Convert.ToDecimal(obj.Text.Replace("$","").Replace(",","")));
        }

        void Monto_Tapped(object sender, System.EventArgs e)
        {
           txtMonto.Focus();
           
        }

       
    }
}
