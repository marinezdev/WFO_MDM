using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.UNAM.Tablas
{
    public class Extraccion
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(int IdUsuario, params string[] prms)
        {
            b.ExecuteCommandSP("UNAM.dbo.Movimientos_Extraccion_Add");
            b.AddParameter("@idusuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@no", prms[0], SqlDbType.NVarChar);
            b.AddParameter("@poliza", prms[1], SqlDbType.NVarChar);
            b.AddParameter("@guid", prms[2], SqlDbType.NVarChar);
            return b.InsertUpdateDelete();
        }
    }
}
