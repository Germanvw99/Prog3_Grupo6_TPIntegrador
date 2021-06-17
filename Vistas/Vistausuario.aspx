<%@ Page Title=""  EnableEventValidation="false"  Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Vistausuario.aspx.cs" Inherits="Vistas.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
     <style type="text/css">
        .c {
            box-shadow: 10px 10px 10px  black;
            border : 3px solid #d3d3d3; 
        }
         .b {
            box-shadow: -1px 1px 1px 1px green;
        }
          .p {
            box-shadow: -1px 1px 1px 1px red;
        }




</style>
     <div >
        <div >
    <asp:ListView ID="ListView1" runat="server"  DataKeyNames="art_codigo" GroupItemCount="6"  style="margin-right: 0px" OnPreRender="ListView1_PreRender" >
        <%--<AlternatingItemTemplate  >
            <td runat="server"   Class=c  style="background-color: #FFF8DC;">art_codigo:
                <asp:Label ID="art_codigoLabel" runat="server" Text='<%# Eval("art_codigo") %>' />
                <br />art_nombre:
                <asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' />
             <br />
                art_descripcion:
                <asp:Label ID="art_descripcionLabel" runat="server" Text='<%# Eval("art_descripcion") %>' />
                <br />
                art_punto_pedido:
                <asp:Label ID="art_punto_pedidoLabel" runat="server" Text='<%# Eval("art_punto_pedido") %>' />
                <br />art_precio_lista:
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                <br />
                art_ruta_imagen:
                <asp:Label ID="art_ruta_imagenLabel" runat="server" Text='<%# Eval("art_ruta_imagen") %>' />
                <br />
                est_nombre:
                <asp:Label ID="est_nombreLabel" runat="server" Text='<%# Eval("est_nombre") %>' />
                <br />
                mar_nombre:
                <asp:Label ID="mar_nombreLabel" runat="server" Text='<%# Eval("mar_nombre") %>' />
                <br />
                cat_nombre:
                <asp:Label ID="cat_nombreLabel" runat="server" Text='<%# Eval("cat_nombre") %>' />
                <br />
            </td>
        </AlternatingItemTemplate>--%>
        <EditItemTemplate>
            <td runat="server" style="background-color: #008A8C; color: #FFFFFF;">art_codigo:&nbsp;<asp:Label ID="art_codigoLabel1" runat="server" Text='<%# Eval("art_codigo") %>' />
                <br />art_nombre:&nbsp;<asp:TextBox ID="art_nombreTextBox" runat="server" Text='<%# Bind("art_nombre") %>' />
                <br />art_descripcion:
                <asp:TextBox ID="art_descripcionTextBox" runat="server" Text='<%# Bind("art_descripcion") %>' />
                <br />
                art_punto_pedido:
                <asp:TextBox ID="art_punto_pedidoTextBox" runat="server" Text='<%# Bind("art_punto_pedido") %>' />
                <br />
                art_precio_lista:
                <asp:TextBox ID="art_precio_listaTextBox" runat="server" Text='<%# Bind("art_precio_lista") %>' />
                <br />
                art_ruta_imagen:
                <asp:TextBox ID="art_ruta_imagenTextBox" runat="server" Text='<%# Bind("art_ruta_imagen") %>' />
                <br />est_nombre:
                <asp:TextBox ID="est_nombreTextBox" runat="server" Text='<%# Bind("est_nombre") %>' />
                <br />
                mar_nombre:
                <asp:TextBox ID="mar_nombreTextBox" runat="server" Text='<%# Bind("mar_nombre") %>' />
                <br />
                cat_nombre:
                <asp:TextBox ID="cat_nombreTextBox" runat="server" Text='<%# Bind("cat_nombre") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Actualizar" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancelar" />
                <br />
            </td>
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
            <td runat="server" style="">art_nombre:
                <asp:TextBox ID="art_nombreTextBox" runat="server" Text='<%# Bind("art_nombre") %>' />
                <br />art_descripcion:
                <asp:TextBox ID="art_descripcionTextBox" runat="server" Text='<%# Bind("art_descripcion") %>' />
                <br />art_punto_pedido:
                <asp:TextBox ID="art_punto_pedidoTextBox" runat="server" Text='<%# Bind("art_punto_pedido") %>' />
                <br />art_precio_lista:
                <asp:TextBox ID="art_precio_listaTextBox" runat="server" Text='<%# Bind("art_precio_lista") %>' />
                <br />art_ruta_imagen:
                <asp:TextBox ID="art_ruta_imagenTextBox" runat="server" Text='<%# Bind("art_ruta_imagen") %>' />
                <br />est_nombre:
                <asp:TextBox ID="est_nombreTextBox" runat="server" Text='<%# Bind("est_nombre") %>' />
                <br />
                mar_nombre:
                <asp:TextBox ID="mar_nombreTextBox" runat="server" Text='<%# Bind("mar_nombre") %>' />
                <br />cat_nombre:
                <asp:TextBox ID="cat_nombreTextBox" runat="server" Text='<%# Bind("cat_nombre") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insertar" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Borrar" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td Class=c runat="server" style="background-color: #FFFFFF; color: #333333;">
                

                <br />&nbsp;
                <asp:Label ID="art_nombreLabel" runat="server" Text='<%# Eval("art_nombre") %>' />
                
                <asp:ImageButton ID="ImageButton3"  style="height:167px" runat="server"  CommandArgument='<%# Eval("art_codigo")+"@"+Eval("art_nombre")+"@"+Eval("art_descripcion")+"@"+Eval("art_punto_pedido")+"@"+Eval("art_precio_lista")+"@"+Eval("art_ruta_imagen")+"@"+Eval("est_nombre")+"@"+Eval("mar_nombre")+"@"+Eval("cat_nombre") %>' CommandName="EventoImg" Height="46px" ImageUrl='<%# Eval("art_ruta_imagen") %>' OnCommand="ImageButton3_Command" Width="202px" />
                <br />
                <br />&nbsp;&nbsp;
                <br />
                <br />&nbsp;&nbsp;$
                <asp:Label ID="art_precio_listaLabel" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                <br />
                <asp:Button ID="Button1" CssClass=btn-primary runat="server" CommandArgument='<%# Eval("art_codigo")+"@"+Eval("art_nombre")+"@"+Eval("art_descripcion")+"@"+Eval("art_precio_lista") %>' CommandName="agregar" OnCommand="Button1_Command" Text="Agregar" />
                <br />
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td Class=c style="text-align: center;background-color: #CCCCCC; font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;" runat="server">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="12">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="background-color: #008A8C; font-weight: bold;color: #FFFFFF;">art_codigo:
                <asp:Label ID="art_codigoLabel" runat="server" Text='<%# Eval("art_codigo") %>' />
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
                <br />est_nombre:
                <asp:Label ID="est_nombreLabel" runat="server" Text='<%# Eval("est_nombre") %>' />
                <br />mar_nombre:
                <asp:Label ID="mar_nombreLabel" runat="server" Text='<%# Eval("mar_nombre") %>' />
                <br />cat_nombre:
                <asp:Label ID="cat_nombreLabel" runat="server" Text='<%# Eval("cat_nombre") %>' />
                <br /></td>
        </SelectedItemTemplate>
    </asp:ListView>

            </div>

         </div>

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Grupo6_TPIntegradorV6ConnectionString3 %>" SelectCommand="SELECT art_codigo,art_nombre,art_descripcion,art_punto_pedido,art_precio_lista,art_ruta_imagen,est_nombre, mar_nombre, cat_nombre FROM Articulos INNER JOIN Estados ON Articulos.art_codigo_estado=Estados.est_codigo INNER JOIN Marcas ON Marcas.mar_codigo=Articulos.art_marca_codigo INNER JOIN Categorias ON Categorias.cat_codigo=Articulos.art_categoria_codigo "></asp:SqlDataSource>

<asp:Label ID="Label1" runat="server"></asp:Label>



</asp:Content>
