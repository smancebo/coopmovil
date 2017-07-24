

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ibanking
{
    [Preserve(AllMembers = true)]
    public partial class NavDrawerPage : MasterDetailPage
    {
        public List<Models.MasterPageItem> menuList { get; set; }
        public NavDrawerPage()
        {
            InitializeComponent();

            lblCliente.Text = Models.Shared.User.NOMBRE;
            this.MasterBehavior = MasterBehavior.Popover;
            menuList = new List<Models.MasterPageItem>();

            var resumen = new Models.MasterPageItem() { Title = i18n.getString("L_RESUMEN"), Icon = "" , TargetType = typeof(Resumen.Resumen) };
            var historico = new Models.MasterPageItem() { Title = i18n.getString("L_HISTORICO"), Icon = "", TargetType = typeof(Historico.Historico) };
            var transferencia = new Models.MasterPageItem() { Title = i18n.getString("L_TRANSFERENCIAS"), Icon = "", TargetType = typeof(Transferencias.Transferencias), frgType="tx" };      
            var pago = new Models.MasterPageItem() { Title = i18n.getString("L_PAGO_PRESTAMOS"), Icon = "", TargetType = typeof(Transferencias.Transferencias), frgType = "pg" };
			var desembolso = new Models.MasterPageItem() { Title = i18n.getString("L_DESEMBOLSO_LINEAS"), Icon = "", TargetType = typeof(Transferencias.Transferencias), frgType = "dl" };
            var bloqueoTc = new Models.MasterPageItem() { Title = i18n.getString("L_BLOQUEO_TARJETA"), Icon = "", TargetType = typeof(BloqueoTarjetas.BloqueoTarjetas) };
            var logout = new Models.MasterPageItem() { Title = i18n.getString("L_CERRAR_SESION"), Icon = "" };

            //menuList.Add(resumen);
            menuList.Add(historico);


            if(Models.Shared.Institucion.TRANSFERENCIA)
            {
                menuList.Add(transferencia);
            }

            if(Models.Shared.Institucion.PAGO)
            {
                menuList.Add(pago);
            }
            if(Models.Shared.Institucion.DESEMBOLSO)
            {
                menuList.Add(desembolso);
            }
            if(Models.Shared.Institucion.BLOQUEOTD)
            {
				menuList.Add(bloqueoTc);
            }
            menuList.Add(logout);

            navigationDrawerList.ItemsSource = menuList;

            Detail =new NavigationPage((Page)Activator.CreateInstance(typeof(Resumen.Resumen)));


        }

         async void OnMenuItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {


                var menuItem = (Models.MasterPageItem)e.SelectedItem;
                var resumen = new Resumen.Resumen();
               

                if (menuItem.TargetType == null)
                { //Logout

                    logOff();
                }
                else
                {
                    
                    if (menuItem.frgType != "")
                    {
                        var frgPage = (Transferencias.Transferencias)(Page)Activator.CreateInstance(menuItem.TargetType, new object[] { menuItem.frgType });

                        await NavigateTo(frgPage);

                        return;
                    }
                    var page = (Page)Activator.CreateInstance(menuItem.TargetType);
                    await NavigateTo(page);
                }
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IsGestureEnabled = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            IsGestureEnabled = false;
        }

        async Task<bool> NavigateTo(Page page)
        {
            
			navigationDrawerList.SelectedItem = null;
			IsPresented = false;
            //await resumen.refresh();
            await Detail.Navigation.PopToRootAsync();
			await Detail.Navigation.PushAsync(((page)));
			


            //Detail.Navigation.InsertPageBefore(resumen, page);
			
            return true;
        }
        async void logOff(){
			var alert = await DisplayAlert(i18n.getString(""),
											 i18n.getString("L_ALERT_LOGOUT"),
											 i18n.getString("L_ACEPTAR"),
											 i18n.getString("L_CANCELAR"));

			if (alert == true)
			{
				Models.Utils.LogOff();
			}
            else
            {
                navigationDrawerList.SelectedItem = null;
            }
           

			
			
        }
    }
}
