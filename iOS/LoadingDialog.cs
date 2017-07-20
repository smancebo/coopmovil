using System;
using BigTed;
using ibanking.iOS;

[assembly: Xamarin.Forms.Dependency(typeof(LoadingDialog))]
namespace ibanking.iOS
{
    public class LoadingDialog : ILoadingDIalog
    {
        public LoadingDialog()
        {
        }

        public void Show(){
            BTProgressHUD.Show("Loading....");
        }

        public void Hide(){
            BTProgressHUD.Dismiss();
        }
    }
}
