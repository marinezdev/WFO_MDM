using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.UNAM
{
    public class BD
    {
        public AccesoDatos.UNAM.BD d;

        public BD()
        {
            d = new AccesoDatos.UNAM.BD();
        }
    }
}
