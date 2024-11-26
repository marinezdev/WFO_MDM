using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using prop = ProcesosMetLife.Propiedades.Procesos.SupervisionGeneral;
using f = ProcesosMetLife.Funciones;

namespace ProcesosMetLife.AccesoDatos.ISSSTE.SupervisionGeneral
{
    public class Tramite
    {
        ManejoDatos b = new ManejoDatos();

        public List<prop.Tramite> Seleccionar()
        {
            b.ExecuteCommandSP("Tramite_Seleccionar");
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id              = reader["Id"].ToString(),
                    Folio           = reader["Folio"].ToString(),
                    IdTipoTramite   = reader["IdTipoTramite"].ToString(),
                    TipoTramite     = reader["TipoTramite"].ToString(),
                    FechaRegistro   = reader["FechaRegistro"].ToString(),
                    FechaTermino    = reader["FechaTermino"].ToString(),
                    FechaSolicitud  = reader["FechaSolicitud"].ToString(),
                    IdPromotoria    = reader["IdPromotoria"].ToString(),
                    Promotoría      = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus        = reader["IdStatus"].ToString(),
                    Status          = reader["Status"].ToString(),
                    IdUsuario       = reader["IdUsuario"].ToString(),
                    IdAgente        = reader["IdAgente"].ToString(),
                    NumeroOrden     = reader["NumeroOrden"].ToString(),
                    IdPrioridad     = reader["IdPrioridad"].ToString(),
                    Prioridad       = reader["Prioridad"].ToString(),
                    IdSisLegados    = reader["IdSisLegados"].ToString(),
                    Kwik            = reader["Kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public prop.Tramite SeleccionarPorId(string id)
        {
            b.ExecuteCommandSP("Tramite_Seleccionar_PorId ");
            b.AddParameter("@id", id, SqlDbType.Int);
            prop.Tramite resultado = new prop.Tramite();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                resultado.Id              = reader["id"].ToString();
                resultado.IdTipoTramite   = reader["idtipotramite"].ToString();
                resultado.FechaRegistro   = reader["fecharegistro"].ToString();
                resultado.FechaTermino    = reader["fechatermino"].ToString();
                resultado.IdStatus        = reader["idstatus"].ToString();
                resultado.IdPromotoria    = reader["idpromotoria"].ToString();
                resultado.IdUsuario       = reader["idusuario"].ToString();
                resultado.IdAgente        = reader["idagente"].ToString();
                resultado.NumeroOrden     = reader["numeroorden"].ToString();
                resultado.FechaSolicitud  = reader["fechasolicitud"].ToString();
                resultado.IdPrioridad     = reader["idprioridad"].ToString();
                resultado.IdSisLegados    = reader["idsislegados"].ToString();
                resultado.Kwik            = reader["kwik"].ToString();
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Tramite> Buscar(string foliocompuesto, string fecharegistrodel, string fecharegistroal, string fechasolicituddel, string fechasolicitudal, string idpromotoria, string estado)
        {
            string folio = "%" + foliocompuesto + "%";
            b.ExecuteCommandSP("Tramite_Seleccionar_Buscar");
            b.AddParameter("@foliocompuesto", folio == "%%" ? DBNull.Value : (Object)folio, SqlDbType.VarChar, 20);
            b.AddParameter("@fecharegistrodel",  fecharegistrodel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistrodel), SqlDbType.VarChar);
            b.AddParameter("@fecharegistroal", fecharegistroal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fecharegistroal), SqlDbType.VarChar);
            b.AddParameter("@fechasolicituddel", fechasolicituddel == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicituddel), SqlDbType.VarChar);
            b.AddParameter("@fechasolicitudal", fechasolicitudal == "" ? "" : Funciones.Fechas.PrepararFechaParaBusqueda(fechasolicitudal), SqlDbType.VarChar);
            b.AddParameter("@idpromotoria", idpromotoria == "0" ? DBNull.Value : (Object)idpromotoria, SqlDbType.Int);
            b.AddParameter("@estado", estado == "0" ? DBNull.Value : (Object)estado, SqlDbType.Int);

            List <prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = reader["Id"].ToString(),
                    Folio = reader["Folio"].ToString(),
                    IdTipoTramite = reader["IdTipoTramite"].ToString(),
                    TipoTramite = reader["TipoTramite"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    FechaTermino = reader["FechaTermino"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    IdPromotoria = reader["IdPromotoria"].ToString(),
                    Promotoría = reader["Promotoria"].ToString(),
                    ClavePromotoria = reader["ClavePromotoria"].ToString(),
                    IdStatus = reader["IdStatus"].ToString(),
                    Status = reader["Status"].ToString(),
                    IdUsuario = reader["IdUsuario"].ToString(),
                    IdAgente = reader["IdAgente"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    IdPrioridad = reader["IdPrioridad"].ToString(),
                    Prioridad = reader["Prioridad"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    Kwik = reader["Kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataTable SeleccionarTramitesPorMesa(string fase)
        {
            b.ExecuteCommandSP("Tramite_EstadosMesa");
            b.AddParameter("@fase", Int32.Parse(fase), SqlDbType.Int);
            return b.Select();
        }

        public DataTable ListadoTramitesOperacion()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN1");
            return b.Select();
        }

        public DataTable ListadoTramitesOperacionN3()
        {
            b.ExecuteCommandSP("spListadoTramitesOperacionN3");
            return b.Select();
        }

        public DataTable SeleccionarTramiteConsultaX()
        {
            b.ExecuteCommandSP("Tramites_Seleccionar_ConsultaX");
            return b.Select();
        }

        public int ModificarPrioridad(string id)
        {
            b.ExecuteCommandSP("Tramite_Modificar_Prioridad");
            b.AddParameter("@id", id, SqlDbType.Int);
            return b.InsertUpdateDelete();
        }

        public List<prop.Tramite> TramiteSupervicionGeneralSelecionar(int Id, DateTime Fecha_Inicio, DateTime Fecha_Termino, string Folio, string RFC, string Nombre, string ApPaterno, string ApMaterno)
        {
            b.ExecuteCommandSP("Tramite_SupervicionGeneral_Selecionar_PorIdUsuario");
            b.AddParameter("@IdUsuario", Id, SqlDbType.Int);
            b.AddParameter("@Fecha_Inicio", Fecha_Inicio, SqlDbType.DateTime);
            b.AddParameter("@Fecha_Termino", Fecha_Termino, SqlDbType.DateTime);
            b.AddParameter("@Folio", Folio, SqlDbType.NVarChar);
            b.AddParameter("@RFC", RFC, SqlDbType.NVarChar);
            b.AddParameter("@Nombre", Nombre, SqlDbType.NVarChar);
            b.AddParameter("@ApPaterno", ApPaterno, SqlDbType.NVarChar);
            b.AddParameter("@ApMaterno", ApMaterno, SqlDbType.NVarChar);
            List<prop.Tramite> resultado = new List<prop.Tramite>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                prop.Tramite item = new prop.Tramite()
                {
                    Id = reader["Id"].ToString(),
                    FechaRegistro = reader["FechaRegistro"].ToString(),
                    Folio = reader["FolioCompuesto"].ToString(),
                    NumeroOrden = reader["NumeroOrden"].ToString(),
                    Operacion = reader["Operacion"].ToString(),
                    Producto = reader["Producto"].ToString(),
                    Contratante = reader["Contratante"].ToString(),
                    RFC = reader["RFC"].ToString(),
                    Titular = reader["Titular"].ToString(),
                    FechaSolicitud = reader["FechaSolicitud"].ToString(),
                    Status = reader["Estatus"].ToString(),
                    IdSisLegados = reader["IdSisLegados"].ToString(),
                    Kwik = reader["kwik"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public bool EnlaceListadoActivar(string Quincena, string TipoNomina, int IdAplicarEnlace)
        {
            bool resultado = false;
            b.ExecuteCommandSP("Tramites_Enlace_Aplicar");
            b.AddParameter("@IdAplicarEnlace", IdAplicarEnlace, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["resultado"].ToString() == "1")
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataSet EnlaceGenerar(string Quincena, string TipoNomina)
        {
            try
            {
                b.ExecuteCommandSP("Tramites_Enlace_Generar");
                b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar, 6);
                b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar, 2);
            }
            catch (Exception ex)
            {
                string Error = ex.Message.ToString();
            }
            
            return b.SelectExecuteFunctions();
        }

        public bool ExtraccionDuplicadosDelete(string Quincena, string TipoNomina, int IdExtraccion, int IdUsuario)
        {
            bool resultado = false;
            b.ExecuteCommandSP("Tramites_Obtener_ExtraccionDuplicadosDelete");
            b.AddParameter("@IdExtraccion", IdExtraccion, SqlDbType.Int);
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                if (reader["RESULTADO"].ToString() == "1")
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public List<prop.Extraccion> ExtraccionDuplicados(string Quincena, string TipoNomina)
        {
            b.ExecuteCommandSP("Tramites_Obtener_ExtraccionDuplicados");
            b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar, 2);
            b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar, 6);
            List<prop.Extraccion> resultado = new List<prop.Extraccion>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    prop.Extraccion item = new prop.Extraccion()
                    {
                        Id = reader["ID"].ToString(),
                        Matricula = reader["MATRICULA"].ToString(),
                        Poliza = reader["POLIZA"].ToString(),
                        TipoMovimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                        TipoNomina = reader["ANO_QUINCENA"].ToString(),
                        Quincena = reader["TIPO_NOMINA"].ToString(),
                        Trabajador = reader["NOMBRE_TRABAJADOR"].ToString(),
                        Importe = reader["IMPORTE"].ToString()
                    };
                    resultado.Add(item);
                }
                catch (Exception ex)
                {
                    string error = ex.Message.ToString();
                }
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }
    
        public List<prop.EnlaceListado> EnlaceListado(string Quincena, string TipoNomina)
        {
                b.ExecuteCommandSP("Tramites_Obtener_EnlaceAplicable");
                b.AddParameter("@TipoNomina", TipoNomina, SqlDbType.VarChar,2);
                b.AddParameter("@Quincena", Quincena, SqlDbType.VarChar,6);
                List<prop.EnlaceListado> resultado = new List<prop.EnlaceListado>();
                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        prop.EnlaceListado item = new prop.EnlaceListado()
                        {
                            EnlaceClave = reader["EnlaceClave"].ToString(),
                            TipoPrestamo = reader["Tipo de Prestamo"].ToString(),
                            Matricula = reader["Matrícula"].ToString(),
                            Concepto = reader["Concepto"].ToString(),
                            Importe = reader["Importe"].ToString(),
                            Plazo = reader["Plazo"].ToString(),
                            NumeroControl = reader["Numero de Control"].ToString(),
                            NumeroCredito = reader["Numero de Crédito (Póliza)"].ToString(),
                            CifraControl = reader["Cifra Control (Importe)"].ToString(),
                            TipoMovimiento = reader["Tipo de Movimiento"].ToString(),
                            NombreTrabajador = reader["Nombre del Trabajador"].ToString(),
                            Retenedor = reader["Numero de Provedor (Retenedor)"].ToString(),
                            Caracter = reader["Carácter"].ToString(),
                            AplicaEnlace = bool.Parse(reader["APLICAENLACE"].ToString())
                        };
                        resultado.Add(item);
                    }
                    catch (Exception ex)
                    {
                        string error = ex.Message.ToString();
                    }
                }
                reader = null;
                b.ConnectionCloseToTransaction();
                return resultado;
            }
    }
}
