using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Procesos.MDM
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            mensajes.TituloAplicacionEnUso(this, "MDM");
            if (!IsPostBack)
            {

            }
        }
    }
}