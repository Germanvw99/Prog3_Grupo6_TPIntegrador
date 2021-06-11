<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentasListado.aspx.cs" Inherits="Vistas.VentasListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
    <main class="content">
        <div class="container-fluid">
            <br />
            <div class="row">
                <div class="col-12">
                    <div class="card shadow mb-4"">
                        <div class="card-header">
                            <div class ="row">
                                <div class="col-md-6">
                                    <h5 class="h2 card-title mb-0">Listado de Ventas</h5>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="GrdVentas" runat="server" AutoGenerateColumns="False"
                                OnPreRender="GrdVentas_PreRender"
                                CssClass="table display" OnRowCommand="GrdVentas_RowCommand" CellPadding="4" ForeColor="#333333" GridLines="None">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:TemplateField HeaderText="N° Factura">
                                        <ItemTemplate>
                                            <asp:Label ID="ven_codigo" runat="server" Text='<%# Eval("ven_codigo") %>' />
                                            <asp:HiddenField ID="usu_direccion" runat="server" Value='<%# Eval("usu_direccion") %>' />
                                            <asp:HiddenField ID="usu_ciudad" runat="server" Value='<%# Eval("usu_ciudad") %>' />
                                            <asp:HiddenField ID="ven_medio_pago_codigo" runat="server" Value='<%# Eval("ven_medio_pago_codigo") %>' />
                                            <%--<asp:HiddenField ID="ven_fecha_requerida" runat="server" Value='<%# Eval("ven_fecha_requerida") %>' />
                                                <asp:HiddenField ID="ven_fecha_envio" runat="server" Value='<%# Eval("ven_fecha_envio") %>' />--%>
                                            <asp:HiddenField ID="ven_codigo_estado" runat="server" Value='<%# Eval("ven_codigo_estado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DNI Cliente">
                                        <ItemTemplate>
                                            <asp:Label ID="ven_usuarios_dni" runat="server" Text='<%# Eval("ven_usuarios_dni") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Apellido">
                                        <ItemTemplate>
                                            <asp:Label ID="usu_apellido" runat="server" Text='<%# Eval("usu_apellido") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="usu_nombre" runat="server" Text='<%# Eval("usu_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medio de pago">
                                        <ItemTemplate>
                                            <asp:Label ID="mp_nombre" runat="server" Text='<%# Eval("mp_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fecha">
                                        <ItemTemplate>
                                            <asp:Label ID="ven_fecha" runat="server" Text='<%# Eval("ven_fecha") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Facturado">
                                        <ItemTemplate>
                                            <asp:Label ID="ven_total_facturado" class="text-right" runat="server" Text='<%# Eval("ven_total_facturado") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:Label ID="est_nombre" runat="server" Text='<%# Eval("est_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- BOTON VER --%>
                                    <asp:ButtonField ButtonType="Image" CommandName="eventoVerDetalles" ImageUrl="Recursos/img/ver.png" />
                                </Columns>
                                <EditRowStyle BackColor="#999999" />
                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
    <!-- DATATABLE JQUERY JAVASCRIPT -->
    <script type="text/javascript">
        $(document).ready(function () {
        	$('#<%= GrdVentas.ClientID %>').dataTable({
                "aLengthMenu": [[10, 50, 75, -1], [10, 50, 75, "All"]],
                "iDisplayLength": 10,
                "order": [[1, "asc"]],
                stateSave: true,
                stateSaveCallback: function (settings, data) {
                    localStorage.setItem
                        ('DataTables_' + settings.sInstance, JSON.stringify(data));
                },
                stateLoadCallback: function (settings) {
                    return JSON.parse
                        (localStorage.getItem('DataTables_' + settings.sInstance));
                },

                language: {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "Ningún dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sSearch": "Buscar:",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    },
                    "buttons": {
                        "copy": "Copiar",
                        "colvis": "Visibilidad"
                    }
                }
            });
        });
    </script>
</asp:Content>