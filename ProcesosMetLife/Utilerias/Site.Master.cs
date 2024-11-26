using System;
using System.Web.UI;

namespace ProcesosMetLife
{
    public partial class SiteMaster : MasterPage
    {
        IU.ManejadorSesion manejo_sesion = new IU.ManejadorSesion();
        Utilerias.Comun cm = new Utilerias.Comun();


        protected void Page_Load(object sender, EventArgs e)
        {
           if (Session["Sesion"] == null)
                Response.Redirect("..\\.");

            manejo_sesion = (IU.ManejadorSesion)Session["Sesion"];
            LblNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
            LblTextNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
            Utilerias.Comun cm = new Utilerias.Comun();
            LblMenu.Text = manejo_sesion.Menu; //Ahora se asigna el menu directamente en la página maestra
            if (string.IsNullOrEmpty(manejo_sesion.MensajeAdvertencia))
            {
                LblNombreUsuario.Text = manejo_sesion.Usuarios.Nombre;
                LblTextNombreUsuario.Text = "Usuario: " + manejo_sesion.Usuarios.Nombre;
            }
            else
            {
                LblNombreUsuario.Text = manejo_sesion.MensajeAdvertencia + ", Usuario: " + manejo_sesion.Usuarios.Nombre;
                LblNombreUsuario.ForeColor = System.Drawing.Color.Red;
                LblNombreUsuario.Font.Bold = true;
            }
        }

        protected void BtnSalirSistema_Click(object sender, EventArgs e)
        {
            Negocio.Sistema.Usuarios sisusr = new Negocio.Sistema.Usuarios();
            if (manejo_sesion.Salida == 0)
            {
                //Salida de alguna aplicación que se usaba
                sisusr.RegistroLog(Session["IdSesion"].ToString(), Session["idusuario"].ToString(), Session["Inicio"].ToString(), 0);
                sisusr.ActualizarDesconectarSesion(manejo_sesion.Usuarios.IdUsuario, 0, manejo_sesion.IdParaCierreSesion);
                Response.Redirect("~/Procesos/Default.aspx", true);
            }
            else
            {
                //Salida del sistema
                sisusr.RegistroLog(Session["IdSesion"].ToString(), Session["idusuario"].ToString(), Session["Inicio"].ToString(), 0);
                sisusr.ActualizarDesconectarSesion(int.Parse(Session["idusuario"].ToString()), 0, manejo_sesion.IdParaCierreSesion);
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
                Server.ClearError();
                Response.Redirect("~/Default.aspx");
            }

        }
    }
}