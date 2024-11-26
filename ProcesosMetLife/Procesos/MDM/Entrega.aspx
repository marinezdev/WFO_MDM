<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="ProcesosMetLife.Procesos.MDM.Entrega" MasterPageFile="~/Utilerias/Site.Master"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
     <div class="row">
        <div class="col-md-12 col-sm-12 col-xs-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>Entrega de Captura Generada</h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>
                <div class="x_content">
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                            ENTREGA: &nbsp;&nbsp;&nbsp;
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                            <asp:DropDownList ID="DDLEntrega" runat="server" class="form-control" AutoPostBack="false" Width="100%">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-6 col-sm-6 col-xs-12 form-group has-feedback">
                            <asp:Button ID="BtnProcesarEntrega" runat="server" Text="Generar Entrega" CssClass="btn btn-primary" OnClick="BtnProcesarEntrega_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
     </div>
</asp:Content>