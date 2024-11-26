using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using ClosedXML.Excel;
using System.Web;
using System.IO;
using System.Web.UI;

namespace ProcesosMetLife.Procesos.Supervision
{
    public partial class CapturaUsuarios : Utilerias.Comun
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
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

        protected void btnFiltroMes_Click(object sender, EventArgs e)
        {
            Mensaje.Text = "";
            if (CalDesde.Date <= CalHasta.Date)
            {
                DateTime FInicio = DateTime.Parse(CalDesde.Date.Year.ToString() + "/" + CalDesde.Date.Month.ToString() + "/" + CalDesde.Date.Day + " 00:00:00");
                DateTime FTermino = DateTime.Parse(CalHasta.Date.Year.ToString() + "/" + CalHasta.Date.Month.ToString() + "/" + CalHasta.Date.Day + " 23:59:59");

                DataSet ds = i.mdm.captura2.getCapturaUsuario(FInicio, FTermino);
                rptTramitesEspera.DataSource = ds.Tables[0];
                rptTramitesEspera.DataBind();
            }
            else
            {
                Mensaje.Text = "La fecha 'Desde' debe ser menor a la fecha 'Hasta'";
                //rptTramitesEspera.Visible = false;
            }
        }


        protected void btnExportar_Click(object sender, EventArgs e)
        {
            //Mensaje.Text = "";
            //if (CalDesde.Date <= CalHasta.Date)
            //{
            //    string script = "window.open('detalleMesaRDescarga.aspx?In=" + CalDesde.Date + "&Fn=" + CalHasta.Date + "&Us=" + manejo_sesion.Credencial.Id + "','Expediente', 'width = 800, height = 400');";
            //    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);

            //}
            //else
            //{
            //    Mensaje.Text = "La fecha 'Desde' debe ser menor a la fecha 'Hasta'";
            //    //rptTramitesEspera.Visible = false;
            //}
        }

        //[WebMethod]
        //public static ConsultaBitacoraSabana BusquedaBitacoraDescraga()
        //{
        //    //DataTable dt = (new wfiplib.NReportes()).SabanaConsultaBitacoraDescarga();
        //    ///* LLENAR JSON PARA RETORNAR */
        //    //ConsultaBitacoraSabana jsonObject = new ConsultaBitacoraSabana();
        //    //jsonObject.bitacoraSabanas = new List<BitacoraSabana>();

        //    //foreach (DataRow row in dt.Rows)
        //    //{
        //    //    jsonObject.bitacoraSabanas.Add(new BitacoraSabana()
        //    //    {
        //    //        FechaRegistro = row["FechaRegistro"].ToString(),
        //    //        FechaInicio = row["FechaInicio"].ToString(),
        //    //        FechaFin = row["FechaFin"].ToString(),
        //    //        NumRegistros = row["NumRegistro"].ToString(),
        //    //        Usuario = row["Usuario"].ToString(),
        //    //        NumSolicitudes = row["NumSolicitudes"].ToString(),
        //    //    });
        //    //}

        //    //return jsonObject;
        //}

        //[WebMethod]
        //public static ConsultasMesas Busqueda(int Id)
        //{
        //    //DataTable dt = (new wfiplib.NReportes()).InformacionTramiteBitacora(Id);
        //    ///* LLENAR JSON PARA RETORNAR */
        //    //ConsultasMesas jsonObject = new ConsultasMesas();
        //    //jsonObject.consulta = new List<Consulta>();

        //    //foreach (DataRow row in dt.Rows)
        //    //{
        //    //    jsonObject.consulta.Add(new Consulta()
        //    //    {
        //    //        Orden = row["NORDENREPORTE"].ToString(),
        //    //        IdTramite = row["IdTramite"].ToString(),
        //    //        FechaRegistro = row["FechaRegistro"].ToString(),
        //    //        NMESA = row["NMESA"].ToString(),
        //    //        FechaInicio = row["FechaInicio"].ToString(),
        //    //        FechaTermino = row["FechaTermino"].ToString(),
        //    //        EstadoMesa = row["EstadoMesa"].ToString(),
        //    //        Observacion = row["Observacion"].ToString(),
        //    //        NombreUsuario = row["NombreUsuario"].ToString(),
        //    //    });
        //    //}

        //    //return jsonObject;
        //}
    }
}