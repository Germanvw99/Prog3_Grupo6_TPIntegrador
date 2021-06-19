<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedoresAgregar.aspx.cs" Inherits="Vistas.ProveedoresAgregar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                                            <h5 class="h2 card-title mb-0">Agregar Proveedor</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class ="row">
                                <div class="card-body card bg-light">
                                    <div class ="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Razón Social</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtRazonSocial" runat="server" ControlToValidate="TxtRazonSocial" ErrorMessage="*Debe ingresar un nombre de Razón Social" ForeColor="Red" ValidationGroup="agregar">*</asp:RequiredFieldValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtRazonSocial" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">DNI o CUIL</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtDni" runat="server" ControlToValidate="TxtDni" ErrorMessage="**Debe ingresar un DNI o CUIL" ForeColor="Red" ValidationGroup="agregar">**</asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RvTxtDni" runat="server" ControlToValidate="TxtDni" ErrorMessage="**Debe ingresar un número de hasta ocho dígitos" ForeColor="Red" MaximumValue="99999999" MinimumValue="1" Type="Integer" ValidationGroup="agregar">**</asp:RangeValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtDni" type="text" runat="server" class="form-control" placeholder="" ></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Dirección</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtDireccion" runat="server" ControlToValidate="TxtDireccion" ErrorMessage="***Debe ingresar una dirección" ForeColor="Red" ValidationGroup="agregar">***</asp:RequiredFieldValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtDireccion" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Email</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="****Debe ingresar un correo electrónico" ForeColor="Red" ValidationGroup="agregar">****</asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RevTxtEmail" runat="server" ControlToValidate="TxtEmail" ErrorMessage="****El correo electrónico no es válido" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="agregar">****</asp:RegularExpressionValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtEmail" type="text" runat="server" class="form-control" placeholder="" ></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label class="form-label">Teléfono</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtTelefono" runat="server" ControlToValidate="TxtTelefono" ErrorMessage="*****Debe ingresar un número telefónico" ForeColor="Red" ValidationGroup="agregar">*****</asp:RequiredFieldValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtTelefono" type="text" runat="server" class="form-control" placeholder=""></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Nombre del Contacto</label>
                                                <asp:RequiredFieldValidator ID="RfvTxtContacto" runat="server" ControlToValidate="TxtContacto" ErrorMessage="******Ingrese un nombre de contacto" ForeColor="Red" ValidationGroup="agregar">******</asp:RequiredFieldValidator>
                                                &nbsp;
                                                <asp:TextBox ID="TxtContacto" type="text" runat="server" class="form-control" placeholder="" ></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Estado</label>
                                                <asp:RequiredFieldValidator ID="RfvDdlEstados" runat="server" ControlToValidate="DdlEstados" ErrorMessage="*******Debe elegir un estado" ForeColor="Red" InitialValue="0" ValidationGroup="agregar">*******</asp:RequiredFieldValidator>
                                                <br />
                                                <asp:DropDownList ID="DdlEstados"  class="custom-select form-control"  runat="server" > </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="form-label">Imágen</label>
                                                <div>
                                                    <asp:FileUpload ID="FUProveedor" runat="server" />
                                                </div>
                                            </div>
                                            <asp:ValidationSummary ID="VsAgregarProveedor" runat="server" ForeColor="Red" ValidationGroup="agregar" />
                                            <asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Agregar Proveedor" OnClick="BtnAgregar_Click" ValidationGroup="agregar" />
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