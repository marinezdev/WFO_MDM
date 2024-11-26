using System;
using System.Web;
using System.Web.UI.WebControls;

namespace ProcesosMetLife.Procesos
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Aplicaciones = 0;
            int IdAplicacionPrincipal = 0;

            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            manejo_sesion.Salida = 1;
            manejo_sesion.Menu = "";
            Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;
            Session["Inicio"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //visibilidad de botones
            foreach (Propiedades.Aplicaciones items in i.administracion.aplicaciones.VisibilidadBotones(manejo_sesion.Usuarios.IdUsuario.ToString()))
            {
                Aplicaciones += 1;
                IdAplicacionPrincipal = items.IdAplicacion;
            
                Button button = new Button();
                button.Text = items.Nombre;
                button.Height = 200;
                button.Width = 344;
                button.CssClass = "btn btn-primary";
                button.CommandArgument = items.IdAplicacion.ToString();
                button.Click += new EventHandler(Button_Click);
                Panel1.Controls.Add(button);
            }
            if (!IsPostBack)
            {
                if (Aplicaciones == 1)
                {
                    Seleccion(IdAplicacionPrincipal.ToString(),1);
                }
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button valor = (Button)sender;
            var ov = valor.Text;

            switch (ov)
            {
                case "ISSSTE":
                    Seleccion("4", 0);
                    break;
                case "Auditoría":
                    Seleccion("5", 0);
                    break;
                case "Administración General":
                    Seleccion("6", 0);
                    break;
                case "MDM":
                    Seleccion("7", 0);
                    break;
                case "UNAM":
                    Seleccion("8", 0);
                    break;
            }

        }

        private void Seleccion(string app, int Aplicaciones)
        {
            string mensaje                      = string.Empty;
            i.administracion.login.Autorizar(manejo_sesion.Cla, manejo_sesion.Con, manejo_sesion, app);
            Propiedades.Sesion psesion          = new Propiedades.Sesion();
            psesion.IdUsuario                   = manejo_sesion.Usuarios.IdUsuario;
            psesion.App                         = int.Parse(app);
            manejo_sesion.IdParaCierreSesion    = i.administracion.sesion.Agregar(psesion);
            //manejo_sesion.Salida                = 0;
            manejo_sesion.Salida                = Aplicaciones;
            manejo_sesion.Menu                  = i.administracion.menu.Seleccionar(manejo_sesion.Usuarios.IdRol, app); //nueva carga del menú, como es modo texto, ya no hay que cargarlo de nuevo
            Session["Sesion"]                   = manejo_sesion;                        //Asignación de la sesión principal del sistema
            Session["idusuario"]                = manejo_sesion.Usuarios.IdUsuario;  //desbloqueo del usuario si termina la sesión
            Session["IdSesion"]                 = HttpContext.Current.Session.SessionID;
            Session["Inicio"]                   = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (manejo_sesion.Usuarios.RolAcceso == "" || manejo_sesion.Usuarios.RolAcceso == null)
                mensajes.MostrarMensaje(this, "Sin acceso a la aplicación seleccionada");
            else
            {
                Response.Redirect(manejo_sesion.Usuarios.RolAcceso, false);
                //Response.Redirect("Procesos/supervision/capturausuarios.aspx", true);
            }
        }


        

    }
}