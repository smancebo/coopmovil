using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace ibanking.Utils
{
    public partial class ChooseTarjeta : ContentPage
    {
        List<Models.ChooseTarjetaItem> _items;
        List<Models.ChooseTarjetaItem> Original_Items { get; set; }
        public List<Models.ChooseTarjetaItem> Items { get { return _items; } set { _items = value;  OnPropertyChanged();} }
        public delegate void OnItemSelectedDelegate(Models.ChooseTarjetaItem item);
        public event OnItemSelectedDelegate OnItemSelected;
        public ChooseTarjeta()
        {
            InitializeComponent();
           
        }

		public ChooseTarjeta(List<Models.ChooseTarjetaItem> items)
		{
			InitializeComponent();
            this.Original_Items = items;
            this.Items = items;
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

		void OnSearchBar_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
			if (e.NewTextValue != null)
			{
				if (e.NewTextValue == "")
				{
					this.Items = Original_Items;
					return;
				}
				string criteria = e.NewTextValue.ToLower();
				var filterItems = this.Original_Items.Where(x =>
															x.tarjeta.ToLower().Contains(criteria) ||
                                                            x.T_Tarjeta_Nombre_Titular.ToLower().Contains(criteria));
				this.Items = filterItems.ToList();
			}

		}


        void lstCuenta_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            OnItemSelected?.Invoke((Models.ChooseTarjetaItem)e.SelectedItem);
            Navigation.PopModalAsync(true);
        }
    }
}
