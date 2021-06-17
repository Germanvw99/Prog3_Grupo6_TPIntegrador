<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleVenta.aspx.cs" Inherits="Vistas.DetalleVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
                        <asp:LinkButton ID="IrListarArticulos" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listado de Artículos</asp:LinkButton>
                        <asp:LinkButton ID="IrListarMarcas" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listado de Marcas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarCategorias" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listado de Categorías</asp:LinkButton>
                        <asp:LinkButton ID="IrListarProveedores" runat="server" class="btn btn-outline-primary" OnClick="IrListarProveedores_Click">Listado de Proveedores</asp:LinkButton>
                        <asp:LinkButton ID="IrListarVentas" runat="server" class="btn btn-outline-warning" OnClick="IrListarVentas_Click">Listado de Ventas</asp:LinkButton>
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-12">
                    <div class="card shadow mb-4"">
                        <div class="card-header">
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <h5 class="h2 card-title mb-0">Detalle de venta</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-4 text-left">
                                            <div class="card">
                                                <div class="card-header">
                                                    <div class="card-actions">
                                                        <!--IR A MAS DETALLES DEL COMPRADOR-->
                                                    </div>
                                                    <h5 class="card-title mb-0">Factura:</h5>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <div class="form-group">
                                                                <label >Número de Factura: </label>
                                                                <asp:Label runat="server" type="text"  id="LblNumeroFactura" ></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label >Fecha: </label>
                                                                <asp:Label runat="server" type="text"  id="LblFecha" ></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-8 text-left">
                                            <div class="card">
                                                <div class="card-header">
                                                    <div class="card-actions">
                                                        <!--IR A MAS DETALLES DEL COMPRADOR-->
                                                    </div>
                                                    <h5 class="card-title mb-0">Comprador:</h5>
                                                </div>
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label >Apellido y nombre: </label>
                                                                <asp:Label runat="server" type="text"  id="LblApellidoNombre" ></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label >DNI: </label>
                                                                <asp:Label runat="server" type="text"  id="LblDni" ></asp:Label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <label >Dirección: </label>
                                                                <asp:Label runat="server" type="text"  id="LblDireccion" ></asp:Label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label >Localidad: </label>
                                                                <asp:Label runat="server" type="text"  id="LblLocalidad" ></asp:Label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div>
                                        </div>
                                        <div class="col-md-12 text-left">
                                            <div class="card">
                                                <div class="card-header">
                                                    <div class="card-actions float-right">
                                                        <!--IR A MAS DETALLES DE LOS ARTICULOS-->
                                                    </div>
                                                    <h5 class="card-title mb-0">Artículos: </h5>
                                                </div>
                                                <div class="card-body">
                                                    <asp:GridView ID="GrdDetalleVentas" runat="server" AutoGenerateColumns="False"
                                                        CssClass="table display" CellPadding="4" ForeColor="#333333" GridLines="None">
                                                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Cod. Art.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="dt_articulo_codigo" runat="server" Text='<%# Eval("dt_articulo_codigo") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Nombre">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="art_nombre" runat="server" Text='<%# Eval("art_nombre") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Cantidad">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="dt_cantidad_unidades" runat="server" Text='<%# Eval("dt_cantidad_unidades") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Precio Unitario">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="dt_precio_unitario" runat="server" Text='<%# Eval("dt_precio_unitario") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="SubTotal">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="dt_total" runat="server" Text='<%# Eval("dt_total") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%-- AGREGAR BOTONOS--%>
                                                        </Columns>
                                                        <EditRowStyle BackColor="#999999" />
                                                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                                    </asp:GridView>
                                                    <div class="row">
                                                        <div class="col-md-2 text-center"></div>
                                                        <div class="col-md-2 text-center"></div>
                                                        <div class="col-md-2 text-center"></div>
                                                        <div class="col-md-2 text-center"></div>
                                                        <div class="col-md-2 text-center"></div>
                                                        <div class="col-md-2 text-left">
                                                            <label >Total: </label>
                                                            <asp:Label runat="server" type="text"  id="LblTotalFacturado" ></asp:Label>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 text-reght">
                                            <div class="form-group float-right">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>