<%@ Page Title="" Language="C#" MasterPageFile="~/Utilerias/Site.Master" AutoEventWireup="true" CodeBehind="TramiteProcesar.aspx.cs" Inherits="ProcesosMetLife.Procesos.MDM.Operador.TramiteProcesar" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.Web.v17.2, Version=17.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <script type="text/javascript">
       
    </script>

    <style>
        td { margin-top:2px; margin-bottom:2px; padding-top: 3px; padding-bottom: 3px}
    </style>

    <!-- MODAL DE CONFIRMACION -->
    <div class="modal fade confirmacion" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-sm">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    <h4 class="modal-title" id="myModalLabel5">Procesar Trámite</h4>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col-md-12 col-sm-12 col-xs-12">
                            <br />&nbsp;
                            ¿Seguro de que desea guardar la captura del trámite?
                            <br />&nbsp;
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnAceptar" runat="server" Text="Guardar" class="btn btn-success" OnClick="BotonPresionado_Click"/>
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblTitulo" runat="server"></asp:Label>
                    </h2>
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
                        <asp:HiddenField ID="hfIdMesa" runat="server" />
                        <asp:HiddenField ID="hfIdFlujo" runat="server" />
                        
                        <table border="0" style="width: 100%;">     
                            <tr>
                                <td style="background-color:#26B99A; width:32%; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    No.
                                </td>
                                <td style="background-color:#26B99A; width:2%; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; width:32%; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Póliza
                                </td>
                                <td style="background-color:#26B99A; width:2%; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; width:32%; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    GUID
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="full-width" ReadOnly="true"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender7" runat="server" TargetControlID="TextBox1" FilterMode="ValidChars" ValidChars="1234567890/SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="full-width"  ReadOnly="true"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender8" runat="server" TargetControlID="TextBox2" FilterMode="ValidChars" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZ/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="full-width"  ReadOnly="true"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender9" runat="server" TargetControlID="TextBox3" FilterMode="ValidChars" ValidChars="1234567890/SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Lugar de Nacimiento-País
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Lugar de Nacimiento Estado/Provincia
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Ciudad/Población
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboLugarNaciomientoPais" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboLugarNacimientoProvincia" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender10" runat="server" TargetControlID="TextBox5" FilterMode="ValidChars" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Nacionalidad
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Ocupación o Profesión
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Clave de Ocupación o Profesión
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboNacionalidad" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboOcupacionProfesion" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboOcupacionProfesionClave" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Detalle de Ocupación ó Profesión
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Ingreso mensual aproximado (pesos)
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    # aproximado de transacciones anuales-aportaciones
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server" TargetControlID="TextBox8" FilterMode="ValidChars" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="TextBox9" FilterMode="ValidChars" ValidChars="1234567890./SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="TextBox10" FilterMode="ValidChars" ValidChars="1234567890/SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    # aproximado de transacciones anuales-retiros
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Monto aproximado de transacciones-aportaciones
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Monto aproximado de transacciones-retiros
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox11" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="TextBox11" FilterMode="ValidChars" ValidChars="1234567890/SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox12" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="TextBox12" FilterMode="ValidChars" ValidChars="1234567890./SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox13" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="TextBox13" FilterMode="ValidChars" ValidChars="1234567890./SN"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    ¿Está sujeto al pago de impuestos en el extranjero?
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Pago de impuestos en el extranjero-País
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <!--Número de Seguridad Social ó número de identificación de impuestos-->
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDL1" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="ddlPagoExtrangero" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox15" runat="server" CssClass="full-width" Text="XXXX" Visible="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender11" runat="server" TargetControlID="TextBox15" FilterMode="ValidChars" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú._-/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    ¿Desempeña o ha desempeñado Usted, su conyúge o un familiar funciones públicas destacadas en territorio nacional o extranjero?
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    En caso de tener nacionalidad extranjera o tener residencia en el extranjero, especifica las razones por las cuales es de tu interés la contratación de un seguro en territorio nacional-Razones
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Nivel de Riesgo
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDL2" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="ddlNacionalidadExtrangera" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox17" runat="server" CssClass="full-width" Text="BAJO RIESGO" Enabled="false"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender12" runat="server" TargetControlID="TextBox17" FilterMode="ValidChars" ValidChars="abcdefghijklmnñopqrstuvwxyz ABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Limitar el uso o divulgación o transferencia de datos
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Tipo de Documento
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    SubTipo de Documento
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDL3" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboTipoDocumento" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboSubTipoDocumento" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Referencia del Documento
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Fecha de Emisión
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Fecha de Vigencia
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox18" runat="server" CssClass="full-width"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="validador1" runat="server" TargetControlID="TextBox18" FilterMode="ValidChars" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú._-/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxDateEdit ID="dtFechaInicial" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="">
                                        <TimeSectionProperties>
                                            <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                        </TimeSectionProperties>
                                        <CalendarProperties>
                                            <FastNavProperties DisplayMode="Inline" />
                                        </CalendarProperties>
                                    </dx:ASPxDateEdit>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxDateEdit ID="dtFechaFinal" runat="server" Theme="Material" EditFormat="Custom" Width="100%" Caption="">
                                        <TimeSectionProperties>
                                            <TimeEditProperties EditFormatString="dd/MM/yyyy" />
                                        </TimeSectionProperties>
                                        <CalendarProperties>
                                            <FastNavProperties DisplayMode="Inline" />
                                        </CalendarProperties>
                                    </dx:ASPxDateEdit>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Entidad Gubernamental Emisora
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    País Emisor
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <!--Contador--> &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboEntidadGubernamentalEmisora" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <dx:ASPxComboBox 
                                        runat="server" 
                                        ID="cboPaisEmisor" 
                                        DropDownStyle="DropDownList" 
                                        IncrementalFilteringMode="Contains"
                                        TextField="Nombre" 
                                        ValueField="Id" 
                                        Width="100%" 
                                        EnableSynchronization="False"
                                        BackColor="White"
                                        >
                                    </dx:ASPxComboBox>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:TextBox ID="TextBox21" runat="server" CssClass="full-width" Text="0" Visible ="false" ></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender13" runat="server" TargetControlID="TextBox21" FilterMode="ValidChars" ValidChars="1234567890abcdefghijklmnñopqrstuvwxyzABCDEFGHIJKLMNÑOPQRSTUVWXYZáéíóú._-/"></ajaxToolkit:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
                            <tr style="display:none;">
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Eliminar
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                            </tr>
                            <tr style="display:none;">
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDLEliminar" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                            </tr>
                            <tr style="display:none;"><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>

                            <tr>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Estado Final
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    Comentarios
                                </td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#26B99A; color:white; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                            </tr>
                            <tr>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDLEstadoFinal" runat="server" AutoPostBack="true" CssClass="full-width" OnSelectedIndexChanged="CargaComentarios_SelectedIndexChanged"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">
                                    <asp:DropDownList ID="DDLComentarios" runat="server" CssClass="full-width"></asp:DropDownList>
                                </td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'">&nbsp;</td>
                                <td style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></td>
                            </tr>
                            <tr style="display:none;"><td colspan="5" style="background-color:#ddd; color:black; font-size:smaller; text-align:left; font-family:'Arial Rounded MT'"></tr>
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
                                                <button type="button" class="btn btn-success col-md-3 col-sm-3 col-xs-12" data-toggle="modal" title="Guardar" data-target=".confirmacion">Guardar</i></button>


                                                <asp:Button ID="btnAceptarObs" runat="server" Text="Aceptar" class="btn btn-success col-md-5 col-sm-5 col-xs-12" OnClick="BotonPresionado_Click" />
                                                <asp:Button ID="btnSelccionCompleta" runat="server" Text="Sel Completa" class="btn btn-warning col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionSeleccionCompleta" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnPCI" runat="server" Text="P C I" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" data-toggle="modal" data-target=".confirmacionPCI" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnHold" runat="server" Text="Hold" class="btn btn-warning col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnSuspender" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
                                                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar" class="btn btn-danger col-md-2 col-sm-2 col-xs-12" OnClick="BotonPresionado_Click"/>
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
