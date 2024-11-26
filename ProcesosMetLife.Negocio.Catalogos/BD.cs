using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLifel.Negocio.Catalogos
{
    public class BD
    {
        public ProcesosMetLife.AccesoDatos.MDM.Tablas.Catalogos catalogosmdm;

        public BD()
        {
            catalogosmdm = new ProcesosMetLife.AccesoDatos.MDM.Tablas.Catalogos();
        }
    }
}
