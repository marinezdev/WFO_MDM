using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;

namespace ProcesosMetLife.Procesos.MDM.Supervisor
{
    public partial class rptCapturaAvances : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            CargarEntregas();

            if (!IsPostBack)
            {
                CalDesde.EditFormatString = "yyyy-MM-dd";
                CalDesde.Date = DateTime.Now.AddDays(-1);
                CalDesde.MaxDate = DateTime.Today;
                CalHasta.EditFormatString = "yyyy-MM-dd";
                CalHasta.Date = DateTime.Today;
                CalHasta.MaxDate = DateTime.Today;
            }
        }

        protected void CargarEntregas()
        {
            List<Propiedades.MDMEntregas> lsEntregas = i.mdm.captura2.getMDMEntregas();
            cboEntregas.DataSource = lsEntregas;
            cboEntregas.TextField = "Nombre";
            cboEntregas.ValueField = "Id";
            cboEntregas.DataBind();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            // Declaración de Variables.
            String script = "";

            if (cboEntregas.SelectedIndex == -1)
            {
                //mensajes.EjecutarCodigo(this, "alert('prueba 1'); window.location.href('Default2.aspx');");
                mensajes.MostrarMensajeSM(this, "Debe seleccionar la Entrega a Generar");
                //Response.Redirect("home.aspx", true);
            }
            else
            {
                List<Propiedades.MDMEntregas> lsCaptura = i.mdm.captura2.getMDMEntregasaCaptura();

                // Asignamos los datos
                rptTramites.DataSource = lsCaptura;
                rptTramites.DataBind();

                // Formato de tabla
                script = "";
                script = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}