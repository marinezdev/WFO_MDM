using System;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI;

namespace ProcesosMetLife.Procesos.MDM.Supervisor
{
    public partial class rptTramitesTotales : Utilerias.Comun
    {
        int suma01 = 0;
        int suma02 = 0;
        int suma03 = 0;
        int suma04 = 0;
        int suma05 = 0;
        int suma06 = 0;
        int suma07 = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];

            if (!IsPostBack)
            {
                CargaFlujos(manejo_sesion.Usuarios.IdUsuario);

                if (!string.IsNullOrEmpty(Request["idmesa"]) && !string.IsNullOrEmpty(Request["statusmesa"]))
                {
                    //ddlFlujo.SelectedValue = Request["f"];
                    //supervisiongeneraltramites.Tramite_LlenarGridView(ref GVReporte, Request["f"]);
                    //supervisiongeneraltramitemesa.TramiteMesaLLenarDetalle_GridView(ref GVDetalle, Request["idmesa"].ToString(), Request["statusmesa"].ToString());
                }
            }
        }

        protected void CargaFlujos(int Id)
        {
            i.mdm.captura2.SeleccionarFlujo_DropDownList(ref ddlFlujo, Id);
        }

        protected void GVReporte_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    HyperLink h1 = (HyperLink)e.Row.FindControl("HLKAdmision");
            //    HyperLink h2 = (HyperLink)e.Row.FindControl("HLKRevision");
            //    HyperLink h3 = (HyperLink)e.Row.FindControl("HLKCaptura");
            //    HyperLink h4 = (HyperLink)e.Row.FindControl("HLKControl");
            //    HyperLink h5 = (HyperLink)e.Row.FindControl("HLKEjecucion");
            //    HyperLink h6 = (HyperLink)e.Row.FindControl("HLKCalidad");
            //    HyperLink h7 = (HyperLink)e.Row.FindControl("HLKKwik");

            //    if (e.Row.Cells[0].Text == "Registro")
            //    {
            //        e.Row.Cells[0].BackColor = Color.SteelBlue;
            //        e.Row.Cells[0].ForeColor = Color.White;
            //    }
            //    if (e.Row.Cells[0].Text == "Atrapado")
            //    {
            //        e.Row.Cells[0].BackColor = Color.LimeGreen;
            //        e.Row.Cells[0].ForeColor = Color.White;
            //    }

            //    if (e.Row.Cells[0].Text == "Registro" && e.Row.Cells[1].Text != "0")
            //    {
            //        e.Row.Cells[1].BackColor = Color.SteelBlue;
            //        e.Row.Cells[1].ForeColor = Color.White;
            //    }
            //    if (e.Row.Cells[0].Text == "Atrapado" && e.Row.Cells[1].Text != "0")
            //    {
            //        e.Row.Cells[1].BackColor = Color.LimeGreen;
            //        e.Row.Cells[1].ForeColor = Color.White;
            //    }

            //    if (e.Row.Cells[0].Text == "Registro" && e.Row.Cells[2].Text != "0")
            //    {
            //        e.Row.Cells[2].BackColor = Color.SteelBlue;
            //        e.Row.Cells[2].ForeColor = Color.White;
            //    }
            //    if (e.Row.Cells[0].Text == "Atrapado" && e.Row.Cells[2].Text != "0")
            //    {
            //        e.Row.Cells[2].BackColor = Color.LimeGreen;
            //        e.Row.Cells[2].ForeColor = Color.White;
            //    }

            //    suma01 = suma01 + int.Parse(h1.Text);
            //    suma02 = suma02 + int.Parse(h2.Text);
            //    suma03 = suma03 + int.Parse(h3.Text);
            //    suma04 = suma04 + int.Parse(h4.Text);
            //    suma05 = suma05 + int.Parse(h5.Text);
            //    suma06 = suma06 + int.Parse(h6.Text);
            //    suma07 = suma07 + int.Parse(h7.Text);

            //}
            //if (e.Row.RowType == DataControlRowType.Footer)
            //{
            //    e.Row.HorizontalAlign = HorizontalAlign.Left;
            //    e.Row.Cells[0].Text = "Totales: ";
            //    e.Row.Cells[1].Text = suma01.ToString();
            //    e.Row.Cells[2].Text = suma02.ToString();
            //    e.Row.Cells[3].Text = suma03.ToString();
            //    e.Row.Cells[4].Text = suma04.ToString();
            //    e.Row.Cells[5].Text = suma05.ToString();
            //    e.Row.Cells[6].Text = suma06.ToString();
            //    e.Row.Cells[7].Text = suma07.ToString();
            //}
        }

        protected void ddlFlujo_SelectedIndexChanged(object sender, EventArgs e)
        {
            String script;

            int _IdFlujo = 0;
            _IdFlujo = int.Parse(ddlFlujo.SelectedValue.ToString());

            i.mdm.captura2.Tramite_LlenarGridView(ref GVReporte, _IdFlujo);
            GVDetalle.DataSource = null;
            GVDetalle.DataBind();

            rptTramites.DataSource = GVReporte.DataSource;
            rptTramites.DataBind();

            // Formato de tabla
            //script = "";
            //script = "$('#example').DataTable({'language': {'url': '//cdn.datatables.net/plug-ins/1.10.15/i18n/Spanish.json'},scrollY: '400px',scrollX: true,scrollCollapse: true, fixedColumns: true,dom: 'Blfrtip', buttons: [{ extend: 'copy', className: 'btn-sm'}, {extend: 'csv', className: 'btn-sm'}, {extend: 'excel', className: 'btn-sm'}, {extend: 'pdfHtml5', className: 'btn-sm'}, {extend: 'print', className: 'btn-sm'}]}); retirar();";
            //ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
        }
    }
}