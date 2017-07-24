using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ibanking.Services;
using ibanking.Models;
using Xamarin.Forms;

namespace ibanking
{
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();
           
        }

        protected override async void OnAppearing(){
            if(await Services.CheckConnection.IsOnline())
            {
				var inst = await GetDatosInst();
				Models.Shared.Institucion = inst;
                if (inst.MSG != "")
                {


                    var coopinfo = new NavigationPage(new CoopInfo());

                    //coopinfo.

                    await Task.Run(async () =>
                    {
                        await Task.Delay(300);
                        Device.BeginInvokeOnMainThread(() =>
                        {
                            Application.Current.MainPage = coopinfo;
                        });

                    });
                }else
                {
                    await DisplayAlert("", inst.MSG, i18n.getString("L_ACEPTAR"));
                }


				
            }else{
                await DisplayAlert(i18n.getString("L_ERROR_CONEXION"),
                                   i18n.getString("L_COOPMOVIL_OFFLINE"),
                                   i18n.getString("L_ACEPTAR"));

            }
			
        }

        public async Task<Institucion> GetDatosInst(){
			var institucion = await ibanking.Services.Splash.GetDatosInstitucion();
            return institucion;
        }
    }
}
