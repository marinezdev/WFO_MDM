using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM.Tablas
{
    public class Tramite_Det_MDM
    {
        internal ManejoDatos b { get; set; } = new ManejoDatos();

        public List<Propiedades.Tramite_Det_MDM> Buscar(string poliza)
        {
            //b.ExecuteCommandQuery("SELECT * FROM MDM.dbo.Tramite_det_MDM WHERE poliza like @poliza");
            //string consulta = "SELECT a.Id, a.IdTramite, a.Poliza, c.Nombre As EstadoNombre " +
            //"FROM MDM.dbo.tramite_det_mdm a " +
            //"INNER JOIN MDM.dbo.tramite_mesa b ON a.IdTramite = b.IdTramite " +
            //"INNER JOIN MDM.dbo.statusmesa c ON b.IdStatusMesa=c.Id " +
            //"WHERE a.poliza like @poliza";
            string consulta = "SELECT " +
            "MDM.dbo.Tramite_Det_MDM.Id AS Id " +
            ",MDM.dbo.Tramite_Det_MDM.Poliza " +
            ",ISNULL((SELECT MDM.dbo.statusMesa.Nombre FROM MDM.dbo.Tramite_Mesa INNER JOIN MDM.dbo.statusMesa ON MDM.dbo.statusMesa.id = MDM.dbo.Tramite_Mesa.IdStatusMesa WHERE IdTramite = MDM.dbo.Tramite_Det_MDM.Id and IdMesa = 103), '<< no asignado >>') AS Captura1 " +
            ",ISNULL((SELECT MDM.dbo.statusMesa.Nombre FROM MDM.dbo.Tramite_Mesa INNER JOIN MDM.dbo.statusMesa ON MDM.dbo.statusMesa.id = MDM.dbo.Tramite_Mesa.IdStatusMesa WHERE IdTramite = MDM.dbo.Tramite_Det_MDM.Id and IdMesa = 104), '<< no asignado >>') AS Captura2 " +
            "FROM MDM.dbo.Tramite_Det_MDM " +
            "WHERE MDM.dbo.Tramite_Det_MDM.poliza like @poliza";
            b.ExecuteCommandQuery(consulta);
            b.AddParameter("@poliza", "%" + poliza + "%", System.Data.SqlDbType.NVarChar, 50);
            List<Propiedades.Tramite_Det_MDM> resultado = new List<Propiedades.Tramite_Det_MDM>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Tramite_Det_MDM item = new Propiedades.Tramite_Det_MDM()
                {
                    Id                 = Funciones.Nums.TextoAEntero(reader["Id"].ToString())
                    ,IdTramite         = Funciones.Nums.TextoAEntero(reader["Id"].ToString())
                    //,IdArchivo       = Funciones.Nums.TextoAEntero(reader["IdArchivo"].ToString())
                    ,Poliza            = reader["Poliza"].ToString()
                    //,TipoNomina      = reader["TipoNomina"].ToString()
                    //,TipoMovimiento  = reader["TipoMovimiento"].ToString()
                    //,UnidadPago      = reader["UnidadPago"].ToString()
                    //,Quincena        = reader["Quincena"].ToString()
                    //,Importe         = reader["Importe"].ToString()
                    ,Captura1           = reader["Captura1"].ToString()
                    ,Captura2           = reader["Captura2"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public Propiedades.Tramite_Det_MDM SeleccionarPorId(int IdTramite)
        {
            b.ExecuteCommandQuery("SELECT * FROM MDM.dbo.Tramite_det_MDM WHERE idtramite=@idtramite");
            b.AddParameter("@idtramite", IdTramite, System.Data.SqlDbType.Int);
            Propiedades.Tramite_Det_MDM resultado = new Propiedades.Tramite_Det_MDM();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id        = Funciones.Nums.TextoAEntero(reader["Id"].ToString());
                resultado.IdTramite = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString());
                resultado.Poliza    = reader["Poliza"].ToString();
                resultado.No        = reader["No"].ToString();
                resultado.Guid      = reader["Guid"].ToString();
            }
            reader = null;
            b.CloseConnection();
            return resultado;
        }
    }
}
