using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.Negocio.Sistema
{
    public class Login
    {
        AccesoDatos.Sistema.Usuarios usuarios = new AccesoDatos.Sistema.Usuarios();

        public int Autenticar(string clave, string contraseña, ref string mensaje)
        {
            int salida = 0;

            var obtenido = usuarios.Validar(clave, contraseña);
            if (obtenido[0].ToString() == "1")
                salida = 1;
            else if (obtenido[0].ToString() == "2")
            {
                mensaje = obtenido[1].ToString();
                salida = 2;
            }
            else if (obtenido[0].ToString() == "3")
            {
                mensaje = obtenido[1].ToString();
                salida = 3;
            }
            else if (obtenido[0].ToString() == "4")
            {
                mensaje = obtenido[1].ToString();
                salida = 4;
            }
            else if (obtenido[0].ToString() == "5")
            {
                mensaje = obtenido[1].ToString();
                salida = 5;
            }

            return salida;
        }

        public void Autorizar(string clave, string contraseña, IU.ManejadorSesion sesion, string app)
        {
            usuarios.Autorizar(clave, contraseña, sesion, app);
        }

    }
}
