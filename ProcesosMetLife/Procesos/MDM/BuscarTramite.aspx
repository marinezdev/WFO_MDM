<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarTramite.aspx.cs" Inherits="ProcesosMetLife.Procesos.MDM.BuscarTramite" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">



     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Buscar Trámite</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    

                            <table>
                                <tr>
                                    <td></td>
                                </tr>
                                <tr>
                                    <td align="right"><strong>Póliza:</strong>&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right">
                                        <asp:TextBox ID="txtBuscar" runat="server" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td align="left">
                                        &nbsp;<asp:Button ID="BtnBuscar" runat="server" CssClass="btn btn-primary" Text="Buscar" OnClick="BtnBuscar_Click"/>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4"><asp:Label ID="lblProcesadoExcel" runat="server" ForeColor="Green"></asp:Label></td>
                                </tr>

                            </table>


                    <asp:Label ID="LblProcesado" runat="server"></asp:Label>
                    <hr>
                    <asp:GridView ID="GV" runat="server" AutoGenerateColumns="false" CssClass="table table-responsive table-hover" HeaderStyle-BackColor="LightGray" 
                        CellPadding="25" CellSpacing="25" Width="35%" 
                        OnRowCommand="GV_RowCommand" 
                        OnRowDataBound="GV_RowDataBound">
                        <Columns>
                            <asp:BoundField DataField="IdTramite" HeaderText="Id Trámite" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Poliza" HeaderText="Poliza" />
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Captura 1" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkEditar" runat="server" Text='<%# Bind("Captura1") %>' CommandArgument='<%# Eval("Id") + ":" + Eval("IdTramite") %>' CommandName="Editar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Captura 2" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LnkRevisar" runat="server" Text='<%# Bind("Captura2") %>' CommandArgument='<%# Eval("Id") + ":" + Eval("IdTramite") %>' CommandName="Revisar"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>






                </div>
            </div>
        </div>
     </div>



</asp:Content>
