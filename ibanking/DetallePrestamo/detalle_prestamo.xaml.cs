using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.DetallePrestamo
{
    [Preserve(AllMembers = true)]
    public partial class detalle_prestamo : ContentPage
    {
        bool _showPrestamo;
        public string IDPRESTAMO { get; set; }
        public bool ShowPrestamo
        {
            get
            {
                return _showPrestamo;
            }
            set
            {
                _showPrestamo = value;
                OnPropertyChanged();
            }
        }

		
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			(Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = true;
		}


		public detalle_prestamo()
        {
            InitializeComponent();
            this.IDPRESTAMO = "";
            this.ShowPrestamo = false;
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = false;
            var dialog = DependencyService.Get<ILoadingDIalog>();
            dialog.Show();
            ShowPrestamo = false;

            var detallePrestamo = await DetallePrestamoService.BuscarPrestamoMovil(
                Models.Shared.User.IDINSTITUCION, 
                this.IDPRESTAMO);

            prestamo.BindingContext = detallePrestamo;
            dialog.Hide();
            ShowPrestamo = true;
        }

        void VerMas_Clicked(object sender, System.EventArgs e)
        {
            btnViewMore.Text = viewMore.IsVisible ?
                i18n.getString("L_VER_MAS") : i18n.getString("L_VER_MENOS");
            viewMore.IsVisible = !viewMore.IsVisible;
        }
    }
}
