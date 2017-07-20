using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ibanking.Historico
{
    public class HistoricoVm : INotifyPropertyChanged
    {
        Models.ChooseCuentaItem _cuenta;
        Models.ChooseTransaccionItem _transaccion;

		public event PropertyChangedEventHandler PropertyChanged;

        public Models.ChooseCuentaItem Cuenta { 
            get{
                return _cuenta;
            } set{
                _cuenta = value;
                NotifyPropertyChanged("Cuenta");
            } 
        }
        public Models.ChooseTransaccionItem Transaccion { get { return _transaccion; } set { _transaccion = value;  NotifyPropertyChanged("Transaccion");} }


        public bool Mostrar_Detalle { get; set; }
        public bool Solo_Transferencias { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }

        public HistoricoVm()
        {
            this.Cuenta = new Models.ChooseCuentaItem();
            this.Transaccion = new Models.ChooseTransaccionItem();
            this.Mostrar_Detalle = false;
            this.Solo_Transferencias = false;
            this.Fecha_Desde = DateTime.Now;
            this.Fecha_Hasta = DateTime.Now;
        }



        public async Task<Models.HistoricoListAdapter> Buscar()
        {
            string origen = this.Transaccion.Index == 0 ? "" : this.Transaccion.Index.ToString();
            string tipo = this.Cuenta.TIPO;
            Models.HistoricoListAdapter movimientos;
            switch (tipo)
            {
                case "1":
                    movimientos = await HistoricoService.BuscarHistoricoAhorro(
	                                   Models.Shared.User.IDINSTITUCION,
	                                   this.Cuenta.IDCUENTA,
	                                   origen,
	                                   this.Solo_Transferencias,
	                                   this.Fecha_Desde,
	                                   this.Fecha_Hasta);
                    return movimientos;
                case "2":
                    movimientos = await HistoricoService.BuscarHistoricoPrestamo(
	                                 Models.Shared.User.IDINSTITUCION,
	                                 this.Cuenta.IDCUENTA,
	                                 origen,
	                                 this.Fecha_Desde,
	                                 this.Fecha_Hasta);
                    return movimientos;
                case "3":
                    movimientos = await HistoricoService.BuscarHistoricoCertificados(
	                                 Models.Shared.User.IDINSTITUCION,
	                                 this.Cuenta.IDCUENTA,
	                                 origen,
	                                 this.Fecha_Desde,
	                                 this.Fecha_Hasta);
                    return movimientos;
                case "4":
                    movimientos = await HistoricoService.BuscarHistoricoAportaciones(
	                                 Models.Shared.User.IDINSTITUCION,
	                                 this.Cuenta.IDCUENTA,
	                                 origen,
	                                 this.Fecha_Desde,
	                                 this.Fecha_Hasta);
                    return movimientos;
            }

            return null;

        }

		void NotifyPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
