using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.DetalleAportacion
{
    public partial class detalle_aportacion : ContentPage
    {
        bool _showAportacion;

        public string IDAPORTACION { get; set; }
        public bool ShowAportacion 
        {
            get {
                return _showAportacion;
            }   

            set {
                _showAportacion = value;
                OnPropertyChanged();
            }
        }

		

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			(Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = true;
		}


		public detalle_aportacion()
        {
            InitializeComponent();
            this.ShowAportacion = false;
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = false;
            var dialog = DependencyService.Get<ILoadingDIalog>();
            ShowAportacion = false;
            dialog.Show();

            var detalleAportacion = await DetalleAportacionService.BuscarAccionesMovil(
                Models.Shared.User.IDINSTITUCION,
                this.IDAPORTACION
            );

            aportacion.BindingContext = detalleAportacion;

            ShowAportacion = true;
            dialog.Hide();
        }

		void BtnVerMas_Clicked(object sender, System.EventArgs e)
		{
			btnViewMore.Text = viewMore.IsVisible ? i18n.getString("L_VER_MAS") : i18n.getString("L_VER_MENOS");
			viewMore.IsVisible = !viewMore.IsVisible;
		}
    }
}
