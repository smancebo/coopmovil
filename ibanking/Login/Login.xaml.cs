﻿using System;
using System.Collections.Generic;
using ibanking.Strings;
using Xamarin.Forms;

namespace ibanking.Login
{
	public partial class Login : ContentPage
	{



		public Login()
		{

			InitializeComponent();
			//Strings.strings.Culture = new System.Globalization.CultureInfo("en-US");
			
			imgLogo.Source = ibanking.Models.Shared.Institucion.Logo;
            txtUsername.Completed += (sender, e) => {
                txtPassword.Focus();
            };

            txtPassword.Completed += (sender, e) => {
                ButtonLogin.Focus();
            };


			ButtonLogin.Clicked += async (sender, e) =>
			{

                if(!string.IsNullOrEmpty(txtUsername.Text) && !string.IsNullOrEmpty(txtPassword.Text))
                {
					var dialog = DependencyService.Get<ILoadingDIalog>();
					dialog.Show();
					bool IsLogged = await LoginService.DoLogin(txtUsername.Text, txtPassword.Text);
					dialog.Hide();
					if (IsLogged)
					{
                        //var resumen = new NavigationPage(new Resumen.Resumen());
                        //Application.Current.MainPage = resumen;

                        //await Navigation.PopToRootAsync(true);
                        Models.Utils.ClearNavigationStack(Navigation);
                        //await Navigation.PushAsync(new ibanking.NavDrawerPage(), true);
                        Application.Current.MainPage = new NavDrawerPage();
					}
					else
					{
                        await DisplayAlert(i18n.getString("L_NO_INICIO_SESION"), 
                                           i18n.getString("L_USUARIO_CONTRASENA"), 
                                           i18n.getString("L_ACEPTAR"));
					}
                }
                else{
                    await DisplayAlert("", 
                                       i18n.getString("L_USUARIO_CONTRASENA_REQUERIDA"), 
                                       i18n.getString("L_ACEPTAR"));
                }
				
				

			};

		}
	}
}
