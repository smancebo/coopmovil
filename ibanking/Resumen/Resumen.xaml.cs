using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ibanking.Resumen
{
    [Preserve(AllMembers = true)]
    public partial class Resumen : ContentPage
    {
     
        public Resumen()
        {
            InitializeComponent();
            Title = i18n.getString("L_RESUMEN");

            if(Device.RuntimePlatform == Device.Android){
                pullToRefresh.RefreshColor = Color.FromHex("#00695C");
            }
           
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if(Navigation.NavigationStack.Count == 1){
                await GetData();
            }

            pullToRefresh.RefreshCommand = new Command(async() => await GetData(true));
                   

        }

        protected override bool OnBackButtonPressed()
        {
            askLogOff();
            return true;
        }

        async void askLogOff()
        {
			var alert = await DisplayAlert(i18n.getString(""),
											 i18n.getString("L_ALERT_LOGOUT"),
											 i18n.getString("L_ACEPTAR"),
											 i18n.getString("L_CANCELAR"));

			if (alert == true)
			{
				Models.Utils.LogOff();
			}
        }

        public async Task<bool> refresh(bool hideDialog = false)
        {
            return await GetData(hideDialog);
        }

        private async Task<bool> GetData(bool hideDialog = false){
			var dialog = DependencyService.Get<ILoadingDIalog>();
			//Models.Utils.ClearNavigationStack(Navigation);

            dialog.Hide();
            if(!hideDialog)
			    dialog.Show();
            lstResumen.IsVisible = false;
			lstResumen.Children.Clear();

			var Res = await ResumenService.cuentasPorClientes(
				Models.Shared.User.IDINSTITUCION,
				Models.Shared.User.IDCLIENTE
			);

			var fs = new FormattedString();
			fs.Spans.Add(new Span() { Text = i18n.getString("L_TRANS_FECHA") });
			fs.Spans.Add(new Span() { Text = Res.FechaProceso.ToString("dd/MM/yyyy"), FontAttributes = FontAttributes.Bold });
			lblFechaProceso.FormattedText = fs;

			//Bind Cuentas de ahorro
			if (Res.CuentasdeAhorro.Count > 0)
			{
				lstResumen.Children.Add(new Controls.Resumen.separator(i18n.getString("L_CUENTAS_AHORROS")));
				foreach (var cuenta in Res.CuentasdeAhorro)
				{
					var view = new Controls.Resumen.Ahorro(cuenta);
                    var onTapped = new TapGestureRecognizer();
                    onTapped.Tapped += (sender, e) =>
                    {
                        var detalleAhorroView = new DetalleAhorro.detalle_ahorro()
                        {
                            IDCUENTA = cuenta.IDCuenta
                        };

                        Navigation.PushAsync(detalleAhorroView);
                    };
                    view.GestureRecognizers.Add(onTapped);
					lstResumen.Children.Add(view);
				}
			}

			if (Res.Prestamos.Count > 0)
			{
				lstResumen.Children.Add(new Controls.Resumen.separator(i18n.getString("L_PRESTAMOS")));
				foreach (var prestamo in Res.Prestamos)
				{
					var view = new Controls.Resumen.Prestamo(prestamo);
                    var onTapped = new TapGestureRecognizer();
                    onTapped.Tapped += (sender, e) =>
                    {
                        var detallePrestamo = new DetallePrestamo.detalle_prestamo()
                        {
                            IDPRESTAMO = prestamo.IDPrestamo
                        };

                        Navigation.PushAsync(detallePrestamo);
                    };
                    view.GestureRecognizers.Add(onTapped);
					lstResumen.Children.Add(view);
				}
			}

			if (Res.Certificados.Count > 0)
			{
				lstResumen.Children.Add(new Controls.Resumen.separator(i18n.getString("L_CERTIFICADOS")));
				foreach (var certificado in Res.Certificados)
				{
					var view = new Controls.Resumen.Certificado(certificado);
                    var onTapped = new TapGestureRecognizer();
                    onTapped.Tapped += (sender, e) => {
                        var detalleCertificado = new DetalleCertificado.detalle_certificado()
                        {
                            IDCERTIFICADO = certificado.IDCertificado
                        };
                        Navigation.PushAsync(detalleCertificado);
                    };
                    view.GestureRecognizers.Add(onTapped);
					lstResumen.Children.Add(view);
				}
			}

			if (Res.Aportaciones.Count > 0)
			{
				lstResumen.Children.Add(new Controls.Resumen.separator(i18n.getString("L_APORTACIONES")));
				foreach (var aportacion in Res.Aportaciones)
				{
                    var view = new Controls.Resumen.Aportacion(aportacion);
                    var onTapped = new TapGestureRecognizer();
                    onTapped.Tapped += (sender, e) => {
                        var detalleAportacion = new DetalleAportacion.detalle_aportacion()
                        {
                            IDAPORTACION = aportacion.IDAportacion
                        };

                        Navigation.PushAsync(detalleAportacion);
                    };
					
                    view.GestureRecognizers.Add(onTapped);
					lstResumen.Children.Add(view);
				}
			}

			lstResumen.IsVisible = true;
			dialog.Hide();
            pullToRefresh.IsRefreshing = false;

            return true;

        }


    }
}
