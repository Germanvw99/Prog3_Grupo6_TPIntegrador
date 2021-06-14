<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="Vistas.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        td{
            
        }
        tr{
            margin:5px;
            background-color:antiquewhite
        }

        .detalles{
            background-color:#E5E7E9;
            padding:5px;
            border-radius:5px;
        }
        .item{
            background-color:;
            padding:5px;
            margin:5px;
            border-radius:5px;
            border-bottom-style:solid;
        }
        .botones{
            display:flex;
            justify-content:space-around;
            margin-top:5px;
        }
       

    </style>
    
    <div style="margin:1% 6%; display:flex; border-style:solid; border-color:#2980B9 ">
        <div style="margin:5px; border-style:solid; border-color:#E5E7E9; border-radius:10px">
        <asp:ImageButton ID="ImageButton2" runat="server" Height="500px" Width="500px" style="border-radius:5px; " />
        </div>
    
        <div style=" flex-grow:1; margin:5px">
            <h2 style="color:black">
                &nbsp;<asp:Label ID="Lbnombre" runat="server" Text="Label"></asp:Label></h2>
            <hr />
          
            <div class="detalles">
                
                <div class="item">
                    <p>Descripción</p>
                    <asp:Label ID="Lbdetalle" runat="server" Text="Label"></asp:Label>
                </div>
                <%--<div class="item">
                    <p>Nombre del Producto</p>
                </div>--%>
                 <div class="item">
                    <p>Marca</p>
                     <asp:Label ID="Lbmarca" runat="server" Text="Label"></asp:Label>
                </div>
                 <div class="item">
                    <p>Categoria</p>
                     <asp:Label ID="Lbcategoria" runat="server" Text="Label"></asp:Label>
                </div>
                <%--<div class="item">
                    <p>Cantidad en Stock</p>
                     <asp:Label ID="Lbstock" runat="server" Text="Label"></asp:Label>
                </div>--%>
                 <div class="item">
                    <p>Precio</p>
                     $<asp:Label ID="Lbprecio" runat="server" Text="Label"></asp:Label>
                </div>
                 <div class="item">Cantidad a Comprar: 
                <asp:Button ID="Button1" runat="server" Text="-" Style="border-radius:5px; background-color:darkgray; border-style:none;color:white; font-size:14px " Width="20px" OnClick="Btmenos_Click" />
                 <asp:TextBox ID="tbcantidad" runat="server" Width="51px" Text="1" style="text-align:center" ReadOnly="True"></asp:TextBox>
                <asp:Button ID="Button4" runat="server" Text="+" Style="border-radius:5px; background-color:darkgray; border-style:none;color:white; font-size:14px" Width="20px" OnClick="Btmas_Click"/>
                </div>
                
             </div>
            <div class="botones">
                <div>
                <asp:Button ID="Button3" runat="server" Text="Comprar ahora" Width="185px" style="padding:8px; background-color:#3498DB;color:white; border-style:none; border-radius:5px; letter-spacing:2px" OnClick="Button3_Click"/>
                </div>
                <div>
                <asp:Button ID="btcarrito" runat="server" Text="Agregar a Carrito" Width="185px" style="padding:8px; background-color:#76D7C4;color:white; border-style:none; border-radius:5px; letter-spacing:2px" OnClick="btcarrito_Click" />
                </div>
                
            </div>
        </div>
    </div>
    <asp:Button ID="Button5" runat="server" Text="Volver a Catálogo" Width="185px" style="padding:8px; background-color:#76D7C4;color:white; border-style:none; border-radius:5px; letter-spacing:2px; margin:1% 2%" OnClick="btcarrito_Click" PostBackUrl="~/Vistausuario.aspx"  />
    <asp:Label ID="Label1" runat="server"></asp:Label>
</asp:Content>
