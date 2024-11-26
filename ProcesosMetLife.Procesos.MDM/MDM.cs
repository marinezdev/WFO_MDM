using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    /// <summary>
    /// Instancias de acceso de MDM de negocio
    /// </summary>
    public class MDM
    {
        public Captura2 captura2;
        public Extraccion extraccion;
        public Tramite tramite;
        public Tramite_Det_MDM trmaitedetmdm;
        public Tramite_Mesa tramitemesa;

        public MDM()
        {
            captura2 = new Captura2();
            extraccion = new Extraccion();
            tramite = new Tramite();
            trmaitedetmdm = new Tramite_Det_MDM();
            tramitemesa = new Tramite_Mesa();
        }
    }
}
