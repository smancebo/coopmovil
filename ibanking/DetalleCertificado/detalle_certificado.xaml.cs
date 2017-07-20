using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.DetalleCertificado
{
    public partial class detalle_certificado : ContentPage
    {
        bool _showCertificado;
        public string IDCERTIFICADO { get; set; }

        public bool ShowCertificado {
            get {
                return _showCertificado;
            }

            set {
                _showCertificado = value;
                OnPropertyChanged();
            }
        }
        public detalle_certificado()
        {
            InitializeComponent();
            this.ShowCertificado = false;
            this.BindingContext = this;
        }

		

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			(Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = true;
		}



		protected override async void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = false;
            var dialog = DependencyService.Get<ILoadingDIalog>();
            ShowCertificado = false;
            dialog.Show();

            var detalleCertificado = await DetalleCertificadoService.BuscarCertificadosMovil(
                Models.Shared.User.IDINSTITUCION,
                this.IDCERTIFICADO
            );

            certificado.BindingContext = detalleCertificado;
            ShowCertificado = true;
            dialog.Hide();

        }

        void BtnVerMas_Clicked(object sender, System.EventArgs e)
        {
			btnViewMore.Text = viewMore.IsVisible ? i18n.getString("L_VER_MAS") : i18n.getString("L_VER_MENOS");
			viewMore.IsVisible = !viewMore.IsVisible;
        }
    }
}
