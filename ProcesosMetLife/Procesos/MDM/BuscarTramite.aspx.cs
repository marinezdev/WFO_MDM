using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Procesos.MDM
{
    public partial class BuscarTramite : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");

            if (!IsPostBack)
            {

            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "")
                return;
            //buscar un tramite asociado con la poliza
            i.mdm.trmaitedetmdm.Buscar(ref GV, txtBuscar.Text);
        }

        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //string id = e.CommandArgument.ToString();
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(':');
            if (e.CommandName == "Editar")
            {
                //Enviar el id a otra página
                Response.Redirect("Captura.aspx?id1=" + arg[0] + "&id2=" + arg[1] + "&id3=103&id4=17", true);
            }
            if (e.CommandName == "Revisar")
            {
                //Enviar el id a otra página
                Response.Redirect("Captura2.aspx?id1=" + arg[0] + "&id2=" + arg[1] + "&id3=104&id4=17", true);
            }

        }

        protected void GV_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}