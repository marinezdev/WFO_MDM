using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Procesos.MDM
{
    public class Tramite_Mesa : BD
    {
        public string AsignarTramite(int IdMesa, int IdUsuario, ref int IdTramite)
        {
            var x = d.tramitemesa.AsignarTramite(IdMesa, IdUsuario, IdTramite);
            IdTramite = int.Parse(x[0].ToString());
            return x[0].ToString() + ":" + x[1].ToString();
        }

        public string ProcesarTramite(string idtramite, string idmesa, string idusuario, string idstatusmesa, string obspub, string obspri, string motivosrechazo)
        {
            var x = d.tramitemesa.ProcesarTramite(idtramite, idmesa, idusuario, idstatusmesa, obspub, obspri, motivosrechazo);
            return x[0].ToString() + ":" + x[1].ToString();
        }


    }
}
