<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Vistas.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="GridView1" runat="server" Width="867px" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" style="margin-right: 2px">
        <Columns>
             <asp:ButtonField ButtonType="Image" CommandName="eventodetalle" ImageUrl="Recursos/img/ver.png" />
            <asp:TemplateField HeaderText="Factura">
                <ItemTemplate>
                    <asp:Label ID="lblfactura" runat="server" Text='<%# Bind("Venta") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cliente">
                <ItemTemplate>
                    <asp:Label ID="lblcliente" runat="server" Text='<%# Bind("Usuario") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mediodepago">
                <ItemTemplate>
                    <asp:Label ID="lblmediodepago" runat="server" Text='<%# Bind("Mediodepago") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha">
                <ItemTemplate>
                    <asp:Label ID="lblfecha" runat="server" Text='<%# Bind("Fecha") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total">
                <ItemTemplate>
                    <asp:Label ID="lbltotal" runat="server" Text='<%# Bind("Total") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="Label2" runat="server"></asp:Label>

</asp:Content>
