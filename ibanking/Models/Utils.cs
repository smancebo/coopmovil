using System;
using System.Linq;
using Xamarin.Forms;

namespace ibanking.Models
{
   
    public static class Utils
    {
        public static DateTime pausedAt { get; set; }
        public static string SelectedLanguage { get; set; }

		public static void ClearNavigationStack(Xamarin.Forms.INavigation navigation)
		{
			var existingPages = navigation.NavigationStack.ToList();
			for (int i = 0; i < existingPages.Count - 1; i++)
			{
				navigation.RemovePage(existingPages[i]);
			}
		}

        public static void LogOff()
        {
			var login = new Login.Login();
			var coopInfo = (new CoopInfo());

			Application.Current.MainPage = new NavigationPage(login);
			Application.Current.MainPage.Navigation.InsertPageBefore(coopInfo, login);
			Models.Shared.User = null;
        }


    }
}
