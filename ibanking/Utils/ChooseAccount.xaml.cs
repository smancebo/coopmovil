using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace ibanking.Utils
{
    public partial class ChooseAccount : ContentPage
    {

        public delegate void ChooseItemDelegate(Models.ChooseCuentaItem SelectedItem);
        List<Models.ChooseCuentaItem> _items;
        List<Models.ChooseCuentaItem> Original_Items { get; set; }

        public List<Models.ChooseCuentaItem> Items { 
            get{
                return _items;
            } 
            set{
                _items = value;
                OnPropertyChanged();
            } 
        }

        public event ChooseItemDelegate OnItemSelected;

        public ChooseAccount()
        {
            InitializeComponent();
            this.BindingContext = this;
        }

        public ChooseAccount(List<Models.ChooseCuentaItem> items)
        {
            InitializeComponent();
            this.Items = items;
            this.Original_Items = items;
            this.BindingContext = this;
            //lstCuentas.ItemsSource = this.Items;

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
            if(e.NewTextValue  != null)
            {
                if(e.NewTextValue == ""){
                    this.Items = Original_Items;
                    return;
                }
                string criteria = e.NewTextValue.ToLower();
				var filterItems = this.Original_Items.Where(x =>
                                                            x.TITULAR.ToLower().Contains(criteria) ||
                                                            x.DESCRIPCION.ToLower().Contains(criteria) ||
                                                            x.IDCUENTA.ToLower().Contains(criteria));
                this.Items = filterItems.ToList();
            }
           
        }

        void lstCuentas_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            
            OnItemSelected?.Invoke((Models.ChooseCuentaItem)e.SelectedItem);
            Navigation.PopModalAsync(true);
        }
    }
}
