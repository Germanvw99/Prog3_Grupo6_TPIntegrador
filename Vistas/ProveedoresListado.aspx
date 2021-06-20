<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresListado.aspx.cs" Inherits="Vistas.ProveedoresListado" %>
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
                                        <div class="col-md-6">
                                            <h5 class="h2 card-title mb-0">Listado de Proveedores</h5>
                                        </div>
                                        <div class="col-md-6">
                                            <asp:LinkButton ID="LnAgregarProveedor" class="btn btn-outline-dark float-right" runat="server" OnClick="LnAgregarProveedor_Click">+ Agregar Proveedor</asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class="row">
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar por CUIL</label>
                                            <asp:RangeValidator ID="RvTxtCodigo" runat="server" ControlToValidate="TxtCodigo" ErrorMessage="*Ingrese un número válido (de ocho dígitos)" ForeColor="Red" MaximumValue="99999999" MinimumValue="0" Type="Integer" ValidationGroup="buscar">*</asp:RangeValidator>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar por nombre</label>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <label class="form-label">Buscar por estado</label>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtCodigo" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-md-3 text-left">
                                            <asp:DropDownList ID="DdlEstados" class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="col-md-3 text-center">
                                            <asp:Button ID="BtnFiltrar" class="btn btn-outline-primary" runat="server" Text="Filtrar búsqueda" OnClick="BtnFiltrar_Click" ValidationGroup="buscar" />
                                            &nbsp;&nbsp;
                                            <asp:Button ID="BtnQuitarFiltro" class="btn btn-outline-primary" runat="server" Text="Quitar filtro" OnClick="BtnQuitarFiltro_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <asp:ValidationSummary ID="VsBuscar" runat="server" ForeColor="Red" ValidationGroup="buscar" />
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <asp:GridView ID="GrdProveedores" runat="server" AutoGenerateColumns="False"
                                        OnPreRender="GrdProveedores_PreRender"
                                        CssClass="table-striped dataTable dtr-inline table-hover row-border"
                                        OnRowCommand="GrdProveedores_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="CUIL">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_dni" runat="server" Text='<%# Eval("pro_dni") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Logo">
                                                <ItemTemplate>
                                                    <asp:Image ID="pro_ruta_imagen" Height="50px" Width="50px" runat="server" ImageUrl='<%# Eval("pro_ruta_imagen") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Razón Social">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_razon_social" runat="server" Text='<%# Eval("pro_razon_social") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dirección">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_direccion" runat="server" Text='<%# Eval("pro_direccion") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Correo">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_email" runat="server" Text='<%# Eval("pro_email") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Teléfono">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_telefono" runat="server" Text='<%# Eval("pro_telefono") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contacto">
                                                <ItemTemplate>
                                                    <asp:Label ID="pro_nombre_contacto" runat="server" Text='<%# Eval("pro_nombre_contacto") %>' />
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
                        <asp:Image ID="ImgLogo" Height="200px" Width="200px" runat="server" class="img-fluid"/>
                    </div>
                    <div class="form-group">
                        <label>Razón Social</label>
                        <asp:TextBox ID="TxtRazonSocial" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>CUIL</label>
                        <asp:TextBox ID="TxtCuil" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Dirección</label>
                        <asp:TextBox ID="TxtDireccion" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Email</label>
                        <asp:TextBox ID="TxtMail" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Teléfono</label>
                        <asp:TextBox ID="TxtTelefono" runat="server" class="form-control form-control-lg"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label>Nombre del Contacto</label>
                        <asp:TextBox ID="TxtNombreContacto" runat="server" class="form-control form-control-lg"></asp:TextBox>
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
                            Está a punto de eliminar un proveeedor, este procedimiento es irreversible. ¿Quiere proceder?
                        </div>
                        <br />
                        <div class="text-center">
                            <asp:Image ID="ImageModalEliminar" Height="200px" Width="200px" runat="server" class="img-fluid rounded-circle"/>
                        </div>
                        <div class="form-group text-center">
                            <asp:Label ID="TxtNombreModalEliminar" runat="server" ReadOnly="true" class ="form-control form-control-lg"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <asp:Button runat="server" ID="BtnEliminarProveedor" type="button" class="btn btn-warning" data-mdb-dismiss="modal"  Text="Eliminar" OnClick="BtnEliminarProveedor_Click" ></asp:Button>
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
        	$('#<%= GrdProveedores.ClientID %>').dataTable({
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