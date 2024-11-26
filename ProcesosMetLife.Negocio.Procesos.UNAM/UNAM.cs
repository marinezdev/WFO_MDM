using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.UNAM
{
    public class UNAM
    {
        public Extraccion extraccion;
        public Tramite tramite;

        public UNAM()
        {
            extraccion = new Extraccion();
            tramite = new Tramite();
        }
    }
}
