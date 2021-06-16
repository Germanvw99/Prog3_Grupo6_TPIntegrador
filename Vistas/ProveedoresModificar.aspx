<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresModificar.aspx.cs" Inherits="Vistas.ProveedoresModificar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
        <div class="container-fluid">
            <br />
            <nav aria-label="breadcrumb">
                <div class="card-body text-left">
                    <div class="mb-3">
                    </div>
                </div>
            </nav>
            <div class="row">
                <div class="col-12">
                    <div class="card shadow mb-4"">
                        <div class="card-header">
                            <h5 class="card-title mb-0">Modificar Proveedores</h5>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-12 col-xl-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h5 class="card-title">Datos actuales</h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <asp:Image ID="ImgLogo" Height="100px" Width="100" runat="server" class="img-fluid rounded-circle"/>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Razón Social</label>
                                            <asp:TextBox ID="TxtRazonSocial" type="text" runat="server" class="form-control" placeholder="Razón Social" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">DNI o CUIL</label>
                                            <asp:TextBox ID="TxtDni" type="text" runat="server" class="form-control" placeholder="DNI o CUIL" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Dirección</label>
                                            <asp:TextBox ID="TxtDireccion" type="text" runat="server" class="form-control" placeholder="Dirección" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Email</label>
                                            <asp:TextBox ID="TxtEmail" type="text" runat="server" class="form-control" placeholder="Email" ReadOnly="True" ></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Teléfono</label>
                                            <asp:TextBox ID="TxtTelefono" type="text" runat="server" class="form-control" placeholder="Teléfono" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Nombre del Contacto</label>
                                            <asp:TextBox ID="TxtContacto" type="text" runat="server" class="form-control" placeholder="Nombre del Contacto" ReadOnly="True" ></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Estado</label>
                                            <asp:TextBox ID="TxtEstado"  class="form-control" runat="server" ReadOnly="True" ></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-xl-6">
                                <div class="card">
                                    <div class="card-header">
                                        <h5 class="card-title">Nuevos datos </h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <label class="form-label">Razón Social</label>
                                            <asp:TextBox ID="TxtRazonSocialModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
<%--                                        <div class="form-group">
                                            <label class="form-label">DNI o CUIL</label>
                                            <asp:TextBox ID="TxtDniModificar" type="text" ReadOnly="true" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>--%>
                                        <div class="form-group">
                                            <label class="form-label">Dirección</label>
                                            <asp:TextBox ID="TxtDireccionModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Email</label>
                                            <asp:TextBox ID="TxtEmailModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Teléfono</label>
                                            <asp:TextBox ID="TxtTelefonoModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Nombre del Contacto</label>
                                            <asp:TextBox ID="TxtContactoModificar" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Estado</label>
                                            <br />
                                            <asp:DropDownList ID="DdlEstadoModificar"  class="custom-select form-control" runat="server" > </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Imágen</label>
                                            <div>
                                                <asp:FileUpload ID="FUProveedor" runat="server" />
                                            </div>
                                            <div class="form-group float-right">
                                                <button type="button" class="btn btn-secondary" data-mdb-dismiss="modal">Cancelar</button>&nbsp &nbsp
                                                <asp:Button ID="BtnModificarProveedor" class="btn btn-primary float-right" runat="server" Text="Modificar Proveedor" OnClick="BtnModificarProveedor_Click" />
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
</asp:Content>