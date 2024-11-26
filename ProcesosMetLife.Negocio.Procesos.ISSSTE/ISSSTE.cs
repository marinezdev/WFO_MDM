using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.ISSSTE
{
    public class ISSSTE
    {
        public Extraccion extracion;
        public ExtraccionSuperISSSTE extraccionsuperissste;

        public ISSSTE()
        {
            extracion = new Extraccion();
            extraccionsuperissste = new ExtraccionSuperISSSTE();
        }
    }
}
