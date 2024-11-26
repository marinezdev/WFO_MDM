using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Negocio.Sistema
{
    public class Aplicaciones
    {
        AccesoDatos.Sistema.Aplicaciones aplicaciones = new AccesoDatos.Sistema.Aplicaciones();

        public List<Propiedades.Aplicaciones> VisibilidadBotones(string idusuario)
        {
            return aplicaciones.Selecionar(idusuario);
        }
    }
}
