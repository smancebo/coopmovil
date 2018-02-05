﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.Registro
{
    public partial class Registro : ContentPage
    {

        RegistroVm _vm;
        Models.Registro _ListaDocumentos;

        public Models.Registro ListaDocumentos {
            get {
                return _ListaDocumentos;
            }
            set {
                _ListaDocumentos = value;
                OnPropertyChanged("ListaDocumentos");
            }
        }

        public RegistroVm vm {
            get {
                return _vm;
            }
            set {
                _vm = value;
                OnPropertyChanged("vm");
            }
        }

        public Registro()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            this.ListaDocumentos = await RegistroService.GetListaRegistroMovil();
            this.vm = new RegistroVm();
            this.BindingContext = this;
            txtOtros.Text = "";
            txtOtros.IsVisible = false;
        }

        async void BtnRegistro_Clicked (object sender, System.EventArgs e)
        {
            var msg = "";

            if (this.vm.TipoDocumento.ID == "")
            {
                await DisplayAlert("", i18n.getString("L_TIPO_DOCUMENTO_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.Documento == "")
            {
                await DisplayAlert("", i18n.getString("L_DOCUMENTO_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.Telefono == "")
            {
                await DisplayAlert("", i18n.getString("L_TELEFONO_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.Email == "")
            {
                await DisplayAlert("", i18n.getString("L_EMAIL_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.UserName == "")
            {
                await DisplayAlert("", i18n.getString("L_USERNAME_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.Pregunta.ID == "")
            {
                await DisplayAlert("", i18n.getString("L_PREGUNTA_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.Respuesta == "")
            {
                await DisplayAlert("", i18n.getString("L_RESPUESTA_REQ"), i18n.getString("L_OK"));
                return;
            }

            if (this.vm.ComoSeEntero.ID == "")
            {
                await DisplayAlert("", i18n.getString("L_COMO_SE_ENTERO_REQ"), i18n.getString("L_OK"));
                return;
            }

           

            try {
				var response = await RegistroService.CrearAccesoMovil(Models.Shared.User.IDINSTITUCION,
																  this.vm.TipoDocumento.ID,
																  this.vm.Documento,
                                                                      this.vm.Telefono,
																  this.vm.Email,
																  this.vm.UserName,
																  this.vm.Pregunta.ID,
																  this.vm.Respuesta,
																  this.vm.ComoSeEntero.ID,
																  this.vm.ComoSeEnteroOtro);
                msg = response.DESCRIPCION;
			}
            catch (Exception ex) {
                msg = ex.Message;
            }

            await DisplayAlert("",msg, i18n.getString("L_OK"));
            Models.Utils.LogOff();
           
        }

        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = (Picker)sender;
            var comoSeEntero = (Models.Documento)picker.SelectedItem;

            if(comoSeEntero.ID == "99") {
                txtOtros.IsVisible = true;
            } else {
                txtOtros.IsVisible = false;
            }
        }
    }
}
