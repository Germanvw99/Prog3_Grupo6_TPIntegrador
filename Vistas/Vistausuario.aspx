<%@ Page Title=""  EnableEventValidation="false"  Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vistausuario.aspx.cs" Inherits="Vistas.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ListView ID="ListViewProductos" runat="server"  DataKeyNames="art_codigo" GroupItemCount="4" OnPreRender="ListViewProductos_PreRender" >
        <LayoutTemplate>
            <div runat="server">
                <div runat="server">
                        <div class="d-flex justify-content-center mt-4 align-items-center">
                            <asp:Label ID="LblCantProductos" runat="server" Text="" CssClass="mr-4"></asp:Label>
                            <asp:Button ID="BtnBuscarTodo" CssClass="btn btn-primary" runat="server" Text="Buscar todo" OnClick="BtnBuscarTodo_Click"/>
                        </div>
                    <div id="groupPlaceholder" runat="server">
                    </div>    
                </div>
                <div runat="server" class="text-center pb-4 pt-4">
                    <asp:DataPager ID="DataPaginacion" runat="server" PageSize="12">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btn btn-primary mr-2" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btn btn-primary ml-2" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </div>
            </div>
        </LayoutTemplate>
            <GroupTemplate>
                <div id="itemPlaceholderContainer" runat="server" class="container d-flex justify-content-center mt-50 mb-50">
                    <div class="card" id="itemPlaceholder" runat="server"></div>
                </div>
            </GroupTemplate>
        <ItemTemplate>
            <div class="col-md-3 mt-5 mr-4 ml-4">
                <div class="card">
                    <div class="card-body text-center">
                        <asp:ImageButton ID="ProductImage"  Height="160px"  Width="200px" runat="server"  CommandArgument='<%# Eval("art_codigo")+"@"+Eval("art_nombre")+"@"+Eval("art_descripcion")+"@"+Eval("art_punto_pedido")+"@"+Eval("art_precio_lista")+"@"+Eval("art_ruta_imagen")+"@"+Eval("est_nombre")+"@"+Eval("mar_nombre")+"@"+Eval("cat_nombre") %>' CommandName="EventoImg" ImageUrl='<%# Eval("art_ruta_imagen") %>' OnCommand="ProductImage_Command"/>
                        <div class="mb-2">
                            <h6 class="font-weight-semibold mb-3"><asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' /></h6>
                            <h6 class="mb-3 text-muted"><asp:Label ID="art_catLabel" runat="server" Text='<%# Eval("cat_nombre") %>' /></h6>
                            <h3 class="mb-0 font-weight-semibold">$ <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' /></h3>
                            <asp:Button ID="BtnAgregarCarrito" CssClass="btn btn-primary btn-block mt-4" runat="server" CommandArgument='<%# Eval("art_codigo")+"@"+Eval("art_nombre")+"@"+Eval("art_descripcion")+"@"+Eval("art_precio_lista") %>' CommandName="agregar" OnCommand="BtnAgregarCarrito_Command" Text="Agregar" />
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div runat="server" class="text-center">
                <h2 class="mt-5">No se han encontrado artículos.</h2>
                <asp:Button ID="BtnBuscarTodo" CssClass="btn btn-primary mt-4" runat="server" Text="Mostrar Todo" OnClick="BtnBuscarTodo_Click"/>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
    <asp:SqlDataSource ID="SqlDtProductos" runat="server" ConnectionString="<%$ ConnectionStrings:Grupo6_TPIntegradorV6ConnectionString3 %>" SelectCommand="SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo "></asp:SqlDataSource>

<asp:Label ID="LblNotificacion" runat="server"></asp:Label>


</asp:Content>
