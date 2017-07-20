using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ibanking.Utils
{
    public partial class ChooseTransaccion : ContentPage
    {

        List<Models.ChooseTransaccionItem> _items;
        readonly List<Models.ChooseTransaccionItem> Transacciones;

        public delegate void OnTransaccionSelectedDelegate(Models.ChooseTransaccionItem SelectedItem);
        public event OnTransaccionSelectedDelegate OnTransaccionChoosed;

        public List<Models.ChooseTransaccionItem> Items {
            get {
                return _items;
            }

            set {
                _items = value;
                OnPropertyChanged();
            }
        }

        public ChooseTransaccion()
        {
            InitializeComponent();
			Transacciones = new List<Models.ChooseTransaccionItem>(){
				new Models.ChooseTransaccionItem(){Index = 0, Descripcion = i18n.getString("L_TODAS")},
				new Models.ChooseTransaccionItem(){Index = 1, Descripcion = i18n.getString("L_DEBITOS")},
				new Models.ChooseTransaccionItem(){Index = 2, Descripcion = i18n.getString("L_CREDITOS")}
			};
            this.Items = this.Transacciones;
            this.BindingContext = this;
			ToolbarItems.Add(new ToolbarItem()
			{
				Text = i18n.getString("L_OK"),
				Command = new Command((obj) =>
				{
					Navigation.PopModalAsync();
				})
			});
        }


        void SearchBox_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if(e.NewTextValue != null)
            {
                if(e.NewTextValue != "")
                {
                    var filteredTransacciones = this.Items.Where(x => x.Descripcion.ToLower().Contains(e.NewTextValue.ToLower()));
                    this.Items = filteredTransacciones.ToList();
                }
                else{
                    this.Items = this.Transacciones;
                }
            }
        }

        void Transaccion_Selected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            OnTransaccionChoosed?.Invoke((Models.ChooseTransaccionItem)e.SelectedItem);
            Navigation.PopModalAsync(true);
        }
    }
}
