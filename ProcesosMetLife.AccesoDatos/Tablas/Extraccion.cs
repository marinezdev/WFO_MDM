using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.Tablas
{
    public class Extraccion
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("Movimientos_Extraccion_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 0, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }

        public int AgregarConcentrado(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            //string consulta = "INSERT INTO archivoexcelextraccion VALUES(@matricula, @importe, @poliza, @promotoriaorigen, @usuarioservicio, @promotoriaultimoservicio, " +
            //"@promotoriaresponsable, @tipomovimiento, @nombretrabajador, @unidadpago, @tiponomina, @annquincena)";
            //b.ExecuteCommandQuery(consulta);

            b.ExecuteCommandSP("Movimientos_Extraccion_Add");
            b.AddParameter("@idUsuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@Folio", Folio, SqlDbType.NChar, 12);
            b.AddParameter("@matricula", prms[0], SqlDbType.NChar, 15);
            b.AddParameter("@importe", Funciones.Texto.ProcesarImporte(prms[1]), SqlDbType.NChar, 10);
            b.AddParameter("@poliza", prms[2], SqlDbType.NChar, 10);
            b.AddParameter("@promotoriaorigen", prms[3], SqlDbType.NChar, 10);
            b.AddParameter("@usuarioservicio", prms[4], SqlDbType.NChar, 8);
            b.AddParameter("@promotoriaultimoservicio", prms[5], SqlDbType.NChar, 2);
            b.AddParameter("@promotoriaresponsable", prms[6], SqlDbType.NChar, 2);
            b.AddParameter("@tipomovimiento", prms[7], SqlDbType.NChar, 1);
            b.AddParameter("@nombretrabajador", prms[8], SqlDbType.NChar, 70);
            b.AddParameter("@unidadpago", prms[9], SqlDbType.NChar, 3);
            b.AddParameter("@tiponomina", prms[10], SqlDbType.NChar, 2);
            b.AddParameter("@annquincena", prms[11], SqlDbType.NChar, 6);
            b.AddParameter("@Observaciones", Observaciones, SqlDbType.NChar);
            b.AddParameter("@Concentrado", 1, SqlDbType.Bit);
            return b.InsertUpdateDelete();
        }


    }
}