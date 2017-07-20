using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.HistoricoList
{
    public partial class Historicolist : ContentPage
    {
        Models.HistoricoListAdapter _historico;

		public Models.HistoricoListAdapter Historico 
        {
            get {
                return _historico;
            }

            set {
                _historico = value;
                OnPropertyChanged();
            }
        }

        public Historicolist()
        {
            InitializeComponent();
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

		public Historicolist(Models.HistoricoListAdapter historico){
			InitializeComponent();
            this.Historico = historico;
            this.BindingContext = this;

            ToolbarItems.Add(new ToolbarItem(){
                Text = i18n.getString("L_CERRAR"),
                Command = new Command((obj) => {
                    Navigation.PushAsync(new Resumen.Resumen());
                    Models.Utils.ClearNavigationStack(this.Navigation);

                })
            });
        }
    }
}
