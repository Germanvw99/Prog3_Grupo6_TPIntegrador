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
                                <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Descripción</label>
                                <asp:TextBox ID="TxtDescripcion" type="text" runat="server" class="form-control" placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <div class="mb-3">
                                    <label class="form-label">Marca</label>
                                    <asp:LinkButton ID="IrAgregarMarca" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarMarca_Click">+ Agregar Marca</asp:LinkButton>
                                </div>
                                <asp:DropDownList ID="DdlMarcas"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <div class="mb-3">
                                    <label class="form-label">Categoría</label>
                                    <asp:LinkButton ID="IrAgregarCategoria" runat="server" class="btn btn-outline-primary float-right" OnClick="IrAgregarCategoria_Click">+ Agregar Categoría</asp:LinkButton>
                                </div>
                                <asp:DropDownList ID="DdlCategorias"    class="custom-select form-control"  runat="server" > </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Estado</label>
                                <br />
                                <asp:DropDownList ID="DdlEstados"   class="custom-select form-control"  runat="server" > </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Punto de pedido</label>
                                <asp:TextBox ID="TextBox1" type="text" runat="server" class="form-control" placeholder="Punto de pedido"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Precio de Lista</label>
                                <asp:TextBox ID="TextBox2" type="text" runat="server" class="form-control" placeholder="Precio de Lista"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Imágen</label>
                                <div>
                                    <input type="file" class="validation-file" name="validation-file">
                                </div>
                            </div>
                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar artículo" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>