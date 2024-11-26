using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeOpenXml;

namespace ProcesosMetLife.Procesos.MDM
{
    public partial class Extraccion : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");
            
            if (!IsPostBack)
            {

            }
        }

        protected void BtnExcelAceptar_Click(object sender, EventArgs e)
        {
            int Entrega = 0;
            int TotalPolizas = 0;
            string strNombreArchivo = "";

            try
            {
                strNombreArchivo = AsyncFileUpload1.FileName;
                BtnExcelAceptar.Enabled = false;

                //string strFolio = DateTime.Now.ToString("yyMMddHHmm") + string.Format("{0:0000}", manejo_sesion.Usuarios.IdUsuario);
                string nombrearchivo = Server.MapPath("~/ArchivosTemporales/" + strNombreArchivo);
                AsyncFileUpload1.SaveAs(nombrearchivo);

                ExcelPackage pagina = new ExcelPackage(AsyncFileUpload1.FileContent);

                Entrega = i.mdm.extraccion.getEntrega();
                i.mdm.extraccion.ProcesarExcel(pagina, manejo_sesion.Usuarios.IdUsuario, Entrega, strNombreArchivo, ref TotalPolizas);
                LblProcesado.Text = "Terminó exitosamente la carga y procesamiento del archivo. Total de Pólizas Cargadas " + TotalPolizas.ToString();
            }
            catch (Exception ex)
            {
                GVExtraccion.DataSource = null;
                GVExtraccion.DataBind();

                lblProcesadoExcel.Text = "No se pudo guardar el archivo: asegúrese de cargarlo apropiadamente.";
                lblProcesadoExcel.ForeColor = System.Drawing.Color.Red;
                log.AgregarError(ex.Message.ToString());
            }
        }
    }
}