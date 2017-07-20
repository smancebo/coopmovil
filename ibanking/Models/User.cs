using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace ibanking.Models
{
    public class User
    {

        public string IDCLIENTE { get; set; }
        public int IDINSTITUCION { get; set; }
        public string DOC_IDENTIFICACION { get; set; }
        public string NOMBRE { get; set; }
        public string EMAIL { get; set; }



        public User()
        {
            this.IDCLIENTE = "";
            this.IDINSTITUCION = 0;
            this.DOC_IDENTIFICACION = "";
            this.NOMBRE = "";
            this.EMAIL = "";
        }

        public static User FromJsonToken(JToken t){

            var token = t.Children().FirstOrDefault();

            try
            {
				return new User()
				{

					IDCLIENTE = token["IDCLIENTE"].Value<string>(),
					IDINSTITUCION = token["IDINSTITUCION"].Value<int>(),
					DOC_IDENTIFICACION = token["DOC_IDENTIFICACION"].Value<string>(),
					NOMBRE = token["NOMBRE"].Value<string>(),
					EMAIL = token["EMAIL"].Value<string>()

				};
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
