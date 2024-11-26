using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM.Tablas
{
    public class Tramite
    {
        internal ManejoDatos b { get; set; } = new ManejoDatos();

        /// <summary>
        /// Crea un trámite nuevo
        /// </summary>
        /// <param name="tramiteN1"></param>
        /// <returns></returns>
        public List<Propiedades.RespuestaNuevoTramiteN1> Agregar(Propiedades.TramiteN1 tramiteN1)
        {
            b.ExecuteCommandSP("MDM.dbo.spTramiteNuevo");
            b.AddParameter("@idtipoarchivo", tramiteN1.IdTipoArchivo, SqlDbType.Int);               //2
            b.AddParameter("@nombrearchivo", tramiteN1.NombreArchivo, SqlDbType.VarChar, 100);
            b.AddParameter("@IdTipoTramite", tramiteN1.IdTipoTramite, SqlDbType.Int);               //4
            b.AddParameter("@IdStatus", tramiteN1.IdStatus, SqlDbType.Int);                         //
            b.AddParameter("@IdPromotoria", tramiteN1.IdPromotoria, SqlDbType.Int);
            b.AddParameter("@IdUsuario", tramiteN1.IdUsuario, SqlDbType.Int);
            b.AddParameter("@idPrioridad", tramiteN1.idPrioridad, SqlDbType.Int);                   //5
            b.AddParameter("@Poliza", tramiteN1.Poliza, SqlDbType.NVarChar, 50);
            b.AddParameter("@TipoNomina", tramiteN1.TipoNomina, SqlDbType.NVarChar, 2);
            b.AddParameter("@TipoMovimiento", tramiteN1.TipoMovimiento, SqlDbType.NVarChar, 2);     //
            b.AddParameter("@UnidadPago", tramiteN1.UnidadPago, SqlDbType.NVarChar, 50);
            b.AddParameter("@Quincena", tramiteN1.Quincena, SqlDbType.NVarChar, 6);
            b.AddParameter("@Importe", "0", SqlDbType.NVarChar, 15);
            b.AddParameter("@No", tramiteN1.No, SqlDbType.NVarChar, 15);
            b.AddParameter("@Guid", tramiteN1.Guid, SqlDbType.NVarChar, 50);

            List<Propiedades.RespuestaNuevoTramiteN1> resultado = new List<Propiedades.RespuestaNuevoTramiteN1>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.RespuestaNuevoTramiteN1 item = new Propiedades.RespuestaNuevoTramiteN1()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString())
                    ,Folio = reader["Folio"].ToString()
                    ,DescError = reader["DescError"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
