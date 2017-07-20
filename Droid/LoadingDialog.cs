using System;
using Android.App;
using ibanking.Droid;
using Xamarin.Android;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(LoadingDialog))]
namespace ibanking.Droid
{
    public class LoadingDialog : ILoadingDIalog
    {
        Dialog _dialog;

        public LoadingDialog(){
            _dialog = new Dialog(Forms.Context);
        }
        public void Show(){
            _dialog.SetContentView(Resource.Layout.loading);
            _dialog.SetCancelable(false);
            _dialog.Show();
        }

        public void Hide(){
            _dialog.Hide();
        }
    }
}
