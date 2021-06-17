<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentasListado.aspx.cs" Inherits="Vistas.VentasListado" %>
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
                                            <h5 class="h2 card-title mb-0">Listado de ventas</h5>
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar cliente</label>
                                        </div>

                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar artículo</label>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <label class="form-label">Buscar marca</label>
                                        </div>
                                        <div class="col-md-4 text-left">
                                            <label class="form-label">Buscar categoría</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtCliente" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtArticulo" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <asp:DropDownList ID="DdlMarcas" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <asp:DropDownList ID="DdlCategorias" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary" runat="server" Text="Buscar" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnQuitarFiltro" class="btn btn-outline-primary" runat="server" Text="Quitar filtro" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                            <asp:GridView ID="GrdVentas" runat="server" AutoGenerateColumns="False"
                                OnPreRender="GrdVentas_PreRender"
                                CssClass="table-striped dataTable dtr-inline table-hover row-border"
                                OnRowCommand="GrdVentas_RowCommand">
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
                            </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
    <!-- MODAL VER-->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="text-center">
                        <asp:Image ID="ImgLogo" Height="200px" Width="200px" runat="server" class="img-fluid rounded-circle"/>
                    </div>
                    <div class="form-group">
                        <label>Nombre</label>
                        <asp:TextBox ID="TxtNombreModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Marca</label>
                        <asp:TextBox ID="TxtMarcaNombre" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Precio</label>
                        <asp:TextBox ID="TxtPrecioListaModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descripción</label>
                        <asp:TextBox ID="TxtDescripcionModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Categoria</label>
                        <asp:TextBox ID="TxtCategoriaNombre" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Código de artículo</label>
                        <asp:TextBox ID="TxtCodigoModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Punto de pedido</label>
                        <asp:TextBox ID="TxtPuntoPedidoModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:TextBox ID="TxtEstadoModal" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                </div>
                <!-- Modal footer -->
            </div>
        </div>
    </div>
    <!-- MODAL ELIMINAR-->

    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
    <!-- DATATABLE JQUERY JAVASCRIPT -->
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= GrdVentas.ClientID %>').dataTable({
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