<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Captura.aspx.cs" Inherits="ProcesosMetLife.Procesos.MDM.Captura" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

<style>

    td { margin-top:2px; margin-bottom:2px; padding-top: 3px; padding-bottom: 3px}

</style>

     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Captura</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">


                    <div class="col-md-12 col-sm-12 col-xs-12">

                            <asp:Label ID="lblMensajes" runat="server" ForeColor="Red"></asp:Label>
                        <asp:HiddenField ID="hfIdTramite" runat="server" />
                            <table border="0" style="width: 100%;">     
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        No.
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="full-width" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Póliza
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox2" runat="server" CssClass="full-width"  ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        GUID
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="full-width"  ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Lugar de Nacimiento-País
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLLugarNacimientoPais" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Lugar de Nacimiento Estado/Provincia
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox4" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Ciudad/Población
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox5" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Nacionalidad
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox6" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Ocupación o Profesión
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLOcupacionProfesion" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Clave de Ocupación o Profesión
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox7" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Detalle de Ocupación ó Profesión
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox8" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Ingreso mensual aproximado (pesos)
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox9" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        # aproximado de transacciones anuales-aportaciones
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox10" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        # aproximado de transacciones anuales-retiros
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox11" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Monto aproximado de transacciones-aportaciones
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox12" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Monto aproximado de transacciones-retiros
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox13" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trFirma">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        ¿Está sujeto al pago de impuestos en el extranjero?
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDL1" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="trIdentificacion">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Pago de impuestos en el extranjero-País
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox14" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSumaAsegurada">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Número de Seguridad Social ó número de identificación de impuestos
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox15" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trImporte">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        ¿Desempeña o ha desempeñado Usted, su conyúge o un familiar funciones públicas destacadas en territorio nacional o extranjero?
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDL2" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSello">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        En caso de tener nacionalidad extranjera o tener residencia en el extranjero, especifica las razones por las cuales es de tu interés la contratación de un seguro en territorio nacional-Razones
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox16" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trSelloPromo">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Nivel de Riesgo
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox17" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="trMontoActual">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Limitar el uso o divulgación o transferencia de datos
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDL3" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr1">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Tipo de Documento
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLTipoDocumento" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr2">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        SubTipo de Documento
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLSubTipoDocumento" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr3">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Referencia del Documento
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox18" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>                           
                                <tr runat="server" id="tr4">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Fecha de Emisión
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox19" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>                                                
                                <tr runat="server" id="tr5">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Fecha de Vigencia
                                    </td>
                                    </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox20" runat="server" CssClass="full-width"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr6">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Entidad Gubernamental Emisora
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLEntidadGubernamentalEmisora" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr7">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        País Emisor
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLPaisEmisor" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr8">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Contador
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:TextBox ID="TextBox21" runat="server" CssClass="full-width" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr runat="server" id="tr9">
                                    <td style="width:35%; background-color:#1572B7; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        Eliminar
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                        <asp:DropDownList ID="DDLEliminar" runat="server" CssClass="full-width"></asp:DropDownList>
                                    </td>
                                </tr>
                            </table>

                    </div>


                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12 text-left">
                            <div class="x_panel">
                                <div class="x_title">
                                    <h2><small>Acciones </small> </h2>
                                    <ul class="nav navbar-right panel_toolbox">
                                        <li>
                                            <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                      	                </li>
                                    </ul>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="x_content text-left" >
                                    <div class="row">
                                        <div class="control-label col-md-5 col-sm-5 col-xs-12">
                                            <strong>OBSERVACIONES PRIVADAS</strong>
                                            <asp:TextBox ID="txtObservacionesPrivadas" runat="server" class="form-control" TextMode="MultiLine" Rows="5" AutoPostBack="false" onkeypress="return soloLetras(event)" onKeyUp="document.getElementById(this.id).value=document.getElementById(this.id).value.toUpperCase()"></asp:TextBox>
                                            <br />
                                        </div>
                                        <div class="control-label col-md-7 col-sm-12 col-xs-12">
                                            <div class="row">
                                                <code><asp:Label runat="server" ID="Mensajes" Text=""></asp:Label></code>
                                            </div>
                                            <div class="row">
                                                <asp:Button ID="btnAceptarObs" runat="server" Text="Aceptar" class="btn btn-success col-md-5 col-sm-5 col-xs-12" OnClick="BotonPresionado_Click" />
                                                <asp:Button ID="btnAceptar" runat="server" Text="Guardar" class="btn btn-success col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Guardar" data-target=".confirmacion" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnSelccionCompleta" runat="server" Text="Sel Completa" class="btn btn-warning col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionSeleccionCompleta" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnPCI" runat="server" Text="P C I" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionPCI" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnHold" runat="server" Text="Hold" class="btn btn-warning col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnSuspender" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <!--
                                                    <button type="button" class="btn btn-info col-md-3 col-sm-3 col-xs-12" data-toggle="modal" title="Enviar a Mesa" data-target=".mSendToMesa">Enviar a Mesa</i></button>
                                                -->
                                            </div>
                                            <div class="row">
                                                <asp:Button ID="btnPausa" runat="server" Text="Pausa de Trámite" class="btn btn-danger col-md-5 col-sm-5 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnDetener" runat="server" Text="Pausa de Usuario" class="btn btn-warning col-md-5 col-sm-5 col-xs-12" OnClick="BotonPresionado_Click"/>
                                            </div>
                                        </div>
                                        </div>
                        
                                    </div>
                                <div class="row">
                                    <div class="control-label col-md-5 col-sm-5 col-xs-12">
                                        <button type="button" class="btn btn-default col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Bitácora publica" data-target=".BitacoraPublica"><i class="fa fa-unlock-alt"></i></button>
                                        <button type="button" class="btn btn-default col-md-2 col-sm-2 col-xs-12" data-toggle="modal" title="Bitácora privada" data-target=".BitacoraPrivada"><i class="fa fa-lock"></i> </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                </div>
            </div>
        </div>
     </div>
</asp:Content>