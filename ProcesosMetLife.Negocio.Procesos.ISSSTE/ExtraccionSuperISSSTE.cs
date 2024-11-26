using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace ProcesosMetLife.Negocio.Procesos.ISSSTE
{
    public class ExtraccionSuperISSSTE : BD
    {
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

                b.taextraccionsuperissste.Agregar(IdUsuario, Folio, 
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

        }
    }
}
    