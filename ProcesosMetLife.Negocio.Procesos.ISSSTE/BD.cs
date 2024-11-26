using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.ISSSTE
{
    public class BD
    {
        public AccesoDatos.ISSSTE.BD b;

        public BD()
        {
            b = new AccesoDatos.ISSSTE.BD();
        }
    }
}
