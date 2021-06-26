<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ConfirmarPedido.aspx.cs" Inherits="Vistas.ConfirmarPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<main>
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
                                        <asp:RangeValidator ID="RfvRangoDireccionPago" runat="server" ControlToValidate="txtDireccionPago" ErrorMessage="*Debe ingresar una direccion válida" ForeColor="Red" MaximumValue="99999999" MinimumValue="999" ValidationGroup="VgPedido" Type="Integer">*</asp:RangeValidator>
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
                                <div class="justify-content-center mb-3">
                                    <asp:GridView ID="GvCarro" runat="server"  CssClass="table display"></asp:GridView>
                                </div> 
                                <hr />
                                <div class="d-flex justify-content-around">
                                    <h4>Productos</h4>
                                    <asp:Label ID="lblCantProductos" runat="server" Text="$0.00" Font-Size="22px"></asp:Label>
                                </div>
                                <hr />
                                <div class="d-flex justify-content-around">
                                    <h3>Total a Pagar</h3>
                                    <asp:Label ID="lblMontoPagar" runat="server" Text="$0.00" Font-Size="30px"></asp:Label>
                                </div>
                                <hr />
                                <asp:Button ID="btnComprar" runat="server" CssClass="btn btn-primary btn-block" Text="Confirmar Pedido" ValidationGroup="VgPedido" OnClick="btnComprar_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
    </div>
</main>
    <!-- MODAL PEDIDO COMPLETO-->
    <div class="modal fade" id="myModal">
        <div class="modal-dialog">
           <div class="modal-content">
                <!-- Modal Header -->
                <div class="modal-header">
                    <h4 class="modal-title">Pedido Completado!</h4>
                    <button type="button" class="close" data-dismiss="modal">×</button>
                </div>
                <!-- Modal body -->
                <div class="modal-body">
                    <div class="form-group">
                        <div class="text-left">
                            Su pedido se realizó con exito, muchas gracias por confiar en nosotros!
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="form-group">
                        <%--BOTONES VER - EDITAR - ELIMINAR--%>
                        <asp:Button runat="server" ID="BtnSalirPedido" type="button" class="btn btn-primary" data-mdb-dismiss="modal"  Text="Ok" OnClick="BtnSalirPedido_Click" ></asp:Button>
                    </div>
                </div>
            </div>
        </div>
    </div>
        <script src="Recursos/js/jquery-3.6.0.min.js"></script>
    <script src="Recursos/js/jquery.dataTables.min.js"></script>
    <script src="Recursos/js/popper.min.js"></script>
    <script src="Recursos/js/bootstrap.min.js"></script>
</asp:Content>
