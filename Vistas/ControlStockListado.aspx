<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlStockListado.aspx.cs" Inherits="Vistas.ControlStockListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
    <main class="content">
        <div class="container-fluid">
            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
                        <asp:LinkButton ID="IrListarUsuarios" runat="server" class="btn btn-outline-success" OnClick="IrListarUsuarios_Click">Listado de Usuarios</asp:LinkButton>
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
                                        <div class="col-md-6">
                                            <h5 class="h2 card-title mb-0">Control de stock</h5>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:LinkButton ID="LnAgregarStock" class="btn btn-outline-dark float-right" runat="server" OnClick="LnAgregarStock_Click">+ Agregar artículos al Stock</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-2 text-left">
                                            <label class="form-label">Buscar CUIL proveedor</label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar nombre proveedor</label>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <label class="form-label">Buscar código artículo</label>
                                        </div>
                                        <div class="col-md-5 text-left">
                                            <label class="form-label">Buscar nombre artículo</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-2 text-center">
                                            <asp:DropDownList ID="DdlProveedores" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtNombreProv" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <asp:DropDownList ID="DdlArticulos" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtNombreArt" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary" runat="server" Text="Buscar" OnClick="BtnFiltrar_Click" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnQuitarFiltro" class="btn btn-outline-primary" runat="server" Text="Quitar filtro" OnClick="BtnQuitarFiltro_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <asp:GridView ID="GrdControlStock" runat="server" AutoGenerateColumns="False"
                                        OnPreRender="GrdControlStock_PreRender"
                                        CssClass="table-striped dataTable dtr-inline table-hover row-border"
                                        OnRowCommand="GrdControlStock_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="CUIL">
                                                <ItemTemplate>
                                                    <asp:Label ID="axp_proveedor_dni"  runat="server" Text='<%# Bind("axp_proveedor_dni") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Razón Social">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_razon_social"  runat="server" Text='<%# Bind("pro_razon_social") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Articulo ID">
                                                <ItemTemplate>
                                                    <asp:Label ID="axp_articulo_codigo" runat="server" Text='<%# Eval("axp_articulo_codigo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Articulo Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="art_nombre" runat="server" Text='<%# Eval("art_nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Stock actual">
                                                <ItemTemplate>
                                                    <asp:Label ID="axp_stock_actual" runat="server" Text='<%# Eval("axp_stock_actual") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Precio unitario">
                                                <ItemTemplate>
                                                    <asp:Label ID="axp_precio_unitario" runat="server" Text='<%# Eval("axp_precio_unitario") %>' />
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
    </main>
    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
    <!-- DATATABLE JQUERY JAVASCRIPT -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= GrdControlStock.ClientID %>').dataTable({
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