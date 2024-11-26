using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace ProcesosMetLife.Procesos.MDM
{
    public partial class Entrega : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");
        
            if (!IsPostBack)
            {
                CargarEntregas();
            }
        }

        protected void CargarEntregas()
        {
            List<Propiedades.MDMEntregas> lsEntregasCaptura = i.mdm.captura2.getMDMEntregasaCaptura();

            DDLEntrega.DataSource = lsEntregasCaptura;
            DDLEntrega.DataTextField = "Nombre";
            DDLEntrega.DataValueField = "Id";
            DDLEntrega.DataBind();
            DDLEntrega.Items.Insert(0, new ListItem("SELECCIONAR", "0"));

            //dropdownlist.Items.Insert(dropdownlist.Items.Count, new ListItem(" ( SIN INFORMACIÓN )", "-1"));
            //i.mdm.captura2.SeleccionarFlujo_DropDownList(ref DDLEntrega, 1);
        }

        protected void BtnProcesarEntrega_Click(object sender, EventArgs e)
        {
            string strNombreArchivo = "";
            strNombreArchivo = DDLEntrega.SelectedItem.ToString().Replace("Proceso_Captura", "Capturado");
            strNombreArchivo = strNombreArchivo.Substring(6).Trim();

            Funciones.ManejoExcel.ExportarDataSetAExcel(this, i.mdm.extraccion.ExportarAExcel(int.Parse(DDLEntrega.SelectedValue.ToString())), strNombreArchivo);
            //Funciones.ManejoExcel.ExportarDataSetAExcel(this, i.mdm.extraccion.ExportarAExcel(1));
        }

        protected void cboEntregas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int IdEntrega = Convert.ToInt32(cboEntregas.SelectedValue.ToString());
            //PintaMesas(IdFlujo);
        }
    }
}