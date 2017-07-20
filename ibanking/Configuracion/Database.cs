using System;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using System.Linq;

namespace ibanking.Configuracion
{
    public class Settings
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ConfigName { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public string TargetType { get; set; }
        public bool IsEnabled { get; set; }
    }


    public class Config
    {
        static SQLiteAsyncConnection _db;

        public static SQLiteAsyncConnection db
        {
            get 
            {
                if(_db == null)
                {
                    _db = new SQLiteAsyncConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath(Services.Config.DBName));
                }
                return _db;
            }
        }

        public Config(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
           
        }

        public static async Task<int> GetAppVersion()
        {
            try
            {
				var versionConfig = await _db.Table<Settings>().Where(x => x.ConfigName == "version").FirstOrDefaultAsync();
				if (versionConfig != null)
				{
					return Convert.ToInt32(versionConfig.Value.Replace(".", "").Replace("v", ""));
				}
				else
				{
                   
					return 0;
				}
            }
            catch
            {
                return 0;
            }
           
           
        }

        public static async Task<bool> UpdateDatabase()
        {
			//Change when we want update database to new version (add fields, add data etc...)
			//await _db.QueryAsync<>();
			await _db.CreateTableAsync<Settings>();
            var settigns = await _db.Table<Settings>().ToListAsync();
            var idioma = settigns.Find(x => x.ConfigName == "idioma");
            var version = settigns.Find(x => x.ConfigName == "version");

            if(idioma == null)
            {
                idioma = new Settings()
                {
                    ConfigName = "idioma",
                    DisplayName = "L_IDIOMA",
                    Value = "es",
                    IsEnabled = true,
                    TargetType = "ibanking.Utils.ChooseLanguage"
                };

               await _db.InsertAsync(idioma);

            }

            if(version == null)
            {
                version = new Settings()
                {
                    ConfigName = "version",
                    DisplayName = "L_VERSION",
                    Value = Services.Config.Version,
                    IsEnabled = false,
                    TargetType = ""

                };

                await _db.InsertAsync(version);
            }

            return true;
        }
    }
}
