using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Propiedades.Procesos.Operacion
{
    public class Pendientes
    {
        public int IdTramite { get; set; }
        public int IdMesa { get; set; }
        public int IdStatusMesa { get; set; }
        public int IdStatusTramite { get; set; }
        public string FolioCompuesto { get; set; }
        public string Operacion { get; set; }

        //Nuevo
        public string Poliza { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
        public string Quincena { get; set; }
        public string Importe { get; set; }
        //*******

        public string Contratante { get; set; }
        public string RFC { get; set; }
        public string Titular { get; set; }

        public string NombreMesa { get; set; }
        public string EstatusMesa { get; set; }
        public string EstatusTramite { get; set; }
        public string FechaRegistro { get; set; }
    }
}
