using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.UNAM
{
    public class BD
    {
        public Tablas.Extraccion extraccion;
        public Tablas.Tramite tramite;

        public BD()
        {
            extraccion = new Tablas.Extraccion();
            tramite = new Tablas.Tramite();
        }
    }
}
