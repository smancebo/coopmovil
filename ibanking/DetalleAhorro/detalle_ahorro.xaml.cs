using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace ibanking.DetalleAhorro
{
    [Preserve(AllMembers = true)]
    public partial class detalle_ahorro : ContentPage, INotifyPropertyChanged
    {
        bool _showAccount = false;
        public string IDCUENTA { get; set; }
        public bool ShowAccount { 
            get{
                return _showAccount;
            } set{
                _showAccount = value;
                OnPropertyChanged();
            } 
        }

		

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			(Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = true;
		}



		//public event PropertyChangedEventHandler PropertyChanged;

		//public void OnPropertyChanged([CallerMemberName] string name = ""){
		//    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name))
		//}

		public detalle_ahorro()
        {
            InitializeComponent();
            this.IDCUENTA = "";
            this.BindingContext = this;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current.MainPage as NavDrawerPage).IsGestureEnabled = false;
            var dialog = DependencyService.Get<ILoadingDIalog>();

            dialog.Show();
            ShowAccount = false;
            var detalleAhorro = await DetalleAhorroService.BuscarAhorrosMovil(
                Models.Shared.User.IDINSTITUCION, 
                this.IDCUENTA);

            account.BindingContext = detalleAhorro;
            //movimientos.

            dialog.Hide();
            ShowAccount = true;
            
        }

        void btnViewMore_Clicked(object sender, System.EventArgs e)
        {
            btnViewMore.Text = viewMore.IsVisible ? i18n.getString("L_VER_MAS") : i18n.getString("L_VER_MENOS");
			viewMore.IsVisible = !viewMore.IsVisible;
        }
    }
}
