<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlStockModificar.aspx.cs" Inherits="Vistas.ControlStockModificar" %>
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
                                        <h5 class="h2 card-title mb-0">Modificar Stocks</h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class ="row">
                            <div class="card-body card bg-light">
                                <div class ="row">
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5 class="card-title">Datos actuales</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="form-group">
                                                    <label class="form-label">Nombre del proveedor</label>
                                                    <asp:TextBox ID="TxtNombreProveedor" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">N° CUIL - DNI</label>
                                                    <asp:TextBox ID="TxtCuilProveedor" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Nombre del artículo</label>
                                                    <asp:TextBox ID="TextNombreArticulo" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Código del artículo</label>
                                                    <asp:TextBox ID="TextCodigoArticulo" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Stock actual</label>
                                                    <asp:TextBox ID="TxtStockActual" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Precio unitario</label>
                                                    <asp:TextBox ID="TxtPrecioUnitario" type="text" runat="server" class="form-control" placeholder="" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card">
                                            <div class="card-header">
                                                <h5 class="card-title">Nuevos datos</h5>
                                            </div>
                                            <div class="card-body">
                                                <div class="form-group">
                                                    <label class="form-label">Stock actual</label><asp:CompareValidator ID="CvTxtStockActualModificar" runat="server" ControlToValidate="TxtStockActualModificar" ErrorMessage="*Debe ingresar valores enteros positivos" ForeColor="Red" Operator="GreaterThanEqual" Type="Integer" ValidationGroup="modificar" ValueToCompare="0">*</asp:CompareValidator>
&nbsp;<asp:TextBox ID="TxtStockActualModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="form-label">Precio unitario</label><asp:RegularExpressionValidator ID="RevTxtPrecioUnitarioModificar" runat="server" ControlToValidate="TxtPrecioUnitarioModificar" ErrorMessage="**Debe ingresar valores hasta con dos decimales (Usar . [punto]  como separador)" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ValidationGroup="modificar">**</asp:RegularExpressionValidator>
&nbsp;<asp:TextBox ID="TxtPrecioUnitarioModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                </div>
                                                    <div class="form-group float-right">
                                                        <asp:Button ID="BtnModificarArticuloProveedor" class="btn btn-primary float-right" runat="server" Text="Modificar Stock" OnClick="BtnModificarArticuloProveedor_Click" ValidationGroup="modificar" />
                                                        &nbsp &nbsp
                                                        <asp:Button ID="BtnCancelar" class="btn btn-secondary float-right" runat="server" Text="Cancelar" OnClick="BtnCancelar_Click" />
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
            </div>
        </div>
    </main>
    <asp:ValidationSummary ID="VsModificarStock" runat="server" ForeColor="Red" ValidationGroup="modificar" />
</asp:Content>