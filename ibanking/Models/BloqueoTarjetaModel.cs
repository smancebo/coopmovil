using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.ComponentModel;

namespace ibanking.Models
{
    public class BloqueoTarjetaModel : INotifyPropertyChanged
    {
        List<ChooseTarjetaItem> _tarjetas;
        List<ChooseTipoBloqueoItem> _tipos_bloqueos;

        public List<Models.ChooseTarjetaItem> Tarjetas { get { return _tarjetas; } set { _tarjetas = value; NotifyPropertyChanged("Tarjetas"); } }
        public List<Models.ChooseTipoBloqueoItem> TiposBloqueos { get { return _tipos_bloqueos; } set { _tipos_bloqueos = value; NotifyPropertyChanged("TiposBloqueos"); } }
        public event PropertyChangedEventHandler PropertyChanged;

        public BloqueoTarjetaModel()
        {
            this.Tarjetas = new List<ChooseTarjetaItem>();
            this.TiposBloqueos = new List<ChooseTipoBloqueoItem>();
        }


        void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public static BloqueoTarjetaModel FromJsonArray(JArray array)
        {
            try
            {
                return new BloqueoTarjetaModel()
                {
                    Tarjetas = ChooseTarjetaItem.FromJsonArray((JArray)array.ElementAt(0)),
                    TiposBloqueos = ChooseTipoBloqueoItem.FromJsonArray((JArray)array.ElementAt(1))
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
