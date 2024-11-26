using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.UNAM
{
    public class Tramite : BD
    {
        public List<Propiedades.RespuestaNuevoTramiteN1> NuevoTramiteN1(Propiedades.TramiteN1 items)
        {
            return d.tramite.Agregar(items);
        }
    }
}
