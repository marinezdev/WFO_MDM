using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM
{
    /// <summary>
    /// Instancias de acceso a la base de datos de MDM
    /// </summary>
    public class BD
    {
        public Tablas.Captura2 captura2;
        public Tablas.Extraccion extraccion;
        public Tablas.Tramite tramite;
        public Tablas.Tramite_Det_MDM tramitedetmdm;
        public Tablas.Tramite_Mesa tramitemesa;

        public BD()
        {
            captura2 = new Tablas.Captura2();
            extraccion = new Tablas.Extraccion();
            tramite = new Tablas.Tramite();
            tramitedetmdm = new Tablas.Tramite_Det_MDM();
            tramitemesa = new Tablas.Tramite_Mesa();
        }
    }
}
