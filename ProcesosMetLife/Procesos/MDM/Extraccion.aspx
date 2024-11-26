<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Extraccion.aspx.cs" Inherits="ProcesosMetLife.Procesos.MDM.Extraccion" MasterPageFile="~/Utilerias/Site.Master"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

    <script type="text/javascript" lang="javascript">
        function postbackButtonClick() {
            updateProgress = $find("<%= UPEncontrar.ClientID %>");
            window.setTimeout("updateProgress.set_visible(true)", updateProgress.get_displayAfter());
            return true;
        }
    </script>


     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Extración de Archivo</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>

                <div class="x_content">
                    <asp:UpdatePanel ID="UPBUscar" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>
                                <!--
                                <tr>
                                    <td>Total de Pólizas</td>
                                    <td>
                                        <asp:TextBox ID="txtTotalTramites" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                </tr>
                                -->
                                <tr>
                                    <td align="right"><strong>Archivo:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right">
                                        <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" PersistFile="true" ClientIDMode="AutoID" UploaderStyle="Modern" ErrorBackColor="Red" Width="100%" />
                                    </td>
                                    <td align="left">
                                        <asp:Button ID="BtnExcelAceptar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="BtnExcelAceptar_Click" OnClientClick="return postbackButtonClick();"/>
                                    </td>
                                    <td>
                                        <asp:UpdateProgress ID="UPEncontrar" runat="server" AssociatedUpdatePanelID="UPBuscar">
                                            <ProgressTemplate>
                                                <asp:Image ID="Espera" runat="server" ImageUrl="~/Imagenes/ajax-loader.gif" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><asp:Label ID="lblProcesadoExcel" runat="server" ForeColor="Green"></asp:Label></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:PostBackTrigger ControlID="BtnExcelAceptar" />
                        </Triggers>
                    </asp:UpdatePanel>

                    <asp:Label ID="LblProcesado" runat="server"></asp:Label>
                    <asp:GridView ID="GVExtraccion" runat="server"></asp:GridView>
                </div>
            </div>
        </div>
     </div>
</asp:Content>
