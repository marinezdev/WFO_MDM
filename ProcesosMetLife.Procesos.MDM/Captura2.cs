using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Data;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    public class Captura2 : BD
    {
        public bool Agregar(Propiedades.Extraccion_MDM items, string TablaNombre)
        {
            return d.captura2.Guardar(items, TablaNombre);
        }

        public List<Propiedades.MDMEntregas> getMDMEntregasaCaptura()
        {
            return d.captura2.getMDMEntregasaCaptura();
        }

        public List<Propiedades.MDMEntregas> getMDMEntregas()
        {
            return d.captura2.getMDMEntregas();
        }

        public List<Propiedades.UsuariosFlujos> getFlujos(int IdUsuario)
        {
            return d.captura2.SelecionarFlujo(IdUsuario);
        }

        public void SeleccionarFlujo_DropDownList(ref DropDownList dropdownlist, int idusuario)
        {
            Funciones.LlenarControles.LlenarDropDownList(ref dropdownlist, d.captura2.SelecionarFlujo(idusuario), "Nombre", "Id");
        }

        public void Tramite_LlenarGridView(ref GridView gridview, int IdFlujo)
        {
            Funciones.LlenarControles.LlenarGridView(ref gridview, d.captura2.SeleccionarTramitesPorMesa(IdFlujo));
        }

        public List<Propiedades.MapaGeneral> getDashboard()
        {
            return d.captura2.getDashboard(4); 
        }

        public DataSet getCapturaUsuario(DateTime FInicio, DateTime FTermino)
        {
            return d.captura2.getCapturaUsuario(FInicio, FTermino);
        }

        public DataSet getCapturaUsuarioDiario(DateTime FInicio, DateTime FTermino)
        {
            return d.captura2.getCapturaUsuarioDiario(FInicio, FTermino);
        }
        

        public void Dashboard(ref Literal literal, int IdFlujo)
        {
            List<Propiedades.MapaGeneral> Dashboard = d.captura2.getDashboard(IdFlujo);

            for (int i = 0; i < Dashboard.Count; i++)
            {
                int Tramites = Dashboard[i].TramitesDisponibles + Dashboard[i].TramitesReingresos;
                literal.Text += "<div class='control-label col-md-4 col-sm-4 col-xs-6'>" +
                            "<div class='x_panel text-center'>" +
                                "<a href='TramiteProcesar.aspx?IdFlujo=" + IdFlujo.ToString() + "&IdMesa=" + Dashboard[i].IdMesa.ToString() + "'>" +
                                    "<table style='border: 0px solid #5A738E; width:100%'>" +
                                        "<tr style='vertical-align: center; text-align: center; '>" +
                                            "<td>" +
                                                "<i class='fa " + Dashboard[i].Icono + " fa-5x'></i>" +
                                                "<div class='form-group text-center'>" +
                                                    "<hr />" +
                                                    "<h2><small>" + Dashboard[i].Mesa + "</small></h2><br/>" +
                                                "</div>" +
                                            "</td>" +
                                            "<td>" +
                                                "<div class='form-group text-center'>" +
                                                    "<i class='fa fa-male fa-3x'></i>   <strong style='font-size: 20px;'>" + Dashboard[i].UsuariosConectados.ToString() + "<strong/><br/><br/>" +
                                                    "<i class='fa fa-book fa-2x'></i>   <strong style='font-size: 20px;'>" + Tramites.ToString() + "<strong/>" +
                                                 "</div>" +
                                            "</td>" +
                                        "</tr>" +
                                    "</table>" +
                                "</a>" +
                            "</div>" +
                         "</div>";
            }
        }
    }
}
