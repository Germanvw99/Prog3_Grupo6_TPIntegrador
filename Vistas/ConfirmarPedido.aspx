<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfirmarPedido.aspx.cs" Inherits="Vistas.ConfirmarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="main-body">
            <h2 class="text-center mt-4">Confirmar Pedido</h2>
                <div class="row gutters-sm mt-4">
				    <div class="col-md-6 mb-3">
                        <div class="card mb-3">
					        <div class="card-body">
                                <h4>Detalles de Pago</h4>
                                <hr />
                                <div class="row mb-4">
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">Dni</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtDni" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">Usuario</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">Nombre</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">Apellido</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                </div>
                                <div class="row mb-4">
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">C. P.</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtCodigo_Postal" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                    <div class="col-6 d-flex align-items-center">
                                        <div class="col-4">
						                    <h6 class="mb-0">Direccion</h6>
						                </div>
						                <div class="col-8 text-secondary form-group p-0 m-0">
						                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'></asp:TextBox>
						                </div>
                                    </div>
                                </div>
                                <div class="row mb-4 align-items-center">
                                    <div class="col-sm-3">
						                <h6 class="mb-0">Método de Pago</h6>
						            </div>
                                    <div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
                                        <asp:DropDownList ID="DdlPago" runat="server" CssClass="form-select"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RfvMetodoPago" runat="server" ControlToValidate="DdlPago" ErrorMessage="Método de pago invalido" ForeColor="Red" ValidationGroup="VgPedido" InitialValue="-1">*</asp:RequiredFieldValidator>
						            </div>
                                </div>
                                <div class="row mb-4 align-items-center">
                                    <div class="col-sm-3">
						                <h6 class="mb-0">Dirección de Pago</h6>
						            </div>
                                    <div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
                                        <asp:TextBox ID="txtDireccionPago" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgPedido"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RfvDireccionPago" runat="server" ControlToValidate="txtDireccionPago" ErrorMessage="Direccion de pago invalida" ForeColor="Red" ValidationGroup="VgPedido">*</asp:RequiredFieldValidator>
						            </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 mb-3">
                        <div class="card mb-3">
					        <div class="card-body">
                                <h4>Su Orden</h4>
                                <hr />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
