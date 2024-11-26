using System;
using System.Web;

namespace ProcesosMetLife
{
    public partial class Default : Utilerias.Comun
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SM1.IsInAsyncPostBack)
                Session["timeout"] = DateTime.Now.AddMinutes(double.Parse(manejo_sesion.EsperaBloqueo)).ToString();
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = string.Empty;
                string ruta = string.Empty;
                int validaUsuario = i.administracion.login.Autenticar(txUsuario.Text, txClave.Text, ref mensaje);
                if (validaUsuario == 1 || validaUsuario == 3)
                {
                    //autorizacion previa para el usuario
                    i.administracion.login.Autorizar(txUsuario.Text, txClave.Text, manejo_sesion, "0");
                    manejo_sesion.Cla = txUsuario.Text;
                    manejo_sesion.Con = txClave.Text;
                    manejo_sesion.MensajeAdvertencia = mensaje;
                    Session["IdSesion"] = HttpContext.Current.Session.SessionID;
                    Session["Sesion"] = manejo_sesion;                        //Asignación temporal de la sesión principal del sistema
                    Response.Redirect("Procesos/Default.aspx", false);
                    //Response.Redirect("Procesos/supervision/capturausuarios.aspx", true);
                }
                else if (validaUsuario == 2)
                {
                    log.Agregar(txUsuario.Text + " ha intentado ingresar al sistema, ha equivocado su clave o intenta accesar sin autorización.");
                    mensajes.MostrarMensaje(this, mensaje);
                }
                else if (validaUsuario == 4)
                {
                    log.Agregar(txUsuario.Text + " intenta ingresar al sistema pero está bloqueado.");
                    LblMensajes.Text = "Acceso del usuario se encuentra bloqueado o contraseña vencida. Contacte al administrador. Intentar de nuevo después de " + manejo_sesion.EsperaBloqueo + " minutos.";
                    LoginButton.Enabled = false;
                    LoginButton.CssClass = "btn-block";
                    Label1.Visible = true;
                    Session["idusuario"] = manejo_sesion.Usuarios.IdUsuario;
                }
                else if (validaUsuario == 5)
                {
                    LblMensajes.Text = "Acceso bloqueado o contraseña vencida. Contacte al administrador.";
                    LoginButton.Enabled = false;
                    LoginButton.CssClass = "btn-block";
                }
                else if (validaUsuario == 0)
                {
                    LblMensajes.Text = "El usuario ya se encuentra conectado en el sistema.";
                }
            }
            catch (Exception ex)
            {
                log.Agregar(ex);
            }
        }

        private void UpdateTimer()
        {
            Label1.Text = DateTime.Now.ToLongTimeString();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //if (0 > DateTime.Compare(DateTime.Now, Funciones.Fechas.ConvertirTextoAFecha(Session["timeout"].ToString())))
            //    Label1.Text = "Quedan " + ((Int32)Funciones.Fechas.ConvertirTextoAFecha(Session["timeout"].ToString()).Subtract(DateTime.Now).TotalMinutes).ToString() + " minutos para desbloquear. <br /> No cierre el navegador.";
            //else
            //{
            //    try
            //    {
            //        i.administracion.usuarios.ActualizarDesconectarSesion(Funciones.Nums.TextoAEntero(Session["idusuario"].ToString()), 0, manejo_sesion.IdParaCierreSesion);
            //        Session["idusuario"] = null;
            //        LblMensajes.Text = "";
            //        Label1.Text = "";
            //        Response.Redirect("Default.aspx", true);
            //    }
            //    catch
            //    {
            //    }
            //}
        }
    }
}