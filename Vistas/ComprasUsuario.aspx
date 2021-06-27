<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComprasUsuario.aspx.cs" Inherits="Vistas.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
            <div class="row">
                <div class="col-12">
                    <div class="card shadow"">
                        <div class="card-header">
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row text-center">
                                            <h5 class="h2 card-title mb-0">Listado de Compras</h5>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <asp:GridView ID="GvCompras" runat="server" CssClass="w-100 table-striped dataTable dtr-inline table-hover row-border" AutoGenerateColumns="False" OnRowCommand="GvCompras_RowCommand">
                                        <Columns>
                                        <asp:ButtonField ButtonType="Image" CommandName="eventodetalle" ImageUrl="Recursos/img/ver.png" />
                                        <asp:TemplateField HeaderText="Factura">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("Venta") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Cliente">
                                            <ItemTemplate>
                                                <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Medio de pago">
                                        <ItemTemplate>
                                                <asp:Label ID="lblmediodepago" runat="server" Text='<%# Bind("Mediodepago") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fecha">
                                            <ItemTemplate>
                                                <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Total">
                                             <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Aun no tienes compras realizadas"></asp:Label>
                                        </EmptyDataTemplate>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div> 
            </div>
        </div> 
    </main>
    <!-- MODAL DETALLES-->
    <!-- MODAL -->
    <div id="myModalDetalles" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header text-center">
                    <h4 class="modal-title">Detalles de compra</h4>
                    <button type="button" class="close" data-dismiss="modal">×</button>
                </div>
				<!-- Modal body -->
				<div class="modal-body">
                    <asp:GridView ID="GvDetallesCompra" runat="server" CssClass="w-100 table-striped dataTable dtr-inline table-hover row-border"  AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Factura">
                                <ItemTemplate>
                                    <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("Factura") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                    <asp:Label ID="lblproducto" runat="server" Text='<%# Bind("Producto") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Importe">
                                <ItemTemplate>
                                    <asp:Label ID="lblimporte" runat="server" Text='<%# Bind("Importe") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label ID="lblcantidad" runat="server" Text='<%# Bind("Cantidad") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Total">
                                <ItemTemplate>
                                    <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                     </asp:GridView>
                </div>  
             </div>
		</div>
    </div>
    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
</asp:Content>
