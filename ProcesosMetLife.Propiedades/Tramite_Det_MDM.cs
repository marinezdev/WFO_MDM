using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Propiedades
{
    public class Tramite_Det_MDM
    {
        public int Id { get; set; }
        public int IdTramite { get; set; }
        public int IdArchivo { get; set; }
        public string Poliza { get; set; }
        public string TipoNomina { get; set; }
        public string TipoMovimiento { get; set; }
        public string UnidadPago { get; set; }
        public string Quincena { get; set; }
        public string Importe { get; set; }
        public string Captura1 { get; set; }
        public string Captura2 { get; set; }

        //Adicionales
        public string No { get; set; }
        public string Guid { get; set; }
    }
}
