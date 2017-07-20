using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ibanking.Transferencias
{
    public class TransferenciaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        Models.ChooseCuentaItem _cuenta_origen;
        Models.ChooseCuentaItem _cuenta_destino;

        public Models.ChooseCuentaItem Cuenta_Origen
        {
            get
            {
                return _cuenta_origen;
            }
            set
            {
                _cuenta_origen = value;
                NotifyPropertyChanged("Cuenta_Origen");
            }
        }
        public Models.ChooseCuentaItem Cuenta_Destino
        {
            get
            {
                return _cuenta_destino;
            }

            set
            {
                _cuenta_destino = value;
                NotifyPropertyChanged("Cuenta_Destino");
            }
        }
        public decimal Monto { get; set; }
        public string Concepto { get; set; }



        public TransferenciaVM()
        {
            this.Cuenta_Origen = new Models.ChooseCuentaItem();
            this.Cuenta_Destino = new Models.ChooseCuentaItem();
            this.Monto = 0;
            this.Concepto = "";
        }

        public async Task<Models.TransferenciaMsj> DoTransferencia(string frg_type)
        {
            string tipo = "";


            if (this.Cuenta_Destino.NOMBRE_PUBLICO[0] == '4')
            {
                tipo = "4";
            }
            else
            {
                tipo = this.Cuenta_Destino.TIPO;
            }


            switch (frg_type)
            {
                case "tx":
                    return await TransferenciasService.TransferenciaAhorrosMovil(Models.Shared.User.IDINSTITUCION,
                                                                                         Models.Shared.User.IDCLIENTE,
                                                                                         this.Cuenta_Origen.IDCUENTA,
                                                                                          this.Monto,
                                                                                          this.Cuenta_Destino.IDCUENTA,
                                                                                          this.Concepto,
                                                                                          tipo
                                                                                         );


                case "pg":
                    return await TransferenciasService.TransferenciaPrestamosMovil(Models.Shared.User.IDINSTITUCION,
                                                                                           this.Cuenta_Origen.IDCUENTA,
                                                                                           this.Monto,
                                                                                            this.Cuenta_Destino.IDCUENTA);
                case "dl":
                    return await TransferenciasService.DesembolsoLineaMovil(Models.Shared.User.IDINSTITUCION,
                                                                           this.Cuenta_Origen.IDCUENTA,
                                                                           this.Monto,
                                                                            this.Cuenta_Destino.IDCUENTA);


                default:
                    return new Models.TransferenciaMsj();
            }


        }
        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
