using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ibanking.BloqueoTarjetas
{
    public class BloqueoTarjetaVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        Models.ChooseTarjetaItem _tarjeta;
        Models.ChooseTipoBloqueoItem _tipo_bloqueo;

        public Models.ChooseTarjetaItem Tarjeta { get { return _tarjeta; } set { _tarjeta = value; NotifyPropertyChanged("Tarjeta"); }}
        public Models.ChooseTipoBloqueoItem Tipo_Bloqueo { get { return _tipo_bloqueo; } set { _tipo_bloqueo = value;  NotifyPropertyChanged("Tipo_Bloqueo");}}
        public string Concepto { get; set; }

        public BloqueoTarjetaVM()
        {
            this.Tarjeta = new Models.ChooseTarjetaItem();
            this.Tipo_Bloqueo = new Models.ChooseTipoBloqueoItem();
            this.Concepto = "";
        }

        public async Task<Models.TransferenciaMsj> Bloquear()
        {
            return await BloqueoTarjetasService.BloquearTdMovil(this.Tarjeta.tarjeta, this.Tipo_Bloqueo.T_TiposDeBloqueo_Codigo, this.Concepto);
        }

        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
