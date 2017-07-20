using System;
using System.Collections.Generic;
using ibanking.Configuracion;
using Xamarin.Forms;


namespace ibanking.Utils
{
    public partial class ChooseLanguage : ContentPage, IItemSelectableNavigationPage
    {
        //public delegate void OnItemSelectedDelegate(Models.Langauge selectedItem, Configuracion.ConfigTypes configType);
        public event OnConfigItemSelectedDelegate OnItemSelected;

        List<Models.Langauge> Original_Items { get; set; }
        List<Models.Langauge> _items;

        public List<Models.Langauge> Items {
            get {
                return _items;
            }

            set {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ChooseLanguage()
        {
            InitializeComponent();
        }

        public ChooseLanguage(List<Models.Langauge> items)
        {
			InitializeComponent();
            this.Items = items;
            this.Original_Items = items;
			this.BindingContext = this;
            ToolbarItems.Add(new ToolbarItem()
            {
                Text = i18n.getString("L_OK"),
                Command = new Command((obj) => {
					closeModal();
                })
            });
        }

       

        void Language_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            OnItemSelected?.Invoke((Models.Langauge)e.SelectedItem, Configuracion.ConfigTypes.idioma);
            closeModal();
        }

        async void closeModal()
        {
            await Navigation.PopModalAsync();
        }
    }
}
