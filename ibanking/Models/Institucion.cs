using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.IO;

namespace ibanking.Models
{
    public class Institucion
    {
        public string Nombre { get; set; }
        public ImageSource Logo { get; set; }
        public ImageSource Banner { get; set; }
        public bool Transferencia { get; set; }
        public bool Pago { get; set; }
        public bool Desembolso { get; set; }
        public bool BloqueoTd {get;set;}

        public Institucion()
        {
            this.Nombre = "";
            this.Logo = null;
            this.Banner = null;
            this.Transferencia = false;
            this.Pago = false;
            this.Desembolso = false;
            this.BloqueoTd = false;
        }

        public static Institucion FromJToken(JToken obj){
            return new Institucion()
            {
                Nombre = obj["NOMBRE"].Value<string>(),
                Logo = ImageSourceFromBase64(obj["LOGO"].Value<string>()),
                Banner = ImageSourceFromBase64(obj["BANNER"].Value<string>()),
				
                Transferencia = Boolean.Parse(obj["TRANSFERENCIA"].Value<string>()),
                Pago = Boolean.Parse(obj["PAGO"].Value<string>()),
                Desembolso = Boolean.Parse(obj["DESEMBOLSO"].Value<string>()),
                BloqueoTd = Boolean.Parse(obj["BLOQUEOTD"].Value<string>())
            };
        }

        static ImageSource ImageSourceFromBase64(string base64){
            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64)));
        }
    }
}
