<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosListado.aspx.cs" Inherits="Vistas.ArticulosListado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
    <link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
    <main class="content">
        <div class="container-fluid">
            <br />
            <%--            <nav aria-label="breadcrumb">--%>
            <%--                <div class="card-body text-left">
                <div class="mb-3">--%>
            <%--						<div class="row">
                <div class="col-md-6">
                		<asp:LinkButton ID="IrListarArticulos" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listado de Artículos</asp:LinkButton>
                		<asp:LinkButton ID="IrListarMarcas" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listado de Marcas</asp:LinkButton>
                		<asp:LinkButton ID="IrListarCategorias" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listado de Categorías</asp:LinkButton>
                		<asp:LinkButton ID="IrListarProveedores" runat="server" class="btn btn-outline-primary" OnClick="IrListarProveedores_Click">Listado de Proveedores</asp:LinkButton>
                	</div>
                <div class="col-md-6">
                		<asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-outline-primary" OnClick="IrListarArticulos_Click">Listado de Artículos</asp:LinkButton>
                		<asp:LinkButton ID="LinkButton2" runat="server" class="btn btn-outline-warning" OnClick="IrListarMarcas_Click">Listado de Marcas</asp:LinkButton>
                		<asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-outline-success" OnClick="IrListarCategorias_Click">Listado de Categorías</asp:LinkButton>
                		<asp:LinkButton ID="LinkButton4" runat="server" class="btn btn-outline-primary" OnClick="IrListarProveedores_Click">Listado de Proveedores</asp:LinkButton>
                	</div>
                			</div>--%>
            <%--                    </div>
                </div>--%>
            <%--            </nav>--%>
            <div class="row">
                <div class="col-12">
                    <div class="card shadow mb-4"">
                        <div class="card-header">
                            <div class ="row">
                                <div class="col-md-6">
                                    <h5 class="h2 card-title mb-0">Listado de Artículos</h5>
                                </div>
                                <div class="col-md-6">
                                    <asp:LinkButton ID="LnAgregarArticulos" class="btn btn-outline-dark float-right" runat="server" OnClick="LnAgregarArticulos_Click">+ Agregar Artículos</asp:LinkButton>
                                </div>
                            </div>
                            <div class="row ">
                                <div class="col-md-2 text-left">
                                    <div class="card-body">
                                        <selected class="form-group">
                                            <label class="form-label">Marcas</label>
                                            <asp:DropDownList ID="DdlMarcas"  class="custom-select form-control" runat="server" value="Marca" > </asp:DropDownList>
                                        </selected>
                                    </div>
                                </div>
                                <div class="col-md-2 text-left">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label class="form-label">Categorías</label>
                                            <asp:DropDownList ID="DdlCategorias" class="custom-select form-control" runat="server" > </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 text-left">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label class="form-label">Código</label>
                                            <asp:TextBox ID="TxtCodigo" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4 text-left">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label class="form-label">Nombre</label>
                                            <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 text-left">
                                    <div class="card-body">
                                        <div class="form-group">
                                            <br />
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary float-left" runat="server" Text="Filtrado" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:GridView ID="GrdArticulos" runat="server" AutoGenerateColumns="False"
                                OnPreRender="GrdArticulos_PreRender"
                                CssClass="table display" OnRowCommand="GrdArticulos_RowCommand" OnSelectedIndexChanged="GrdArticulos_SelectedIndexChanged">
                                <Columns>
                                    <asp:TemplateField HeaderText="Código">
                                        <ItemTemplate>
                                            <asp:Label ID="art_codigo" runat="server" Text='<%# Eval("art_codigo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Foto">
                                        <ItemTemplate>
                                            <asp:Image ID="art_ruta_imagen" Height="50px" Width="50px" runat="server" ImageUrl='<%# Bind("art_ruta_imagen") %>' />
                                            <asp:HiddenField ID="urlImage" runat="server" Value='<%# Eval("art_ruta_imagen") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label ID="art_nombre" runat="server" Text='<%# Eval("art_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <asp:Label ID="art_descripcion" runat="server" Text='<%# Eval("art_descripcion") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Punto de Pedido">
                                        <ItemTemplate>
                                            <asp:Label ID="art_punto_pedido" runat="server" Text='<%# Eval("art_punto_pedido") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio">
                                        <ItemTemplate>
                                            <asp:Label ID="art_precio_lista" runat="server" Text='<%# Eval("art_precio_lista") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Estado">
                                        <ItemTemplate>
                                            <asp:Label ID="est_nombre" runat="server" Text='<%# Eval("est_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Marca">
                                        <ItemTemplate>
                                            <asp:Label ID="mar_nombre" runat="server" Text='<%# Eval("mar_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categoría">
                                        <ItemTemplate>
                                            <asp:Label ID="cat_nombre" runat="server" Text='<%# Eval("cat_nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--BOTONES VER - EDITAR - ELIMINAR--%>
                                    <asp:ButtonField ButtonType="Image" CommandName="eventoVer" ImageUrl="Recursos/img/ver.png" />
                                    <asp:ButtonField ButtonType="Image" CommandName="eventoAgregarCarrito" ImageUrl="Recursos/img/ca.png" />
                                    <asp:ButtonField ButtonType="Image" CommandName="eventoEditar" ImageUrl="Recursos/img/editar.png" />
                                    <asp:ButtonField ButtonType="Image" CommandName="eventoEliminar" ImageUrl="Recursos/img/eliminar.png" />
                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
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
    <div class="modal fade" id="myModalEliminar">
        <div class="modal-dialog">
            <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <div class="text-center">
                        <h5 class="modal-title" >Atención</h5>
                    </div>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <div class="text-left">
                            Está a punto de eliminar un artículo, este procedimiento es irreversible. ¿Quiere proceder?
                        </div>
                        <br />
                        <div class="form-group">
                            <asp:TextBox ID="TxtNombreModalEliminar" runat="server" class="form-control form-control-lg"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <button type="button" class="btn btn-secondary" data-mdb-dismiss="modal">Cancelar</button>
                        <button type="button" class="btn btn-warning">Eliminar</button>
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
        	$('#<%= GrdArticulos.ClientID %>').dataTable({
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