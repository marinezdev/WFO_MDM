using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    public class Extraccion : BD
    {
        
        /// <summary>
        /// Agrega un archivo de excel de extracción para ser procesado y agrega un nuevo tramite por cada registro
        /// </summary>
        /// <param name="archivo"></param>
        /// <param name="IdUsuario"></param>
        public void ProcesarExcel(ExcelPackage archivo, int IdUsuario, int Entrega, string NombreArchivo, ref int TotalPolizas)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);
            

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                //if (string.IsNullOrEmpty(fila[0].ToString()) && string.IsNullOrEmpty(fila[1].ToString()) && string.IsNullOrEmpty(fila[2].ToString()))
                if (string.IsNullOrEmpty(fila[0].ToString()))
                {
                    // No se encontró la póliza
                    return;
                }

                try
                {
                    int intExtraccion = 0;

                    //intExtraccion = d.extraccion.Agregar(IdUsuario, Entrega, NombreArchivo, fila[0].ToString(), fila[1].ToString(), fila[2].ToString());
                    intExtraccion = d.extraccion.Agregar(IdUsuario, Entrega, NombreArchivo, fila[0].ToString());
                    if (intExtraccion > 0)
                    {
                        Propiedades.TramiteN1 items = new Propiedades.TramiteN1()
                        {
                            Archivo = null             //No utilizado
                        ,
                            NombreArchivo = ""         //No utilizado
                        ,
                            IdTipoArchivo = 2          //1 Concentrado, 2 Extraccion, 3 Carta Promotoria, 4 Carta baja
                        ,
                            IdTipoTramite = 4          //4 MDM
                        ,
                            IdStatus = 1               //Registro
                        ,
                            IdUsuario = IdUsuario      //Usuario Id
                        ,
                            idPrioridad = 5            //1 Supervisor, 2 Sistema, 3 Grandes sumas, 4 Hombres clave, 5 Normal, 6 No procesaro
                        ,
                            Poliza = fila[0].ToString()
                        ,
                            IdPromotoria = 0           //No utilizado
                        ,
                            TipoMovimiento = null      //No utilizado
                        ,
                            UnidadPago = null          //No utilizado
                        ,
                            Quincena = null            //No utilizado
                        ,
                            Importe = null             //No utilizado
                        ,
                            No =  "0" // fila[0].ToString()
                        ,
                            Guid = "000" // fila[2].ToString()

                        };
                        d.tramite.Agregar(items);
                        TotalPolizas += 1;
                    }

                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                }
            }
        }

        public int getEntrega()
        {
            return d.extraccion.getEntrega();
        }

        public bool GuardarCaptura(Propiedades.Extraccion_MDM items)
        {
            if (d.extraccion.Guardar(items) == 1)
            {
                DataRow dr = d.tramitemesa.ProcesarTramite(items.idtramite, items.idmesa, items.idusuario, items.idstatusmesa, items.obspub, items.obspri, items.motivosrechazo);
                if (!dr[1].ToString().Contains("Trámite Procesado"))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public DataSet ExportarAExcel(int IdEntrega)
        {
            return d.extraccion.ExportarAExcel(IdEntrega);            
        }

        public DataSet getCapturaValidacion(int IdTramite)
        {
            return d.extraccion.getCapturaValidacion(IdTramite);
        }
    }
}
