<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ComprasUsuario.aspx.cs" Inherits="Vistas.Formulario_web12" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class ="row">
      <div class="card-body card bg-light">
    <asp:GridView ID="GridView1" runat="server" Width="1390px" CssClass="table-striped dataTable dtr-inline table-hover row-border" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" style="margin-right: 2px; margin-left: 141px;">
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
            <asp:TemplateField HeaderText="Medio de pago">
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
        <EmptyDataTemplate>
            <asp:Label ID="Label1" runat="server" Text="Aun no tienes compras realizadas"></asp:Label>
        </EmptyDataTemplate>
    </asp:GridView>
          </div>
          </div>



    </asp:Content>
