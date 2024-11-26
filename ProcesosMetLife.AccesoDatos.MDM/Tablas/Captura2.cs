using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcesosMetLife.AccesoDatos.MDM.Tablas
{
    public class Captura2
    {
        internal ManejoDatos b { get; set; } = new ManejoDatos();

        /// <summary>
        /// Actualiza los datos de un trámite con la información capturada
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool Guardar(Propiedades.Extraccion_MDM items, string TablaNombre)
        {
            bool bCaptura = false;

            b.ExecuteCommandQuery("INSERT INTO MDM.dbo." + TablaNombre + " " +
            "(Fecha" +
            ",IdUsuario " +
            ",Numero  " +
            ",Poliza " +
            ",Guid_ " +
            ",PaisNacimiento " +
            ",EstadoNacimiento " +
            ",Ciudad " +
            ",Nacionalidad " +
            ",Ocupacion " +
            ",ClaveOcupacion " +
            ",DetalleOcupacion " +
            ",IngresoMensual " +
            ",TransaccionesAnualesAportaciones " +
            ",TransaccionesAnualesRetiros " +
            ",TransaccionesAportaciones " +
            ",TransaccionesRetiros " +
            ",PagoImpuestosExtranjero " +
            ",PagoImpuestosExtranjeroPais " +
            ",NSS " +
            ",DesempeñoDestacado " +
            ",RazonesContratacion " +
            ",NivelRiesgo " +
            ",LimitarDivulgacion " +
            ",Tipodocumento " +
            ",SubtipoDocumento " +
            ",Referencia " +
            ",FechaEmision " +
            ",FechaVigencia " +
            ",EntidadGubernamentalEmisora " +
            ",PaisEmisor " +
            ",Contador " +
            ",Eliminar " +
            ",EstadoFinal " +
            ",Comentarios " +
            ",UsuarioCaptura2)" +
            "VALUES (" +
            "getdate()" +
            "," + items.idusuario + " " +
            ",'" + items.Numero + "' " +
            ",'" + items.Poliza + "' " +
            ",'" + items.GUID_ + "' " +
            ",'" + items.PaisNacimiento + "' " +
            ",'" + items.EstadoNacimiento + "' " +
            ",'" + items.Ciudad + "' " +
            ",'" + items.Nacionalidad + "' " +
            ",'" + items.Ocupacion + "' " +
            ",'" + items.ClaveOcupacion + "' " +
            ",'" + items.DetalleOcupacion + "' " +
            ",'" + items.IngresoMensual + "' " +
            ",'" + items.TransaccionesAnualesAportaciones + "' " +
            ",'" + items.TransaccionesAnualesRetiros + "' " +
            ",'" + items.TransaccionesAportaciones + "' " +
            ",'" + items.TransaccionesRetiros + "' " +
            ",'" + items.PagoImpuestosExtranjero + "' " +
            ",'" + items.PagoImpuestosExtranjeroPais + "' " +
            ",'" + items.NSS + "' " +
            ",'" + items.DesempeñoDestacado + "' " +
            ",'" + items.RazonesContratacion + "' " +
            ",'" + items.NivelRiesgo + "' " +
            ",'" + items.LimitarDivulgacion + "' " +
            ",'" + items.Tipodocumento + "' " +
            ",'" + items.SubtipoDocumento + "' " +
            ",'" + items.Referencia + "' " +
            ",'" + items.FechaEmision + "' " +
            ",'" + items.FechaVigencia + "' " +
            ",'" + items.EntidadGubernamentalEmisora + "' " +
            ",'" + items.PaisEmisor + "' " +
            ",'" + items.Contador + "' " +
            ",'" + items.Eliminar + "' " +
            ",'" + items.EstadoFinal + "' " +
            ",'" + items.Comentarios + "' " +
            ", " + items.idusuario + "" +
            ")"
            );
            //b.AddParameter("@idusuario", items.IdUsuario, SqlDbType.Int);
            //b.AddParameter("@no", items.Numero, SqlDbType.NVarChar);
            //b.AddParameter("@poliza", items.Poliza, SqlDbType.NVarChar);
            //b.AddParameter("@guid", items.GUID_, SqlDbType.NVarChar);
            //b.AddParameter("@paisnacimiento", items.PaisNacimiento, SqlDbType.NVarChar);
            //b.AddParameter("@estadonacimiento", items.EstadoNacimiento, SqlDbType.NVarChar);
            //b.AddParameter("@ciudad", items.Ciudad, SqlDbType.NVarChar);
            //b.AddParameter("@nacionalidad", items.Nacionalidad, SqlDbType.NVarChar);
            //b.AddParameter("@ocupacion", items.Ocupacion, SqlDbType.NVarChar);
            //b.AddParameter("@claveocupacion", items.ClaveOcupacion, SqlDbType.NVarChar);
            //b.AddParameter("@detalleocupacion", items.DetalleOcupacion, SqlDbType.NVarChar);
            //b.AddParameter("@ingresomensual", items.IngresoMensual, SqlDbType.NVarChar);
            //b.AddParameter("@transaccionesanualesaportaciones", items.TransaccionesAnualesAportaciones, SqlDbType.NVarChar);
            //b.AddParameter("@transaccionesanualesretiros", items.TransaccionesAnualesRetiros, SqlDbType.NVarChar);
            //b.AddParameter("@transaccionesaportaciones", items.TransaccionesAportaciones, SqlDbType.NVarChar);
            //b.AddParameter("@transaccionesretiros", items.TransaccionesRetiros, SqlDbType.NVarChar);
            //b.AddParameter("@pagoimpuestosextranjero", items.PagoImpuestosExtranjero, SqlDbType.NVarChar);
            //b.AddParameter("@pagoimpuestosextranjeropais", items.PagoImpuestosExtranjeroPais, SqlDbType.NVarChar);
            //b.AddParameter("@nss", items.NSS, SqlDbType.NVarChar);
            //b.AddParameter("@desempeñodestacado", items.DesempeñoDestacado, SqlDbType.NVarChar);
            //b.AddParameter("@razonescontratacion", items.RazonesContratacion, SqlDbType.NVarChar);
            //b.AddParameter("@nivelriesgo", items.NivelRiesgo, SqlDbType.NVarChar);
            //b.AddParameter("@limitardivulgacion", items.LimitarDivulgacion, SqlDbType.NVarChar);
            //b.AddParameter("@tipodocumento", items.Tipodocumento, SqlDbType.NVarChar);
            //b.AddParameter("@subtipodocumento", items.SubtipoDocumento, SqlDbType.NVarChar);
            //b.AddParameter("@referencia", items.Referencia, SqlDbType.NVarChar);
            //b.AddParameter("@fechaemision", items.FechaEmision, SqlDbType.NVarChar);
            //b.AddParameter("@fechavigencia", items.FechaVigencia, SqlDbType.NVarChar);
            //b.AddParameter("@entidadgubernamentalemisora", items.EntidadGubernamentalEmisora, SqlDbType.NVarChar);
            //b.AddParameter("@paisemisor", items.PaisEmisor, SqlDbType.NVarChar);
            //b.AddParameter("@contador", items.Contador, SqlDbType.NVarChar);
            //b.AddParameter("@eliminar", items.Eliminar, SqlDbType.NVarChar);
            //b.AddParameter("@usuariocaptura2", items.idusuario, SqlDbType.Int);

            if (b.InsertUpdateDelete() > 0)
            {
                b.ExecuteCommandSP("spWFOTramiteProcesar");
                b.AddParameter("@IdTramite", items.idtramite, SqlDbType.Int);
                b.AddParameter("@IdMesa", items.idmesa, SqlDbType.Int);
                b.AddParameter("@IdUsuario", items.idusuario, SqlDbType.Int);
                b.AddParameter("@IdStatusMesa", items.idstatusmesa, SqlDbType.Int);
                b.AddParameter("@ObservacionPub", items.obspub.Replace(System.Environment.NewLine, ""), SqlDbType.VarChar);
                b.AddParameter("@ObservacionPriv", items.obspri.Replace(System.Environment.NewLine, ""), SqlDbType.VarChar);
                b.AddParameter("@MotivosRechazo", items.motivosrechazo, SqlDbType.VarChar);

                //List<prop.TramiteProcesado> resultado = new List<prop.TramiteProcesado>();
                var reader = b.ExecuteReader();
                while (reader.Read())
                {
                    string strIdTramite = "";
                    string strAccion = "";

                    strIdTramite = reader["IdTramite"].ToString();
                    strAccion = reader["Accion"].ToString();

                    //prop.TramiteProcesado item = new prop.TramiteProcesado()
                    //{
                    //    IdTramite = Convert.ToInt32(reader["IdTramite"].ToString()),
                    //    Accion = reader["Accion"].ToString(),
                    //};
                    //resultado.Add(item);


                    // regresamos true
                    bCaptura = true;
                }
                reader = null;
                b.ConnectionCloseToTransaction();
                //return resultado;
            }
            else
            {
                bCaptura = false;
            }

            return bCaptura;
        }

        public DataTable SeleccionarTramitesPorMesa(int IdFlujo)
        {
            b.ExecuteCommandSP("MDM.DBO.Tramites_Totales");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            return b.Select();
        }
         
        public List<Propiedades.MDMEntregas> getMDMEntregasaCaptura()
        {
            b.ExecuteCommandSP("MDM.dbo.getMDMEntregas");
            List<Propiedades.MDMEntregas> resultado = new List<Propiedades.MDMEntregas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.MDMEntregas item = new Propiedades.MDMEntregas()
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

        public List<Propiedades.MDMEntregas> getMDMEntregas()
        {
            b.ExecuteCommandSP("MDM.dbo.getMDMEntregas");
            List<Propiedades.MDMEntregas> resultado = new List<Propiedades.MDMEntregas>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.MDMEntregas item = new Propiedades.MDMEntregas()
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

        public List<Propiedades.UsuariosFlujos> SelecionarFlujo(int IdUsuario)
        {
            b.ExecuteCommandSP("UsuariosFlujo_Seleccionar_PorIdUsuario");
            b.AddParameter("@IdUsuario", IdUsuario, SqlDbType.Int);
            List<Propiedades.UsuariosFlujos> resultado = new List<Propiedades.UsuariosFlujos>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.UsuariosFlujos item = new Propiedades.UsuariosFlujos()
                {
                    Id = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    nombre = reader["Nombre"].ToString()
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

        public DataSet getCapturaUsuario(DateTime FInicio, DateTime FTermino)
        {
            b.ExecuteCommandSP("getCapturaUsuario");
            b.AddParameter("@FechaInicio", FInicio, SqlDbType.DateTime);
            b.AddParameter("@FechaTermino", FTermino, SqlDbType.DateTime);
            DataSet dsResultado = b.SelectExecuteFunctions();
            b.ConnectionCloseToTransaction();
            return dsResultado;
        }

        public DataSet getCapturaUsuarioDiario(DateTime FInicio, DateTime FTermino)
        {
            b.ExecuteCommandSP("getCapturaUsuarioDiario");
            b.AddParameter("@FechaInicio", FInicio, SqlDbType.DateTime);
            b.AddParameter("@FechaTermino", FTermino, SqlDbType.DateTime);
            DataSet dsResultado = b.SelectExecuteFunctions();
            b.ConnectionCloseToTransaction();
            return dsResultado;
        }


        public List<Propiedades.MapaGeneral> getDashboard(int IdFlujo)
        {
            b.ExecuteCommandSP("spWFOMapaGeneral");
            b.AddParameter("@IdFlujo", IdFlujo, SqlDbType.Int);
            List<Propiedades.MapaGeneral> resultado = new List<Propiedades.MapaGeneral>();
            var reader = b.ExecuteReader();
            while (reader.Read())
            {
                Propiedades.MapaGeneral item = new Propiedades.MapaGeneral()
                {
                    IdMesa = Funciones.Nums.TextoAEntero(reader["Id"].ToString()),
                    Mesa = reader["Nombre"].ToString(),
                    Icono = reader["Icono"].ToString(),
                    UsuariosConectados = Funciones.Nums.TextoAEntero(reader["UsuariosDisponibles"].ToString()),
                    TramitesDisponibles = Funciones.Nums.TextoAEntero(reader["TramitesDisponibles"].ToString()),
                    TramitesReingresos = Funciones.Nums.TextoAEntero(reader["TramitesReingresos"].ToString())
                };
                resultado.Add(item);
            }
            reader = null;
            b.ConnectionCloseToTransaction();
            return resultado;
        }

    }
}
