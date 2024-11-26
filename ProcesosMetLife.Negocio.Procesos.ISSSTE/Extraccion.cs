using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProcesosMetLife.Negocio.Procesos.ISSSTE
{
    public class Extraccion : BD
    {
        //Métodos públicos
        public void ProcesarExcel(ExcelPackage archivo, int IdUsuario, string Folio)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatos(archivo);

            //Procesar la tabla

            foreach (DataRow fila in dt.Rows)
            {
                if (string.IsNullOrEmpty(fila[0].ToString()) && string.IsNullOrEmpty(fila[1].ToString()) && string.IsNullOrEmpty(fila[2].ToString()) &&
                    string.IsNullOrEmpty(fila[3].ToString()) && string.IsNullOrEmpty(fila[4].ToString()) && string.IsNullOrEmpty(fila[5].ToString()) &&
                    string.IsNullOrEmpty(fila[6].ToString()) && string.IsNullOrEmpty(fila[7].ToString()) && string.IsNullOrEmpty(fila[8].ToString()) &&
                    string.IsNullOrEmpty(fila[9].ToString()) && string.IsNullOrEmpty(fila[10].ToString()) && string.IsNullOrEmpty(fila[11].ToString()) &&
                    string.IsNullOrEmpty(fila[12].ToString()) && string.IsNullOrEmpty(fila[13].ToString()) && string.IsNullOrEmpty(fila[14].ToString()) &&
                    string.IsNullOrEmpty(fila[15].ToString()) && string.IsNullOrEmpty(fila[16].ToString()) && string.IsNullOrEmpty(fila[17].ToString()) &&
                    string.IsNullOrEmpty(fila[18].ToString()) && string.IsNullOrEmpty(fila[19].ToString()) && string.IsNullOrEmpty(fila[20].ToString()) 
                    )
                    return;

                try
                {
                    Agregar(IdUsuario, Folio, 
                    fila[0].ToString(),
                    fila[1].ToString(),
                    fila[2].ToString(),
                    fila[3].ToString(),
                    fila[4].ToString(),
                    fila[5].ToString(),
                    fila[6].ToString(),
                    fila[7].ToString(),
                    fila[8].ToString(),
                    fila[9].ToString(),
                    fila[10].ToString(),
                    fila[11].ToString(),
                    fila[12].ToString(),
                    fila[13].ToString(),
                    fila[14].ToString(),
                    fila[15].ToString(),
                    fila[16].ToString(),
                    fila[17].ToString(),
                    fila[18].ToString(),
                    fila[19].ToString(),
                    fila[20].ToString()
                    );
                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                }
            }
        }

        public void ProcesarExcelConcentrado(ExcelPackage archivo, int IdUsuario, string Folio, string Observaciones)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatosConcentrado(archivo);

            //Procesar la tabla
            foreach (DataRow columna in dt.Rows)
            {
                if (
                     //    string.IsNullOrEmpty(columna[0].ToString()) 
                     // && string.IsNullOrEmpty(columna[1].ToString()) 
                     string.IsNullOrEmpty(columna[2].ToString())
                    && string.IsNullOrEmpty(columna[3].ToString())
                    && string.IsNullOrEmpty(columna[4].ToString())
                    && string.IsNullOrEmpty(columna[5].ToString())
                    && string.IsNullOrEmpty(columna[6].ToString())
                    && string.IsNullOrEmpty(columna[7].ToString())
                    && string.IsNullOrEmpty(columna[8].ToString())
                    && string.IsNullOrEmpty(columna[9].ToString())
                    && string.IsNullOrEmpty(columna[10].ToString())
                // && string.IsNullOrEmpty(columna[11].ToString())
                )
                    return;

                try
                {
                    double dblImporte = 0;
                    dblImporte = double.Parse(columna[1].ToString().Replace(",", "").Trim());

                    AgregarConcentrado(IdUsuario, Folio, Observaciones,
                        columna[0].ToString(),
                        string.Format("{0:#.00}", dblImporte),
                        columna[2].ToString(),
                        columna[3].ToString(),
                        columna[4].ToString(),
                        columna[5].ToString(),
                        columna[6].ToString(),
                        columna[7].ToString(),
                        columna[8].ToString(),
                        columna[9].ToString(),
                        columna[10].ToString(),
                        columna[11].ToString()
                    );
                }
                catch (Exception ex)
                {
                }
            }
        }

        public DataTable ProcesarExcelPromotoria(ExcelPackage archivo)
        {
            DataTable dt = new DataTable();
            dt = Funciones.ManejoExcel.Excel_A_TablaDeDatosPromotoria(archivo);

            ////Procesar la tabla
            foreach (DataRow columna in dt.Rows)
            {
                if (
                     string.IsNullOrEmpty(columna[0].ToString())
                     && string.IsNullOrEmpty(columna[1].ToString())
                     && string.IsNullOrEmpty(columna[2].ToString())
                     && string.IsNullOrEmpty(columna[3].ToString())
                     && string.IsNullOrEmpty(columna[4].ToString())
                     && string.IsNullOrEmpty(columna[5].ToString())
                )
                    return null;

            }

            return dt;
        }

        //Métodos privados
        private int Agregar(int IdUsuario, string Folio, params string[] prms)
        {
            return b.taextraccion.Agregar(IdUsuario, Folio, prms);
        }

        private int AgregarConcentrado(int IdUsuario, string Folio, string Observaciones, params string[] prms)
        {
            return b.taextraccion.AgregarConcentrado(IdUsuario, Folio, Observaciones, prms);
        }

    }
}
