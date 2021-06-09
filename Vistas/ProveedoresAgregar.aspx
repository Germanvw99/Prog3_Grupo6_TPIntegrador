<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresAgregar.aspx.cs" Inherits="Vistas.ProveedoresAgregar" %>
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
                            <h5 class="card-title mb-0">Agregar Proveedores</h5>
                        </div>
                        <div class="card-body">
                            <div class="form-group">
                                <label class="form-label">Nombre</label>
                                <asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">DNI o CUIL</label>
                                <asp:TextBox ID="TxtDni" type="text" runat="server" class="form-control" placeholder="DNI o CUIL" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Dirección</label>
                                <asp:TextBox ID="TxtDireccion" type="text" runat="server" class="form-control" placeholder="Dirección"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="TxtEmail" type="text" runat="server" class="form-control" placeholder="Email" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Teléfono</label>
                                <asp:TextBox ID="TxtTelefono" type="text" runat="server" class="form-control" placeholder="Teléfono"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Nombre del Contacto</label>
                                <asp:TextBox ID="TxtContacto" type="text" runat="server" class="form-control" placeholder="Nombre del Contacto" ></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Estado</label>
                                <br />
                                <asp:DropDownList ID="DdlEstados"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="form-label">Imágen</label>
                                <div>
                                    <input type="file" class="validation-file" name="validation-file">
                                </div>
                            </div>
                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar Marca" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
