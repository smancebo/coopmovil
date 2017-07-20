using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ibanking.OtherInfo
{
    public partial class OtherInfo : ContentPage
    {
        string _source;
        ILoadingDIalog dialog;

        public string Source {
            get 
            {
                return _source;
            }

            set 
            {
                _source = value;
                OnPropertyChanged();
            }
        }

        public OtherInfo()
        {
            InitializeComponent();
            Title = i18n.getString("L_OTRAS_INFORMACIONES");
            webView.Source = Services.Config.OtherInfo.ToString();
            this.BindingContext = this;
            dialog = DependencyService.Get<ILoadingDIalog>();
			webView.Navigating += (sender, e) =>
			{
				dialog.Show();
			};

			webView.Navigated += (sender, e) =>
			{
				dialog.Hide();
			};

		}
    }
}
