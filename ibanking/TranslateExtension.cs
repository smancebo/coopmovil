using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace ibanking
{
    [Preserve(AllMembers = true)]
    [Xamarin.Forms.ContentProperty("Text")]
    public class TranslateExtension : Xamarin.Forms.Xaml.IMarkupExtension
    {

        public string Text { get; set; }


        public TranslateExtension()
        {
           
        }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null) return "";
            return i18n.getString(Text);
        }
    }

    public static class i18n
    {
        
        public static string getString(string key){
            string idioma = Models.Utils.SelectedLanguage ?? "es";

			CultureInfo ci = new CultureInfo(idioma); //GetCurrent Culture Info
			using (var reader = new StreamReader(i18n.getLangFile(ci.TwoLetterISOLanguageName)))
			{

				JObject lang = JObject.Parse(reader.ReadToEnd());

				var translation = lang[key]?.Value<string>();

				if (translation == null)
				{
					translation = key;
				}

				return translation;
			}

        }

        static Stream getLangFile(string lang){
            var langFile = $"ibanking.lang.{lang}.lang.json";
			var assembly = typeof(CoopInfo).GetTypeInfo().Assembly;
			return assembly.GetManifestResourceStream(langFile);
        }

        public static async Task<List<Models.Langauge>> GetLanguages()
        {
            var assembly = typeof(CoopInfo).GetTypeInfo().Assembly;
            using(var stream = new StreamReader(assembly.GetManifestResourceStream("ibanking.lang.languages.json")))
            {
                var langArray = JArray.Parse(await stream.ReadToEndAsync());
                return langArray.ToObject<List<Models.Langauge>>();
            }
        }
    }
}
