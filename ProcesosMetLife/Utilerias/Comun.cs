using System.Web;
using System.Web.Configuration;

namespace ProcesosMetLife.Utilerias
{
    /// <summary>
    /// Clase para integrar todos los procesos y facilitar la accesibilidad
    /// </summary>
    public class Comun : System.Web.UI.Page
    {
        /// <summary>
        /// Instanciador general de acceso a todos los procesos de negocio
        /// </summary>
        public Negocio.Inicializador.Inicializador i;

        //Utilerias/Servicios
        public IU.ManejadorSesion manejo_sesion;
        public Mensajes mensajes;
        public RegistraLog.RegistraLog log;
        public RegistraLog.RegistraLog seguimiento;

        public Comun()
        {
            //Inicializador general
            i = new Negocio.Inicializador.Inicializador();

            //Utilerias/Servicios
            manejo_sesion = new IU.ManejadorSesion();
            mensajes = new Mensajes();
            log = new RegistraLog.RegistraLog("Log", HttpContext.Current.Server.MapPath("~"), "Procesos-MetLife Error");
            seguimiento = new RegistraLog.RegistraLog("Log", HttpContext.Current.Server.MapPath("~"), "Procesos-MetLife Seguimiento");

            manejo_sesion.EsperaBloqueo = WebConfigurationManager.AppSettings["EsperaLoginBloqueado"];

        }


    }
}