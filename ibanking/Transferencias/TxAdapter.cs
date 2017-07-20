using System;
using System.Collections.Generic;

namespace ibanking.Transferencias
{
    public static class TxAdapter
    {

		public static List<Models.ChooseCuentaItem> GetCuentasOrigen(List<Models.ChooseCuentaItem> items, string frg_type)
		{
			var retItems = new List<Models.ChooseCuentaItem>();

			for (int i = 0; i <= items.Count - 1; i++)
			{
				var current = items[i];
				current.POSITION = i.ToString();

                if (frg_type == "tx" || frg_type == "pg")
                {
                    if(current.TIPO == "4")
                    {
                        retItems.Add(current);
                    }
                }
                else if (frg_type == "dl")
                {
                    if(current.TIPO == "6")
                    {
                        retItems.Add(current);
                    }
                }
			}

			return retItems;
		}

        public static List<Models.ChooseCuentaItem> GetCuentasDestino(List<Models.ChooseCuentaItem> items, string frg_type)
        {
            var retItems = new List<Models.ChooseCuentaItem>();

            for (int i = 0; i <= items.Count -1; i++)
            {
                var current = items[i];
                current.POSITION = i.ToString();

                if (frg_type == "tx"){
                    if(current.TIPO == "1" || current.TIPO == "2"){
                        retItems.Add(current);
                    }
                } else if (frg_type == "pg"){
                    if(current.TIPO == "5"){
                        retItems.Add(current);
                    }
                }
                else if (frg_type == "dl")
                {
                    if(current.TIPO == "1" && current.NOMBRE_PUBLICO.Substring(0,1) != "4"){
                        retItems.Add(current);
                    }
                }
            }

            return retItems;
        }
    }
}
