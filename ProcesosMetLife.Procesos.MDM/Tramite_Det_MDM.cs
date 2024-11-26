using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    public class Tramite_Det_MDM : BD
    {
        public void Buscar(ref GridView gridview, string poliza)
        {
             Funciones.LlenarControles.LlenarGridView(ref gridview, d.tramitedetmdm.Buscar(poliza));
        }

        /// <summary>
        /// Obtiene los datos iniciales para la captura de un trámite
        /// </summary>
        /// <param name="idtramite"></param>
        /// <param name="poliza"></param>
        public void SeleccionarPorId(int IdTramite, ref TextBox no, ref TextBox poliza, ref TextBox guid)
        {
            Propiedades.Tramite_Det_MDM items = new Propiedades.Tramite_Det_MDM();
            items = d.tramitedetmdm.SeleccionarPorId(IdTramite);
            no.Text = items.No;
            poliza.Text = items.Poliza;
            guid.Text = items.Guid;

        }
    }
}
