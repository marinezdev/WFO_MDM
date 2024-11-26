using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Propiedades
{
    public class Extraccion_MDM
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public string Numero { get; set; }
        public string Poliza { get; set; }
        public string GUID_ { get; set; }
        public string PaisNacimiento { get; set; }
        public string EstadoNacimiento { get; set; }
        public string Ciudad { get; set; }
        public string Nacionalidad { get; set; }
        public string Ocupacion { get; set; }
        public string ClaveOcupacion { get; set; }
        public string DetalleOcupacion { get; set; }
        public string IngresoMensual { get; set; }
        public string TransaccionesAnualesAportaciones { get; set; }
        public string TransaccionesAnualesRetiros { get; set; }
        public string TransaccionesAportaciones { get; set; }
        public string TransaccionesRetiros { get; set; }
        public string PagoImpuestosExtranjero { get; set; }
        public string PagoImpuestosExtranjeroPais { get; set; }
        public string NSS { get; set; }
        public string DesempeñoDestacado { get; set; }
        public string RazonesContratacion { get; set; }
        public string NivelRiesgo { get; set; }
        public string LimitarDivulgacion { get; set; }
        public string Tipodocumento { get; set; }
        public string SubtipoDocumento { get; set; }
        public string Referencia { get; set; }
        public string FechaEmision { get; set; }
        public string FechaVigencia { get; set; }
        public string EntidadGubernamentalEmisora { get; set; }
        public string PaisEmisor { get; set; }
        public string Contador { get; set; }
        public string Eliminar { get; set; }
        public int UsuarioCaptura1 { get; set; }
        public int UsuarioCaptura2 { get; set; }

        public string EstadoFinal { get; set; }
        public string Comentarios { get; set; }

        //Adicionales usados para guardado extra
        public string idtramite { get; set; }
        public string idmesa { get; set; }
        public string idusuario { get; set; }
        public string idstatusmesa { get; set; }
        public string obspub { get; set; }
        public string obspri { get; set; }
        public string motivosrechazo { get; set; }

    }
}
