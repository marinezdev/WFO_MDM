<%@ Page 
        Title="" 
        Language="C#" 
        MasterPageFile="~/Utilerias/Site.Master" 
        AutoEventWireup="true" 
        CodeBehind="rptTramitesTotales.aspx.cs" 
        Inherits="ProcesosMetLife.Procesos.MDM.Supervisor.rptTramitesTotales"
%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server" EnableViewState="true">

    <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Reporte de Trámites por Mesa</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <asp:DropDownList ID="ddlFlujo" runat="server" AutoPostBack="true" EnableViewState="true" class="form-control" OnSelectedIndexChanged="ddlFlujo_SelectedIndexChanged">
                    </asp:DropDownList>
                    <br /><br />
                    
                        <asp:Repeater ID="rptTramites" runat="server">
                            <HeaderTemplate>
                                <table id="example" class="table table-striped table-bordered table-hover" style='width:100%'>
                                    <thead>
                                        <tr >
                                            <th>Staus Trámite</th>
                                            <th>Total de Trámites</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td style="width:70%;">
                                        <%# Eval("Nombre") %>
                                    </td>
                                    <td style="width:70%;">
                                        <%# Eval("Total Trámite") %>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </tbody>
                            </table>
                            </FooterTemplate>
                        </asp:Repeater>

                    <br /><br />
                    <asp:GridView ID="GVReporte" runat="server"  AutoGenerateColumns="true" 
                        OnRowDataBound="GVReporte_RowDataBound" 
                        GridLines="Both" 
                        HeaderStyle-BackColor="LightGray" 
                        HeaderStyle-ForeColor="Black" 
                        RowStyle-HorizontalAlign="Right" 
                        FooterStyle-BackColor="LightGray" 
                        FooterStyle-HorizontalAlign="Right" 
                        FooterStyle-ForeColor="Black"
                        Font-Names="Tahoma" 
                        ShowFooter="true"
                        Visible="false">
                    </asp:GridView>
                    <br /><br />
                    <asp:GridView ID="GVDetalle" runat="server" GridLines="Both" 
                        HeaderStyle-BackColor="LightGray" 
                        HeaderStyle-ForeColor="Black" 
                        RowStyle-HorizontalAlign="Right" 
                        FooterStyle-BackColor="LightGray" 
                        FooterStyle-HorizontalAlign="Right" 
                        FooterStyle-ForeColor="Black"
                        Font-Names="Tahoma">
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
