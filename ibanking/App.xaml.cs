using System.Linq;
using Xamarin.Forms;
using ibanking.Configuracion;
namespace ibanking
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Splash();
        }

       

       

        protected override async void OnStart()
        {

            // Handle when your app startsvar 
            var config = new Config(DependencyService.Get<IFileHelper>().GetLocalFilePath(Services.Config.DBName));
            if (await Config.GetAppVersion() < Services.Config.GetCurrentAppVersion())
            {
                await Config.UpdateDatabase();
            }

            var idioma = await Config.db.FindAsync<Settings>(x=>x.ConfigName == "idioma");
            Models.Utils.SelectedLanguage = idioma.Value;


        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
            Models.Utils.pausedAt = System.DateTime.Now.AddMinutes(2);


        }

        protected override void OnResume()
        {
            var pausedAt = Models.Utils.pausedAt;
            if(Models.Shared.User != null)
            {
                if((System.DateTime.Now.Ticks >= pausedAt.Ticks))
                {
                    Models.Utils.LogOff();
                }
            }
            // Handle when your app resumes
        }
    }
}
