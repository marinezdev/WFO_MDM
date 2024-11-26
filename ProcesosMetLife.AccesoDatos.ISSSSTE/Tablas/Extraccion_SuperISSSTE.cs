using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.ISSSTE.Tablas
{
    public class Extraccion_SuperISSSTE
    {
        ManejoDatos b = new ManejoDatos();

        public int Agregar(int IdUsuario, string Folio, params string[] prms)
        {
            b.ExecuteCommandSP("ISSSTE.dbo.Movimientos_Extraccion_Super_ISSSTE_Add");
            b.AddParameter("@idusuario", IdUsuario, SqlDbType.Int);
            b.AddParameter("@folio", Folio, SqlDbType.VarChar, 15);
            b.AddParameter("@idsuperissste", prms[0], SqlDbType.Int);
            b.AddParameter("@tipoderegistro", prms[1], SqlDbType.Int);
            b.AddParameter("@retenedor", prms[2], SqlDbType.VarChar, 100);
            b.AddParameter("@unidaddepago", prms[3], SqlDbType.VarChar, 100);
            b.AddParameter("@poliza", prms[4], SqlDbType.VarChar, 100);
            b.AddParameter("@quincena", prms[5], SqlDbType.VarChar, 100);
            b.AddParameter("@concepto", prms[6], SqlDbType.VarChar, 100);
            b.AddParameter("@tm", prms[7], SqlDbType.VarChar, 100);
            b.AddParameter("@importe", prms[8], SqlDbType.VarChar, 100);
            b.AddParameter("@rfc", prms[9], SqlDbType.VarChar, 100);
            b.AddParameter("@apellidonombre", prms[10], SqlDbType.VarChar, 100);
            b.AddParameter("@idnominal", prms[11], SqlDbType.VarChar, 100);
            b.AddParameter("@importe$", prms[12], SqlDbType.VarChar, 100);
            b.AddParameter("@promotoriaus", prms[13], SqlDbType.VarChar, 2);
            b.AddParameter("@usuarious", prms[14], SqlDbType.VarChar, 50);
            b.AddParameter("@servicio", prms[15], SqlDbType.Int);
            b.AddParameter("@motivodelservicio", prms[16], SqlDbType.Int);
            b.AddParameter("@estatus", prms[17], SqlDbType.VarChar, 1);
            b.AddParameter("@descripciondelservicio", prms[18], SqlDbType.VarChar, 100);
            b.AddParameter("@descripcionmotivo", prms[19], SqlDbType.VarChar, 100);
            b.AddParameter("@observaciones", prms[20], SqlDbType.VarChar, 100);
            return b.InsertUpdateDelete();
        }



    }
}
