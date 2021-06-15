<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
	<link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />
    <link href="Recursos/css/estilos.css" rel="stylesheet" />
	<main class="content">

		<div class="container">
			<div class="main-body">
			  <div class="row gutters-sm mt-4">
				<div class="col-md-5 mb-3">
				  <div class="card">
					<div class="card-body">
					  <div class="d-flex flex-column align-items-center text-center">
						<img src="Recursos/img/avatar.png" class="img-fluid rounded-circle mb-2" alt="imagen del usuario" id="img_user0" />
						<div class="mt-3">
							<asp:Label ID="lblUsername" runat="server" Text="Label"></asp:Label>
						</div>
					  </div>
					</div>
				  </div>
				  <div class="card mt-5">
					<div class="card-body pt-5 pb-5">
					  <h2 class="mt-3 mb-5"> Modificar Contraseña </h2>
						<div class="row">
							<div class="col-sm-3">
								<h6 class="mb-0">Actual</h6>
							</div>
							<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
								<asp:TextBox ID="txtAntiguaPassword" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="vgEditarPassword"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RfvAntiguaPassword" runat="server" ControlToValidate="txtAntiguaPassword" ErrorMessage="Antigua Contraseña invalida" ForeColor="Red" ValidationGroup="vgEditarPassword">*</asp:RequiredFieldValidator>
							</div>
						</div>
						<hr>
						<div class="row">
							<div class="col-sm-3">
								<h6 class="mb-0">Nueva</h6>
							</div>
							<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
								<asp:TextBox ID="txtNuevaPassword" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="vgEditarPassword"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RfvNuevaPassword" runat="server" ControlToValidate="txtNuevaPassword" ErrorMessage="Nueva Contraseña invalida" ForeColor="Red" ValidationGroup="vgEditarPassword">*</asp:RequiredFieldValidator>
							</div>
						</div>
						<hr>
						<div class="row">
							<div class="col-sm-3">
								<h6 class="mb-0">Verifique</h6>
							</div>
							<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
								<asp:TextBox ID="txtVerificacionPassword" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="vgEditarPassword"></asp:TextBox>
								<asp:RequiredFieldValidator ID="RfvVerificacionPassword" runat="server" ControlToValidate="txtVerificacionPassword" ErrorMessage="Verificacion invalida" ForeColor="Red" ValidationGroup="vgEditarPassword">*</asp:RequiredFieldValidator>
								<asp:CompareValidator ID="CvRepeatPassword" runat="server" ErrorMessage="Las contraseñas no son iguales" ControlToCompare="txtVerificacionPassword" ControlToValidate="txtNuevaPassword" ForeColor="Red" ValidationGroup="vgEditarPassword">*</asp:CompareValidator>
							</div>
						</div>
						<hr>
						<div class="row">
							<div class="col-sm-6">
								<asp:Button ID="btnActivarFormPassword" runat="server" Text="Editar" CssClass="btn btn-info" OnClick="btnActivarFormPassword_Click"/>
							</div>
							<div class="col-sm-6">
								<asp:Button ID="btnEnviarFormPassword" runat="server" Text="Cambiar Contraseña" CssClass="btn btn-info" type="button" ValidationGroup="vgEditarPassword" OnClick="btnEnviarFormPassword_Click"/>
							</div>
						</div>
					</div >
					  <asp:Label ID="lblNotificacionPassword" runat="server" CssClass="mt-2" ForeColor="#00CC66"></asp:Label>
				  </div>
				</div>
				<div class="col-md-7">
				  <div class="card mb-3">
					<div class="card-body">
						<div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Dni</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtDni" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Dni invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
						<div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Username</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Username invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Nombre</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="Nombre invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Apellido</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvApellido" runat="server" ControlToValidate="txtApellido" ErrorMessage="Apellido invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Email</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Telefono</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Telefono invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					  <hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Direccion</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Direccion invalida" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
						<hr>
					<div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Codigo Postal</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtCodigo_Postal" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvCodigo_Postal" runat="server" ControlToValidate="txtCodigo_Postal" ErrorMessage="Codigo Postal invalido" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					<hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Ciudad</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvCiudad" runat="server" ControlToValidate="txtCiudad" ErrorMessage="Ciudad invalida" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
						<hr>
					  <div class="row">
						<div class="col-sm-3">
						  <h6 class="mb-0">Provincia</h6>
						</div>
						<div class="col-sm-9 text-secondary form-group d-flex p-0 m-0">
						  <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' ValidationGroup="VgEditarUsuario"></asp:TextBox>
						  <asp:RequiredFieldValidator ID="RfvProvincia" runat="server" ControlToValidate="txtProvincia" ErrorMessage="Provincia invalida" ForeColor="Red" ValidationGroup="VgEditarUsuario">*</asp:RequiredFieldValidator>
						</div>
					  </div>
					<hr>
					  <div class="row">
						<div class="col-sm-6">
							<asp:Button ID="btnActivarForm" runat="server" Text="Editar" CssClass="btn btn-info" OnClick="btnActivarForm_Click" />
						</div>
						  <div class="col-sm-6">
							<asp:Button ID="btnEnviarForm" runat="server" Text="Enviar Cambios" CssClass="btn btn-info" OnClick="btnEnviarForm_Click" type="button" ValidationGroup="VgEditarUsuario"/>
						</div>
					  </div>
					</div>
						<asp:Label ID="lblNotificacion" runat="server" CssClass="mt-2" ForeColor="#00CC66"></asp:Label>
				  </div>
				</div>
			  </div>
		</div>
		</div>
	</main>
	</asp:Content>