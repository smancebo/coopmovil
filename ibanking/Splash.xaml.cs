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


				
            }else{
                await DisplayAlert(Strings.strings.noConnection,
                                   Strings.strings.noConnectionError,
                                   Strings.strings.Ok);

            }
			
        }

        public async Task<Institucion> GetDatosInst(){
			var institucion = await ibanking.Services.Splash.GetDatosInstitucion();
            return institucion;
        }
    }
}
