using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace ibanking.Historico
{
    public static class HistoricoService
    {
        public static async Task<Models.HistoricoListAdapter> BuscarHistoricoAhorro(
            int idinst,
            string idcuenta,
            string origen,
            bool soloTransferencias,
            DateTime fechaDesde,
            DateTime fechaHasta
        )
        {
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idcuenta", idcuenta);
            webMethodParams.Add("Origen", origen);
            webMethodParams.Add("bSoloTransferencia", soloTransferencias);
            webMethodParams.Add("strFechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
            webMethodParams.Add("strFechaHasta", fechaHasta.ToString("yyyy-MM-dd"));

            var consulta = (JArray)(await Services.APICaller.Call("BuscarAhorrosTransMovil", webMethodParams));


            //Models.Movimiento.FromJsonArray((JArray)consulta.ElementAt(1));
            return new Models.HistoricoListAdapter()
            {
                Balance = consulta.ElementAt(0).FirstOrDefault()["BALANCE_ANTERIOR"].Value<decimal>(),
                Movimientos = Models.Movimiento.FromJsonArray((JArray)consulta.ElementAt(1))
            };
        }

        public static async Task<Models.HistoricoListAdapter> BuscarHistoricoPrestamo(
            int idinst,
            string idprestamo,
            string origen,
            DateTime fechaDesde,
            DateTime fechaHasta
        )
        {
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idprestamo", idprestamo);
            webMethodParams.Add("Origen", origen);
            webMethodParams.Add("strFechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
            webMethodParams.Add("strFechaHasta", fechaHasta.ToString("yyyy-MM-dd"));

            var consulta = (JArray)(await Services.APICaller.Call("BuscarPrestamosTransMovil", webMethodParams));

			return new Models.HistoricoListAdapter()
			{
				Balance = consulta.ElementAt(0).FirstOrDefault()["BALANCE_ANTERIOR"].Value<decimal>(),
				Movimientos = Models.Movimiento.FromJsonArray((JArray)consulta.ElementAt(1))
			};
        }

        public static async Task<Models.HistoricoListAdapter> BuscarHistoricoCertificados(
           int idinst,
           string idcertificado,
           string origen,
           DateTime fechaDesde,
           DateTime fechaHasta
       )
        {
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idcertificado", idcertificado);
            webMethodParams.Add("Origen", origen);
            webMethodParams.Add("strFechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
            webMethodParams.Add("strFechaHasta", fechaHasta.ToString("yyyy-MM-dd"));

            var consulta = (JArray)(await Services.APICaller.Call("BuscarCertificadosTransMovil", webMethodParams));

			return new Models.HistoricoListAdapter()
			{
				Balance = consulta.ElementAt(0).FirstOrDefault()["BALANCE_ANTERIOR"].Value<decimal>(),
				Movimientos = Models.Movimiento.FromJsonArray((JArray)consulta.ElementAt(1))
			};
        }

        public static async Task<Models.HistoricoListAdapter> BuscarHistoricoAportaciones(
           int idinst,
           string idaportacion,
           string origen,
           DateTime fechaDesde,
           DateTime fechaHasta
       )
        {
            var webMethodParams = new Services.ApiParams();
            webMethodParams.Add("idinst", idinst);
            webMethodParams.Add("idaportacion", idaportacion);
            webMethodParams.Add("Origen", origen);
            webMethodParams.Add("strFechaDesde", fechaDesde.ToString("yyyy-MM-dd"));
            webMethodParams.Add("strFechaHasta", fechaHasta.ToString("yyyy-MM-dd"));

            var consulta = (JArray)(await Services.APICaller.Call("BuscarAccionesTransMovil", webMethodParams));

			return new Models.HistoricoListAdapter()
			{
				Balance = consulta.ElementAt(0).FirstOrDefault()["BALANCE_ANTERIOR"].Value<decimal>(),
				Movimientos = Models.Movimiento.FromJsonArray((JArray)consulta.ElementAt(1))
			};
        }

    }
}
