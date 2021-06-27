<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlStockAgregar.aspx.cs" Inherits="Vistas.ControlStockAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
                        <asp:LinkButton ID="IrListarUsuarios" runat="server" class="btn btn-outline-success" OnClick="IrListarUsuarios_Click" >Listado de Usuarios</asp:LinkButton>
                        <asp:LinkButton ID="IrListarArticulos" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listado de Artículos</asp:LinkButton>
                        <asp:LinkButton ID="IrListarMarcas" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listado de Marcas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarCategorias" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listado de Categorías</asp:LinkButton>
                        <asp:LinkButton ID="IrListarProveedores" runat="server" class="btn btn-outline-primary" OnClick="IrListarProveedores_Click">Listado de Proveedores</asp:LinkButton>
                        <asp:LinkButton ID="IrListarVentas" runat="server" class="btn btn-outline-warning" OnClick="IrListarVentas_Click">Listado de Ventas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarStock" runat="server" class="btn btn-outline-success" OnClick="IrListarStock_Click">Listado de Stocks</asp:LinkButton>
                        <asp:LinkButton ID="IrReportes" runat="server" class="btn btn-outline-primary" OnClick="IrReportes_Click">Reportes</asp:LinkButton>
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
                                            <h5 class="h2 card-title mb-0">Agregar Stock</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class ="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <div class="mb-3">
                                                    <label class="form-label">Proveedor</label>
                                                    <asp:LinkButton ID="IrAgregarProveedor" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarProveedor_Click">+ Agregar Proveedor</asp:LinkButton>
                                                </div>
                                                <asp:DropDownList ID="DdlProveedores"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <div class="mb-3">
                                                    <label class="form-label">Artículo</label>
                                                    <asp:LinkButton ID="IrAgregarArticulo" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarArticulo_Click">+ Agregar Artículo</asp:LinkButton>
                                                </div>
                                                <asp:DropDownList ID="DdlArticulos" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Cantidad</label>&nbsp;<asp:TextBox ID="TxtCantidad" type="text" runat="server" class="form-control" placeholder="cantidad" TextMode="Number"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Precio por unidad</label><asp:TextBox ID="TxtPrecio" type="number" step="any"  runat="server" class="form-control" placeholder="0.00"></asp:TextBox>
                                            </div>
                                            <asp:ValidationSummary ID="VsAgregarArticuloStock" runat="server" ForeColor="Red" ValidationGroup="agregar" />
                                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar artículo al stock" OnClick="BtnAgregar_Click" ValidationGroup="agregar"/>
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