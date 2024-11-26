using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM.Tablas
{
    public class Tramite_Mesa
    {
        ManejoDatos b = new ManejoDatos();

        public DataRow AsignarTramite(int IdMesa, int IdUsuario, int IdTramite)
        {
            b.ExecuteCommandSP("MDM.dbo.spWFOTramiteAsignar");
            b.AddParameter("@IdMesa", IdMesa, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@IdTramite", IdTramite, SqlDbType.Int);
            return b.SelectDataRow();
        }

        public DataRow ProcesarTramite(string idtramite, string idmesa, string idusuario, string idstatusmesa, string obspub, string obspri, string motivosrechazo)
        {
            b.ExecuteCommandSP("MDM.dbo.spWFOTramiteProcesar");
            b.AddParameter("@IdTramite", idtramite, SqlDbType.Int);
            b.AddParameter("@IdMesa", idmesa, SqlDbType.Int);
            b.AddParameter("@IdUsuario", idusuario, SqlDbType.Int);
            b.AddParameter("@IdStatusMesa", idstatusmesa, SqlDbType.Int);
            b.AddParameter("@ObservacionPub", obspub, SqlDbType.NVarChar);
            b.AddParameter("@ObservacionPriv", obspri, SqlDbType.NVarChar);
            b.AddParameter("@MotivosRechazo", motivosrechazo, SqlDbType.NVarChar);
            return b.SelectDataRow();
        }
    }
}
