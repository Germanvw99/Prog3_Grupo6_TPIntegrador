<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosAgregar.aspx.cs" Inherits="Vistas.ArticulosAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
            <br />
<%--            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
                        <asp:LinkButton ID="IrListarArticulos" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listar Artículos</asp:LinkButton>
                        <asp:LinkButton ID="IrListarMarcas" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listar Marcas</asp:LinkButton>
                        <asp:LinkButton ID="IrListarCategorias" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listar Categorías</asp:LinkButton>
                    </div>
                </div>
            </nav>--%>
            <div class="row">
                <div class="col-12">
                    <div class="card shadow mb-4"">
                        <div class="card-header">
                            <h5 class="card-title mb-0">Agregar Artículos</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="form-label">Nombre</label>
                                <div class="d-flex">
                                    <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="txtnombre" ErrorMessage="Nombre invalido" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>

                            </div>
                            <div class="form-group">
                                <label class="form-label">Descripción</label>
                                <div class="d-flex">
                                    <asp:TextBox ID="TxtDescripcion" type="text" runat="server" class="form-control" placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvDescripcion" runat="server" ControlToValidate="txtDescripcion" ErrorMessage="Descripcion invalida" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="mb-3">
                                    <label class="form-label">Marca</label>
                                    <asp:LinkButton ID="IrAgregarMarca" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarMarca_Click">+ Agregar Marca</asp:LinkButton>
                                </div>
                                <div class="d-flex">
                                    <asp:DropDownList ID="DdlMarcas"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RfvMarca" runat="server" ControlToValidate="DdlMarcas" ErrorMessage="Marca invalida" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="mb-3">
                                    <label class="form-label">Categoría</label>
                                    <asp:LinkButton ID="IrAgregarCategoria" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarCategoria_Click">+ Agregar Categoría</asp:LinkButton>
                                </div>
                                <div class="d-flex">
                                    <asp:DropDownList ID="DdlCategorias"    class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RfvCategorias" runat="server" ControlToValidate="DdlCategorias" ErrorMessage="Categoria invalida" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Estado</label>
                                <br />
                                <div class="d-flex">
                                    <asp:DropDownList ID="DdlEstados"   class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RfvEstados" runat="server" ControlToValidate="DdlEstados" ErrorMessage="Estado invalido" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Punto de pedido</label>
                                <div class="d-flex">
                                    <asp:TextBox ID="txtPedido" type="text" runat="server" class="form-control" placeholder="Punto de pedido" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvPedido" runat="server" ControlToValidate="txtPedido" ErrorMessage="Pedido invalido" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                             </div>
                            <div class="form-group">
                                <label class="form-label">Precio de Lista</label>
                                <div class="d-flex">
                                    <asp:TextBox ID="txtPrecio" type="text" runat="server" class="form-control" placeholder="Precio de Lista" TextMode="Number"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RfvPrecio" runat="server" ControlToValidate="txtPrecio" ErrorMessage="Precio invalido" ForeColor="Red" ValidationGroup="VgAgregarArticulo">*</asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Imágen</label>
                                <div>
                                    <asp:FileUpload ID="UploadImage" runat="server" />
                                </div>
                            </div>
                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar artículo" OnClick="BtnAgregar_Click" ValidationGroup="VgAgregarArticulo"/>
                        </div>
                        <asp:Label ID="lblNotificacion" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
    </main>
</asp:Content>