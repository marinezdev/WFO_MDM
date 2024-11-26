using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Propiedades
{
    public class Sesion
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public DateTime Acceso { get; set; }
        public DateTime FinAcceso { get; set; }
        public int App { get; set; }
    }
}
