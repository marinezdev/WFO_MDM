using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM.Tablas
{
    public class Catalogos
    {
        ManejoDatos b = new ManejoDatos();

        public List<Propiedades.Listas> OcupacionProfesionClave()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo  UNION ALL SELECT * FROM MDM.dbo.OcupacionProfesionalClave WHERE Activo = 1 ORDER BY Nombre;");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> OcupacionProfesion()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, 1 AS Activo, '000' AS Orden UNION ALL SELECT * FROM MDM.dbo.OcupacionProfesional WHERE Activo = 1 ORDER BY Orden, Nombre");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> Provincia()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo UNION ALL SELECT * FROM MDM.dbo.estadoprovincia WHERE Activo = 1 ORDER BY Nombre; ");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> Preguntas()
        {
            b.ExecuteCommandQuery("SELECT * FROM MDM.dbo.preguntas");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> TipoDocumento()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo  UNION ALL SELECT * FROM MDM.dbo.tipodocumento ORDER BY Nombre");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> SubTipoDocumento()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo  UNION ALL SELECT * FROM MDM.dbo.subtipodocumento ORDER BY Nombre");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }


        public List<Propiedades.Listas> EntidadGubernamentalEmisora()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo  UNION ALL SELECT * FROM MDM.dbo.EntidadGubernamentalEmisora ORDER BY Nombre");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }



        public List<Propiedades.Listas> Pais()
        {
            b.ExecuteCommandQuery("SELECT '0' AS Id, '( SIN INFORMACIÓN )' AS Nombre, '000' AS Orden, 1 AS Activo  UNION ALL SELECT * FROM MDM.dbo.Pais WHERE Activo = 1 ORDER BY Orden, Nombre; ");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> EstadoFinal()
        {
            b.ExecuteCommandQuery("SELECT * FROM MDM.dbo.EstadoFinal WHERE Activo = 1 ORDER BY Nombre;");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<Propiedades.Listas> Comentarios(int MotivoComentario)
        {
            b.ExecuteCommandQuery("SELECT * FROM MDM.dbo.Comentarios WHERE EstadoFinalPadre = " + MotivoComentario.ToString() + " AND Activo = 1 ORDER BY Nombre;");
            List<Propiedades.Listas> resultado = new List<Propiedades.Listas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.Listas item = new Propiedades.Listas()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        
    }
}
