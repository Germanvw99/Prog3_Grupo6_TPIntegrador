<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vistausuario.aspx.cs" Inherits="Vistas.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="card-body">
    <asp:ListView ID="ListView1" runat="server"  DataKeyNames="art_codigo" GroupItemCount="3" DataSourceID="SqlDataSource1" style="margin-right: 0px" OnSelectedIndexChanged="ListView1_SelectedIndexChanged">
        <AlternatingItemTemplate>
            <td runat="server" style="background-color: #FAFAD2;color: #284775;"><br />&nbsp;
                <asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' />
                <br />
                <asp:ImageButton ID="ImageButton4" runat="server" Height="166px" ImageUrl='<%# Bind("art_ruta_imagen") %>' Width="202px" />
                <br />
                <br />
                <br />
                <br />&nbsp;$
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                <br />
                <asp:Button ID="Button3" runat="server" CssClass="btn-primary" OnClick="Button3_Click" Text="Agregar" />
            </td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td runat="server" style="background-color: #FFCC66;color: #000080;">&nbsp;<br />&nbsp;
                <asp:Label ID="art_codigoLabel1" runat="server" Text='<%# Eval("art_codigo") %>' />
                <br />
                <asp:ImageButton ID="ImageButton2" runat="server" Height="156px" ImageUrl='<%# Bind("art_ruta_imagen") %>' Width="169px" />
                <br />
                <br />&nbsp;$
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>'></asp:Label>
                <br />
                <br />
                <br /></td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No se han devuelto datos.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">art_marca_codigo:
                <asp:TextBox ID="art_marca_codigoTextBox" runat="server" Text='<%# Bind("art_marca_codigo") %>' />
                <br />art_categoria_codigo:
                <asp:TextBox ID="art_categoria_codigoTextBox" runat="server" Text='<%# Bind("art_categoria_codigo") %>' />
                <br />art_nombre:
                <asp:TextBox ID="art_nombreTextBox" runat="server" Text='<%# Bind("art_nombre") %>' />
                <br />art_descripcion:
                <asp:TextBox ID="art_descripcionTextBox" runat="server" Text='<%# Bind("art_descripcion") %>' />
                <br />art_punto_pedido:
                <asp:TextBox ID="art_punto_pedidoTextBox" runat="server" Text='<%# Bind("art_punto_pedido") %>' />
                <br />art_precio_lista:
                <asp:TextBox ID="art_precio_listaTextBox" runat="server" Text='<%# Bind("art_precio_lista") %>' />
                <br />art_ruta_imagen:
                <asp:TextBox ID="art_ruta_imagenTextBox" runat="server" Text='<%# Bind("art_ruta_imagen") %>' />
                <br />art_codigo_estado:
                <asp:TextBox ID="art_codigo_estadoTextBox" runat="server" Text='<%# Bind("art_codigo_estado") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td runat="server" style="background-color: #FFFBD6;color: #333333;">
                <br />&nbsp;<asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' />
                <br />&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" Height="167px" ImageUrl='<%# Bind("art_ruta_imagen") %>' Width="202px" />
                <br />
                <br />&nbsp;&nbsp;
                <br />
                <br />&nbsp;$&nbsp;
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                <br />
                <asp:Button ID="Button2" CssClass=btn-primary runat="server" Text="Agregar" />
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server" style="height: 172px">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="background-color: #FFCC66;font-weight: bold;color: #000080;">art_codigo:
                <asp:Label ID="art_codigoLabel" runat="server" Text='<%# Eval("art_codigo") %>' />
                <br />art_marca_codigo:
                <asp:Label ID="art_marca_codigoLabel" runat="server" Text='<%# Eval("art_marca_codigo") %>' />
                <br />art_categoria_codigo:
                <asp:Label ID="art_categoria_codigoLabel" runat="server" Text='<%# Eval("art_categoria_codigo") %>' />
                <br />art_nombre:
                <asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' />
                <br />art_descripcion:
                <asp:Label ID="art_descripcionLabel" runat="server" Text='<%# Eval("art_descripcion") %>' />
                <br />art_punto_pedido:
                <asp:Label ID="art_punto_pedidoLabel" runat="server" Text='<%# Eval("art_punto_pedido") %>' />
                <br />art_precio_lista:
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                <br />art_ruta_imagen:
                <asp:Label ID="art_ruta_imagenLabel" runat="server" Text='<%# Eval("art_ruta_imagen") %>' />
                <br />art_codigo_estado:
                <asp:Label ID="art_codigo_estadoLabel" runat="server" Text='<%# Eval("art_codigo_estado") %>' />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>

         </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Grupo6_TPIntegradorV6ConnectionString2 %>" SelectCommand="SELECT * FROM [Articulos]"></asp:SqlDataSource>

</asp:Content>
