using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProcesosMetLife.Negocio.Procesos.UNAM
{
    public class Extraccion : BD
    {
        /// <summary>
        /// Agrega un archivo de excel de extracción para ser procesado y agrega un nuevo tramite por cada registro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="IdUsuario"></param>
        public void ProcesarExcel(ExcelPackage archivo, int IdUsuario)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                if (string.IsNullOrEmpty(fila[0].ToString()) && string.IsNullOrEmpty(fila[1].ToString()) && string.IsNullOrEmpty(fila[2].ToString()))
                    return;

                try
                {
                    d.extraccion.Agregar(IdUsuario, fila[0].ToString(), fila[1].ToString(), fila[2].ToString());

                    Propiedades.TramiteN1 items = new Propiedades.TramiteN1()
                    {
                        Archivo = null,             //No utilizado
                        NombreArchivo = "",       //No utilizado
                        IdTipoArchivo = 2,         //1 Concetntrado, 2 Extraccion, 3 Carta Promotoria, 4 Carta baja
                        IdTipoTramite = 4,          //MDM
                        IdStatus = 1,               //Registro
                        IdUsuario = IdUsuario,
                        idPrioridad = 5,            //1 Supervisor, 2 Sistema, 3 Grandes sumas, 4 Hombres clave, 5 Normal, 6 No procesaro
                        Poliza = fila[1].ToString(),
                        IdPromotoria = 0,           //No utilizado
                        TipoMovimiento = null,      //No utilizado
                        UnidadPago = null,          //No utilizado
                        Quincena = null,            //No utilizado
                        Importe = null              //No utilizado
                    };
                    d.tramite.Agregar(items);

                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                }
            }
        }
    }
}
