<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuariosListado.aspx.cs" Inherits="Vistas.UsuariosAdministrar" %>
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
                                            <h5 class="h2 card-title mb-0">Listado de Artículos</h5>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:LinkButton ID="LnAgregarArticulos" class="btn btn-outline-dark float-right" runat="server">+ Agregar Artículos</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar por Dni</label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar por Username</label>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <label class="form-label">Buscar por Provincia</label>
                                        </div>
                                        <div class="col-md-4 text-left">
                                            <label class="form-label">Buscar por Estado</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtCodigo" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtNombre1" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <asp:DropDownList ID="DdlMarcas" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 text-left">
                                            <asp:DropDownList ID="DdlCategorias" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary" runat="server" Text="Buscar"  />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnQuitarFiltro" class="btn btn-outline-primary" runat="server" Text="Quitar filtro" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <asp:GridView ID="GrdUsuarios" runat="server" AutoGenerateColumns="False"
                                        OnPreRender="GrdUsuarios_PreRender"
                                        OnRowCommand="GrdUsuarios_RowCommand"
                                        CssClass="table-striped dataTable dtr-inline table-hover row-border">
								<Columns>
									<asp:TemplateField HeaderText="Dni">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_dni" runat="server" Text='<%# Eval("usu_dni") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Imagen">
                                                <ItemTemplate>
                                                    <asp:Image ID="usu_ruta_imagen" Height="50px" Width="50px" runat="server" ImageUrl='<%# Bind("usu_ruta_imagen") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Username">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_username" runat="server" Text='<%# Eval("usu_username") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Nombre">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_nombre" runat="server" Text='<%# Eval("usu_nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Apellido">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_apellido" runat="server" Text='<%# Eval("usu_apellido") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_email" runat="server" Text='<%# Eval("usu_email") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Ciudad">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_ciudad" runat="server" Text='<%# Eval("usu_ciudad") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Provincia">
                                                <ItemTemplate>
                                                    <asp:Label ID="usu_provincia" runat="server" Text='<%# Eval("usu_provincia") %>' />
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
						<asp:Image ID="ProfilePic" Height="200px" Width="200px" runat="server" class="img-fluid"/>
					</div>
                    <div class="row d-flex mt-3">
                        <div class="form-group col-md-6">
                            <label>Dni Personal</label>
						    <asp:TextBox ID="TxtDni" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Username</label>
						    <asp:TextBox ID="TxtUsername" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row d-flex">
                        <div class="form-group col-md-6">
                            <label>Nombre</label>
						    <asp:TextBox ID="TxtNombre" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Apellido</label>
						    <asp:TextBox ID="TxtApellido" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row d-flex">
                        <div class="form-group col-md-6">
                            <label>Telefono</label>
						    <asp:TextBox ID="TxtTelefono" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Email</label>
						    <asp:TextBox ID="TxtEmail" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row d-flex">
                        <div class="form-group col-md-6">
                            <label>Ciudad</label>
						    <asp:TextBox ID="TxtCiudad" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Provincia</label>
						    <asp:TextBox ID="TxtProvincia" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row d-flex">
                        <div class="form-group col-md-6">
                            <label>Codigo Postal</label>
						    <asp:TextBox ID="TxtCodigo_Postal" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Estado</label>
						    <asp:TextBox ID="TxtEstado" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row d-flex">
                        <div class="form-group col-md-6">
                            <label>Direccion</label>
						    <asp:TextBox ID="txtDireccion" runat="server" class="form-control"></asp:TextBox>
                        </div>
                        <div class="form-group col-md-6">
                            <label>Tipo de Usuario</label>
						    <asp:TextBox ID="TxtCodigo_Perfil" runat="server" class="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>  
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
                            Está a punto de eliminar un usuario, este procedimiento es irreversible. ¿Quiere proceder?
                        </div>
                        <br />
                        <div class="text-center">
                            <asp:Image ID="ImageModalEliminar" Height="200px" Width="200px" runat="server" class="img-fluid rounded-circle"/>
                        </div>
                        <div class="row d-flex mt-3">
                            <div class="form-group col-md-6">
                                <label>Dni Personal</label>
						        <asp:TextBox ID="txtDniEliminar" runat="server" class="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group col-md-6">
                                <label>Username</label>
						        <asp:TextBox ID="txtUsernameEliminar" runat="server" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <%--BOTONES VER - EDITAR - ELIMINAR--%>
                        <asp:Button runat="server" ID="BtnEliminarUsuario" type="button" class="btn btn-warning" data-mdb-dismiss="modal"  Text="Eliminar" OnClick="BtnEliminarUsuario_Click" ></asp:Button>
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
        	$('#<%= GrdUsuarios.ClientID %>').dataTable({
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
