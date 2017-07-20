using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace ibanking.Utils
{
    public partial class ChooseTipoBloqueo : ContentPage
    {

        List<Models.ChooseTipoBloqueoItem> _items;
        public delegate void OnTipoBloqueoSelectedDelegate(Models.ChooseTipoBloqueoItem item);
        public event OnTipoBloqueoSelectedDelegate OnItemSelected;

        List<Models.ChooseTipoBloqueoItem> Original_Items { get; set; }
		public List<Models.ChooseTipoBloqueoItem> Items {
            get {
                return _items;
            }
            set {
                _items = value;
                OnPropertyChanged();
            }
        }
        public ChooseTipoBloqueo()
        {
            InitializeComponent();
        }
        public ChooseTipoBloqueo(List<Models.ChooseTipoBloqueoItem> items)
        {
            InitializeComponent();
            this.Items = items;
            this.Original_Items = items;
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
			if (e.NewTextValue != null)
			{
				if (e.NewTextValue == "")
				{
					this.Items = Original_Items;
					return;
				}
				string criteria = e.NewTextValue.ToLower();
                var filterItems = this.Original_Items.Where(x =>
                                                            x.T_TiposDeBloqueo_Descripcion.ToLower().Contains(criteria));
				this.Items = filterItems.ToList();
			}

		}

        void TipoBloqueo_Selected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            OnItemSelected?.Invoke((Models.ChooseTipoBloqueoItem)e.SelectedItem);
            Navigation.PopModalAsync(true);
        }
    }
}
