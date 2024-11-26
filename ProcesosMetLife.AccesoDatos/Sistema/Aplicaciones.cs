using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.Sistema
{
    /// <summary>
    /// Acceso a aplicaciones dentro del sistema
    /// </summary>
    public class Aplicaciones
    {
        ManejoDatos b = new ManejoDatos();

        public List<Propiedades.Aplicaciones> Selecionar(string idusuario)
        {
            b.ExecuteCommandQuery("SELECT SuperLogin.dbo.Aplicaciones.Id" +
            ", SuperLogin.dbo.Aplicaciones.Nombre" +
            ", SuperLogin.dbo.Aplicaciones.Descripcion" +
            ", SuperLogin.dbo.Roles.Acceso " +
            "FROM SuperLogin.dbo.UsuarioAplicaciones " +
            "INNER JOIN SuperLogin.dbo.Usuarios ON SuperLogin.dbo.UsuarioAplicaciones.IdUsuario = SuperLogin.dbo.Usuarios.Id " +
            "INNER JOIN SuperLogin.dbo.Aplicaciones ON SuperLogin.dbo.UsuarioAplicaciones.IdAplicacion = SuperLogin.dbo.Aplicaciones.Id " +
            "INNER JOIN SuperLogin.dbo.Roles ON SuperLogin.dbo.UsuarioAplicaciones.IdRol=SuperLogin.dbo.Roles.Id " +
            "WHERE SuperLogin.dbo.Usuarios.Activo = 1 " +
            "AND SuperLogin.dbo.UsuarioAplicaciones.Estado=1 " +
            "AND SuperLogin.dbo.Aplicaciones.Estado = 1 " +
            "AND SuperLogin.dbo.UsuarioAplicaciones.IdUsuario=@idusuario");
            b.AddParameter("@idusuario", idusuario, SqlDbType.Int);
            List<Propiedades.Aplicaciones> resultado = new List<Propiedades.Aplicaciones>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Aplicaciones item = new Propiedades.Aplicaciones()
                {
                    IdAplicacion = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString(),
                    Descripcion = reader["Descripcion"].ToString(),
                    Acceso = reader["Acceso"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    }
}
