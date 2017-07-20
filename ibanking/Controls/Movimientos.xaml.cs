using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Linq;

namespace ibanking.Controls
{
    [Preserve(AllMembers = true)]
    public partial class Movimientos : StackLayout
    {
        public string Tipo { get; set; }

        public bool Group { get; set; }
        //public bool MostrarConcepto { get; set; }
        public static readonly BindableProperty ListMovimientosProperty =
            BindableProperty.Create("ListMovimientos",
                                    typeof(List<Models.Movimiento>),
                                    typeof(Movimientos),
                                    null,
                                    propertyChanged: OnMovimientosListChanged);

		public static readonly BindableProperty MostrarConceptoProperty =
		   BindableProperty.Create("MostrarConcepto",
                                   typeof(bool),
                                   typeof(Movimientos),
                                   false);

		public bool MostrarConcepto
		{
			get { return (bool)GetValue(MostrarConceptoProperty); }
			set
			{
                var val = value;
				SetValue(MostrarConceptoProperty, val);
			}
		}

        public List<Models.Movimiento> ListMovimientos {
            get { return (List<Models.Movimiento>)GetValue(ListMovimientosProperty); }
            set {
                var val = value ?? new List<Models.Movimiento>();
                System.Diagnostics.Debug.WriteLine(val);
                SetValue(ListMovimientosProperty, val); 
            }
        }
        public Movimientos()
        {
            InitializeComponent();
            this.Tipo = "dp";
            this.MostrarConcepto = false;
        }
                                    

        public Movimientos(List<Models.Movimiento> movimientos){
            InitializeComponent();

            foreach(var movimiento in movimientos){
                lstMovimentos.Children.Add(new Movimiento(movimiento, this.Tipo, this.MostrarConcepto));
            }
        }

        static void OnMovimientosListChanged(BindableObject bindable, object oldValue, object newValue){
            var objMovimientos = (Movimientos)bindable;
            objMovimientos.lstMovimentos.Children.Clear();
            DateTime movDate = DateTime.Now;

           
                
            foreach (var movimiento in (((List<Models.Movimiento>)newValue).OrderByDescending(x=>x.SECUENCIA)))
			{
				if (objMovimientos.Group)
                {
                    if (movDate != movimiento.FECHA)
                    {
                        objMovimientos.lstMovimentos.Children.Add(new Controls.Resumen.separator(movimiento.FECHA.ToString("dd MMM yyyy")));
                        movDate = movimiento.FECHA;
                    }
                }
				objMovimientos.lstMovimentos.Children.Add(new Movimiento(movimiento, objMovimientos.Tipo, objMovimientos.MostrarConcepto));
			}
        }


                                    
    }
}
