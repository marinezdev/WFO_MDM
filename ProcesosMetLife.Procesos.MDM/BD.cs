using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    /// <summary>
    /// Instancias de acceso a la base de datos de MDM para Negocio
    /// </summary>
    public class BD
    {
        public AccesoDatos.MDM.BD d;

        public BD()
        {
            d = new AccesoDatos.MDM.BD();
        }
    }
}
