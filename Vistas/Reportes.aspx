<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Vistas.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
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
                                        <div class="col-md-12">
                                            <h5 class="h2 card-title mb-0">Reporte de ventas</h5>
                                            <p class="h2 card-title mb-0">&nbsp;</p>
                                            <h6 class="h4 card-title mb-0">
                                                <asp:Label ID="LblMensaje" runat="server"></asp:Label>
                                            </h6>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <asp:ValidationSummary ID="VsBuscar" runat="server" ForeColor="Red" ValidationGroup="buscar" />
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-2 text-left">
                                            <div class="card">
                                                <div class="card-body">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnHoy" runat="server" Text="Hoy" class="btn btn-outline-primary btn-block" OnClick="BtnHoy_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnUltimaSemana" runat="server" Text="Últimos 7 días" class="btn btn-outline-primary btn-block" OnClick="BtnUltimaSemana_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnEsteMes" runat="server" Text="Este mes" class="btn btn-outline-primary btn-block" OnClick="BtnEsteMes_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnUltimoMes" runat="server" Text="Últimos 30 días" class="btn btn-outline-primary btn-block" OnClick="BtnUltimoMes_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnEsteAnio" runat="server" Text="Este año" class="btn btn-outline-primary btn-block" OnClick="BtnEsteAnio_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <h3 class="text-center">Personalizado</h3>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Desde:
                                                                <asp:TextBox ID="TxtFechaInicio" ReadOnly="true" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="ImageButtonInicio" runat="server" ImageUrl="Recursos/img/calendar.png" ImageAlign="AbsBottom" OnClick="ImageButtonInicio_Click" />
                                                                <asp:Calendar ID="CalendarInicio" runat="server" Height=" 200px" Width="200px" OnSelectionChanged="CalendarInicio_SelectionChanged"></asp:Calendar>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                Hasta:
                                                                <asp:TextBox ID="TxtFechaFinal" ReadOnly="true" runat="server" Width="120px"></asp:TextBox>
                                                                <asp:ImageButton ID="ImageButtonFinal" runat="server" ImageUrl="Recursos/img/calendar.png" ImageAlign="AbsBottom" OnClick="ImageButtonFinal_Click" />
                                                                <asp:Calendar ID="CalendarFinal" runat="server" Height=" 200px" Width="200px" OnSelectionChanged="CalendarFinal_SelectionChanged"></asp:Calendar>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Button ID="BtnSolicitud" runat="server" Text="Solicitud" class="btn btn-outline-primary btn-block" OnClick="BtnSolicitud_Click" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-10 text-left">
                                            <div class="row">
                                                <div class="col-md-3 col-lg-3 col-xl">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="row">
                                                                <div class="col mt-0">
                                                                    <h5 class="card-title">Ingresos $</h5>
                                                                    <p class="card-title">
                                                                        <asp:Label ID="LblIngresos" runat="server" Text=""></asp:Label>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3 col-lg-3 col-xl">
                                                    <div class="card">
                                                        <div class="card-body">
                                                            <div class="row">
                                                                <div class="col mt-0">
                                                                    <h5 class="card-title">Ventas</h5>
                                                                    <p class="card-title">
                                                                        <asp:Label ID="LblVentas" runat="server"></asp:Label>
                                                                    </p>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <br />
                                            <div class="card">
                                                <div class="card-body">
                                                    <asp:GridView ID="GrdReportes" runat="server" AutoGenerateColumns="False"
                                                        OnPreRender="GrdReportes_PreRender"
                                                        CssClass="table-striped dataTable dtr-inline table-hover row-border">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Fact.">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ven_codigo" runat="server" Text='<%# Eval("ven_codigo") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Fecha">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ven_fecha" runat="server" Text='<%# Eval("ven_fecha") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Cliente">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="usu_apellido" runat="server" Text='<%# Eval("usu_apellido") + ", "+Eval("usu_nombre")  %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Facturado">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="ven_total_facturado" class="text-right" runat="server" Text='<%# Eval("ven_total_facturado") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
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
    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
    <!-- DATATABLE JQUERY JAVASCRIPT -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= GrdReportes.ClientID %>').dataTable({
                "aLengthMenu": [[6, 25, 50, -1], [6, 25, 50, "All"]],
                "iDisplayLength": 6,
                "order": [[3, "asc"]],
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