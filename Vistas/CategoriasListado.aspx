<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoriasListado.aspx.cs" Inherits="Vistas.CategoriasListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
    <main class="content">
        <div class="container-fluid">
            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
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
                                            <h5 class="h2 card-title mb-0">Listado de Categorías</h5>
                                        </div>
                                        <div class="col-md-6">
											<asp:LinkButton ID="LnAgregarCategorias" class="btn btn-outline-dark float-right" runat="server" OnClick="LnAgregarCategorias_Click">+ Agregar Categorías</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-6 text-left">
                                            <label class="form-label">Buscar categoría por nombre o código</label>
                                        </div>
                                        <div class="col-md-6 text-left">
                                            <label class="form-label">Buscar categoría por estado</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 text-center">
                                            <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:DropDownList ID="DdlEstados" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary" runat="server" Text="Filtrar búsqueda" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnQuitarFiltro" class="btn btn-outline-primary" runat="server" Text="Quitar filtro" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <asp:GridView ID="GrdCategorias" runat="server" AutoGenerateColumns="False"
                                        OnPreRender="GrdCategorias_PreRender"
                                        CssClass="table-striped dataTable dtr-inline table-hover row-border"
                                        OnRowCommand="GrdCategorias_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Código">
                                                <ItemTemplate>
                                                    <asp:Label ID="cat_codigo" runat="server" Text='<%# Eval("cat_codigo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Logo">
                                                <ItemTemplate>
                                                    <asp:Image ID="cat_ruta_imagen" Height="50px" Width="50px" runat="server" ImageUrl='<%# Bind("cat_ruta_imagen") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="cat_nombre" runat="server" Text='<%# Eval("cat_nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Eslogan">
                                                <ItemTemplate>
                                                    <asp:Label ID="cat_descripcion" runat="server" Text='<%# Eval("cat_descripcion") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Estado">
                                                <ItemTemplate>
                                                    <asp:Label ID="est_nombre" runat="server" Text='<%# Eval("est_nombre") %>' />
                                                    <asp:Label ID="est_codigo" visible="false" runat="server" type="Hidden" Text='<%# Eval("est_codigo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--BOTONES VER - EDITAR - ELIMINAR--%>
                                            <asp:ButtonField ButtonType="Image" CommandName="eventoVerDetalle" ImageUrl="Recursos/img/ver.png" />
                                            <asp:ButtonField ButtonType="Image" CommandName="eventoEditar" ImageUrl="Recursos/img/editar.png" />
                                            <asp:ButtonField ButtonType="Image" CommandName="eventoEliminar" ImageUrl="Recursos/img/eliminar.png" />
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
    <!-- MODAL -->
    <div id="myModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Detalles</h4>
                    <button type="button" class="close" data-dismiss="modal">×</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="text-center">
                        <asp:Image ID="ImgLogo" Height="200px" Width="200px" runat="server" class="img-fluid rounded-circle"/>
                    </div>
                    <div class="form-group">
                        <label>Nombre</label>
                        <asp:TextBox ID="TxtNombreModal" runat="server" ReadOnly="true" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Descripción</label>
                        <asp:TextBox ID="TxtDescripcionModal" runat="server" ReadOnly="true" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Código</label>
                        <asp:TextBox ID="TxtCodigoModal" runat="server" ReadOnly="true" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Estado</label>
                        <asp:TextBox ID="TxtEstadoModal" runat="server" ReadOnly="true" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                </div>
                <!-- Modal footer -->
            </div>
        </div>
    </div>
    <!-- MODAL ELIMINAR-->
    <div class="modal fade" id="myModalEliminar">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Atención</h4>
                    <button type="button" class="close" data-dismiss="modal">×</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <div class="text-left">
                            Está a punto de eliminar una marca, este procedimiento es irreversible. ¿Quiere proceder?
                        </div>
                        <br />
                        <div class="text-center">
                            <asp:Image ID="ImageModalEliminar" Height="200px" Width="200px" runat="server" class="img-fluid rounded-circle"/>
                        </div>
                        <div class="form-group text-center">
                            <asp:Label ID="TxtNombreModalEliminar" runat="server" ReadOnly="true" class ="form-control form-control-lg"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>Código</label>
                            <asp:TextBox ID="TxtCodigoModalEliminar" ReadOnly="true" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <%--BOTONES VER - EDITAR - ELIMINAR--%>
                        <asp:Button runat="server" ID="BtnEliminarCategoria" type="button" class="btn btn-warning" data-mdb-dismiss="modal"  Text="Eliminar" OnClick="BtnEliminarCategoria_Click" ></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
    <!-- DATATABLE JQUERY JAVASCRIPT -->
    <script type="text/javascript">
        $(document).ready(function () {
        	$('#<%= GrdCategorias.ClientID %>').dataTable({
                "aLengthMenu": [[6, 25, 50, -1], [6, 25, 50, "All"]],
                "iDisplayLength": 6,
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