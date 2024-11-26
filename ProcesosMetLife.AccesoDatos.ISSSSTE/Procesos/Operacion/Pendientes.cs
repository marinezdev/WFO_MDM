using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = ProcesosMetLife.Propiedades.Procesos.Operacion;

namespace ProcesosMetLife.AccesoDatos.ISSSTE.Procesos.Operacion
{
    public class Pendientes
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Pendientes> Selecionar_Pendientes_PorId(int IdPendiente, int IdUsuario)
        {
            b.ExecuteCommandSP("Pendientes_Selecionar_PorIdpendiente");
            b.AddParameter("@IdPendiente", IdPendiente, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            List<prop.Pendientes> resultado = new List<prop.Pendientes>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Pendientes item = new prop.Pendientes()
                {
                    IdTramite           = Funciones.Nums.TextoAEntero(reader["IdTramite"].ToString()),
                    IdMesa              = Funciones.Nums.TextoAEntero(reader["IdMesa"].ToString()),
                    IdStatusMesa        = Funciones.Nums.TextoAEntero(reader["IdStatusMesa"].ToString()),
                    IdStatusTramite     = Funciones.Nums.TextoAEntero(reader["IdStatusTramite"].ToString()),
                    FolioCompuesto      = reader["FolioCompuesto"].ToString(),
                    Operacion           = reader["Operacion"].ToString(),
                    
                    //Contratante = reader["Contratante"].ToString(),
                    //RFC = reader["RFC"].ToString(),
                    //Titular = reader["Titular"].ToString(),

                    Poliza              = reader["Poliza"].ToString(),
                    TipoNomina          = reader["TipoNomina"].ToString(),
                    TipoMovimiento      = reader["TipoMovimiento"].ToString(),
                    UnidadPago          = reader["UnidadPago"].ToString(),
                    Quincena            = reader["Quincena"].ToString(),
                    Importe             = reader["Importe"].ToString(),

                    NombreMesa          = reader["NombreMesa"].ToString(),
                    EstatusMesa         = reader["EstatusMesa"].ToString(),
                    EstatusTramite      = reader["EstatusTramite"].ToString(),
                    FechaRegistro       = reader["FechaRegistro"].ToString(),
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
