using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ibanking.Utils;
using Xamarin.Forms;

namespace ibanking.Configuracion
{
	public enum ConfigTypes
	{
		idioma
	}

    public delegate void OnConfigItemSelectedDelegate(object SelectedItem, ConfigTypes configType);
    public partial class Configuracion : ContentPage
    {
        
        ILoadingDIalog dialog;
        public Configuracion()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            dialog = DependencyService.Get<ILoadingDIalog>();
            dialog.Show();
            var config = await Config.db.Table<Settings>().ToListAsync();
            foreach(var item in config)
            {
                item.DisplayName = i18n.getString(item.DisplayName);

            }
            lstConfig.ItemsSource = config;
            dialog.Hide();

        }

        void Config_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var setting = (Settings)e.SelectedItem;
            NavigateTo(setting);
        }

        async void NavigateTo(Settings setting)
        {

            var page = await GetTargetTypePage(setting);
            await Navigation.PushModalAsync(page);
           
        }

        async Task<NavigationPage> GetTargetTypePage(Settings setting)
        {
            var type = Type.GetType(setting.TargetType);
            IItemSelectableNavigationPage INavPage;
            Page navPage;
			switch (setting.ConfigName)
			{
				case "idioma":
	                    dialog.Show();
	                    var langauges = await i18n.GetLanguages();
	                    dialog.Hide();
	                    navPage = ((Page)Activator.CreateInstance(type, new object[] { langauges }));
                    break;

                    default:
                        navPage = new Page();
                    break;
			}

            INavPage = (IItemSelectableNavigationPage)navPage;
            INavPage.OnItemSelected += (SelectedItem, configType) => {
                switch(configType)
                {
                    case ConfigTypes.idioma:
                        ChangeLanguage((Models.Langauge)SelectedItem);
                        break;
                }
            };

            return new NavigationPage((Page)navPage);
        }

        async void ChangeLanguage(Models.Langauge configLang)
        {
            Models.Utils.SelectedLanguage = configLang.id;
            var configIdioma = await Config.db.FindAsync<Settings>(x => x.ConfigName == "idioma");
            configIdioma.Value = configLang.id;
            await Config.db.UpdateAsync(configIdioma);
            var coopInfo = (new CoopInfo());

           
            await Navigation.PushAsync(coopInfo);
			Models.Utils.ClearNavigationStack(this.Navigation);
            //await Task.Run(async () => {
            //    await Task.Delay(300);
            //    Device.BeginInvokeOnMainThread( () => {
            //        Application.Current.MainPage = coopInfo;
            //    });

            //});

        }
    }
}
