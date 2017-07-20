using System;
using System.Collections.Generic;
using ibanking.Models;
using Xamarin.Forms;
using ibanking.Strings;
using ibanking.Login;
using System.Threading.Tasks;

namespace ibanking
{
    public partial class CoopInfo : ContentPage
    {
        public string txtButtonAcceso;
        bool _canClose = true;
        public CoopInfo()
        {
            InitializeComponent();


            LabelFecha.Text = DateTime.Now.ToString("dd MMM yyyy");
            ImageLogo.Source = Shared.Institucion.Logo;
            ImageBanner.Source = Shared.Institucion.Banner;

            ButtonAcceso.Tapped = OnAccesoTap;
            ButtonOtherInfo.Tapped = OnOtherInfoTap;
            ButtonConfig.Tapped = OnConfiguracionTap;




        }

        protected override bool OnBackButtonPressed()
        {
            if(_canClose)
            {
                ShowExitDialog();

            }
            return _canClose;

        }

        async void ShowExitDialog()
        {
			var confirm = await DisplayAlert("",
									   i18n.getString("L_CONFIRM_EXIT"),
									   i18n.getString("L_ACEPTAR"),
									   i18n.getString("L_CANCELAR"));
            if(confirm){
                _canClose = false;
                if(Device.RuntimePlatform == Device.Android)
                {
                    var androidUtils = DependencyService.Get<IAdroidUtils>();
                    androidUtils.Close_App();
                }
            }
			
        }
         protected async void OnAccesoTap(object sender, EventArgs e){
            await Navigation.PushAsync(new Login.Login(), true);
        }

        protected async void OnOtherInfoTap(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new OtherInfo.OtherInfo(), true);
		}

        protected async void OnConfiguracionTap(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new Configuracion.Configuracion(), true);
		}
    }
}
