using System;
using Newtonsoft.Json.Linq;
using ibanking.Services;
using System.Threading.Tasks;

namespace ibanking.Login
{
    public static class LoginService
    {
        public static async Task<bool> DoLogin(string username, string password){

            try
            {
                var methodParam = new ApiParams();
                methodParam.Add("idUsuario", username);
                methodParam.Add("clave", password);

                var userJson = await APICaller.Call("ValidarAccesoMovil", methodParam);

                var user = Models.User.FromJsonToken(userJson);
                if (user == null) return false;
                Models.Shared.User = user;
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
