using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.ISSSTE.Tablas
{
    public class Extraccion
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(int IdUsuario, string Folio, params string[] prms)
        {
            b.ExecuteCommandSP("ISSSTE.dbo.Movimientos_Extraccion_Add");
            b.AddParameter("@idusuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@folio", Folio, SqlDbType.VarChar, 15);
            b.AddParameter("@idproducto", prms[0], SqlDbType.VarChar,10);
            b.AddParameter("@cvemov", prms[1], SqlDbType.VarChar, 100);
	        b.AddParameter("@ultimodeaaqq", prms[2], SqlDbType.VarChar, 100);
            b.AddParameter("@idpoliza", prms[3], SqlDbType.VarChar, 100);
            b.AddParameter("@idretenedor", prms[4], SqlDbType.VarChar, 100);
            b.AddParameter("@idunidadpago", prms[5], SqlDbType.VarChar, 100);
            b.AddParameter("@idconceptoret", prms[6], SqlDbType.VarChar, 100);
            b.AddParameter("@impmov", prms[7], SqlDbType.VarChar, 100);
            b.AddParameter("@rfc", prms[8], SqlDbType.VarChar, 100);
            b.AddParameter("@homoclave", prms[9], SqlDbType.VarChar, 100);
            b.AddParameter("@idnominal", prms[10], SqlDbType.VarChar, 100);
            b.AddParameter("@nombre", prms[11], SqlDbType.VarChar, 100);
            b.AddParameter("@primerapellido", prms[12], SqlDbType.VarChar, 100);
            b.AddParameter("@segundoapellido", prms[13], SqlDbType.VarChar, 100);
            b.AddParameter("@idpromotoria", prms[14], SqlDbType.VarChar, 10);
            b.AddParameter("@fechainivig", prms[15], SqlDbType.VarChar, 15);
            b.AddParameter("@statpol", prms[16], SqlDbType.VarChar, 100);
            b.AddParameter("@pdescpagada", prms[17], SqlDbType.VarChar, 100);
            b.AddParameter("@aaqqultpag", prms[18], SqlDbType.VarChar, 100);
            b.AddParameter("@fechaactualizacion", prms[19], SqlDbType.VarChar, 100);
            b.AddParameter("@actualizadopor", prms[20], SqlDbType.VarChar, 100);
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