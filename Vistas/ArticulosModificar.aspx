<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosModificar.aspx.cs" Inherits="Vistas.ArticulosModificar" %>
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
                                            <h5 class="h2 card-title mb-0">Modificar Artículo</h5>
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
                                                        <asp:Image ID="ImgLogo" Height="100px" Width="100" runat="server" class="img-fluid rounded-circle"/>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Nombre</label>
                                                        <asp:TextBox ID="TxtNombre" readonly="true" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Descripción</label>
                                                        <asp:TextBox ID="TxtDescripcion" readonly="true" type="text" runat="server" class="form-control" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="mb-3">
                                                            <label class="form-label">Marca</label>
                                                        </div>
                                                        <asp:TextBox ID="TxtMarca" readonly="true" class="form-control" runat="server" > </asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="mb-3">
                                                            <label class="form-label">Categoría</label>
                                                        </div>
                                                        <asp:TextBox ID="TxtCategoria" readonly="true" class="form-control" runat="server" > </asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Estado</label>
                                                        <br />
                                                        <asp:TextBox ID="TxtEstado" readonly="true" class="form-control" runat="server" > </asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Punto de pedido</label>
                                                        <asp:TextBox ID="TxtPuntoPedido"  readonly="true" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Precio de Lista</label>
                                                        <asp:TextBox ID="TxtPrecioLista" readonly="true" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
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
                                                        <label class="form-label">Nombre</label>
                                                        <asp:TextBox ID="TxtNombreModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Descripción</label>
                                                        <asp:TextBox ID="TxtDescripcionModificar" type="text" runat="server" class="form-control" placeholder="" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="mb-3">
                                                            <label class="form-label">Marca</label>
                                                        </div>
                                                        <asp:DropDownList ID="DdlMarcaModificar"  class="custom-select form-control" runat="server" > </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="mb-3">
                                                            <label class="form-label">Categoría</label>
                                                        </div>
                                                        <asp:DropDownList ID="DdlCategoriaModificar"  class="custom-select form-control" runat="server" > </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Estado</label>
                                                        <asp:DropDownList ID="DdlEstadoModificar"  class="custom-select form-control" runat="server" > </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Punto de pedido</label><asp:CompareValidator ID="CvTxtPuntoPedidoModificar" runat="server" ErrorMessage="*Debe ingresar un numero mayor a cero" ControlToValidate="TxtPuntoPedidoModificar" ForeColor="Red" Operator="GreaterThanEqual" Type="Integer" ValidationGroup="modificar" ValueToCompare="0">*</asp:CompareValidator>
&nbsp;<asp:TextBox ID="TxtPuntoPedidoModificar" type="text" runat="server" TextMode="Number" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-label">Precio de Lista</label><asp:CompareValidator ID="CvTxtPrecioListaModificar" runat="server" ErrorMessage="** El valor debe ser monetario (hasta dos decimales)" ControlToValidate="TxtPrecioListaModificar" ForeColor="Red" Operator="GreaterThanEqual" Type="Currency" ValidationGroup="modificar" ValueToCompare="0">**</asp:CompareValidator>
&nbsp;<asp:RegularExpressionValidator ID="RevTxtPrecioListaModificar" runat="server" ControlToValidate="TxtPrecioListaModificar" ErrorMessage="**Debe ingresar valores hasta con dos decimales (Usar . [punto]  como separador)" ForeColor="Red" ValidationExpression="^[0-9]+(\.[0-9]{1,2})?$" ValidationGroup="modificar">**</asp:RegularExpressionValidator>
                                                        <asp:TextBox ID="TxtPrecioListaModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                                    </div>
                                                                                            <div class="form-group">
                                            <label class="form-label">Imágen</label>
                                            <div>
                                                <asp:FileUpload ID="FUArticulo" runat="server" />
                                                <br />
                                                <br />
                                                <asp:ValidationSummary ID="VsModificarArticulo" runat="server" ForeColor="Red" ValidationGroup="modificar" />
                                            </div>
                                            <div class="form-group float-right">
                                                                                                <asp:Button ID="BtnModificarArticulo" class="btn btn-primary float-right" runat="server" Text="Modificar Artículo" OnClick="BtnModificarArticulo_Click" ValidationGroup="modificar" />
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
        </div>
  
    </main>
</asp:Content>