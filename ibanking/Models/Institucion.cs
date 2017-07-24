﻿﻿﻿using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using System.IO;

namespace ibanking.Models
{
    public class Institucion
    {
        public string NOMBRE { get; set; }
        public ImageSource LOGO { get; set; }
        public ImageSource BANNER { get; set; }
        public bool TRANSFERENCIA { get; set; }
        public bool PAGO { get; set; }
        public bool DESEMBOLSO { get; set; }
        public bool BLOQUEOTD {get;set;}
        public string MSG { get; set; }

        public Institucion()
        {
            this.NOMBRE = "";
            this.LOGO = null;
            this.BANNER = null;
            this.TRANSFERENCIA = false;
            this.PAGO = false;
            this.DESEMBOLSO = false;
            this.BLOQUEOTD = false;
            this.MSG = "";
        }

        public static Institucion FromJToken(JToken obj){
			var msg = obj.Value<string>("MSG") ?? "";
			if (msg != "")
			{
				return new Institucion()
				{
					MSG = obj["MSG"].Value<string>()
				};
			}
			else
			{
				return new Institucion()
				{
					NOMBRE = obj["NOMBRE"].Value<string>(),
					LOGO = ImageSourceFromBase64(obj["LOGO"].Value<string>()),
					BANNER = ImageSourceFromBase64(obj["BANNER"].Value<string>()),
					TRANSFERENCIA = Boolean.Parse(obj["TRANSFERENCIA"].Value<string>()),
					PAGO = Boolean.Parse(obj["PAGO"].Value<string>()),
					DESEMBOLSO = Boolean.Parse(obj["DESEMBOLSO"].Value<string>()),
					BLOQUEOTD = Boolean.Parse(obj["BLOQUEOTD"].Value<string>())
				};
			}
			//return obj.ToObject<Models.Institucion>();
		}

        static ImageSource ImageSourceFromBase64(string base64){
            return ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(base64)));
        }
    }
}
