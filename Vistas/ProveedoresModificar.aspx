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
											<label class="form-label">Nombre</label>
											<asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre" ReadOnly="True"></asp:TextBox>
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
											<asp:TextBox ID="TxtEstados"  class="form-control" runat="server" ReadOnly="True" ></asp:TextBox>
										</div>
									</div>
								</div>
							</div>
							<div class="col-12 col-xl-6">
								<div class="card">
									<div class="card-header">
										<h5 class="card-title">Nuevos datos</h5>
									</div>
									<div class="card-body">
										<div class="form-group">
											<label class="form-label">Nombre</label>
											<asp:TextBox ID="TextBox1" type="text" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">DNI o CUIL</label>
											<asp:TextBox ID="TextBox2" type="text" runat="server" class="form-control" placeholder="DNI o CUIL" ReadOnly="True" ></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">Dirección</label>
											<asp:TextBox ID="TextBox3" type="text" runat="server" class="form-control" placeholder="Dirección"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">Email</label>
											<asp:TextBox ID="TextBox4" type="text" runat="server" class="form-control" placeholder="Email" ></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">Teléfono</label>
											<asp:TextBox ID="TextBox5" type="text" runat="server" class="form-control" placeholder="Teléfono"></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">Nombre del Contacto</label>
											<asp:TextBox ID="TextBox6" type="text" runat="server" class="form-control" placeholder="Nombre del Contacto" ></asp:TextBox>
										</div>
										<div class="form-group">
											<label class="form-label">Estado</label>
											<br />
											<asp:DropDownList ID="DropDownList1" class="custom-select form-control"  runat="server" > </asp:DropDownList>
										</div>
										<div class="form-group">
								<label class="form-label">Imágen</label>
								<div>
									<input type="file" class="validation-file" name="validation-file">
								</div>
										<div class="form-group float-right">
																	<button type="button" class="btn btn-secondary" data-mdb-dismiss="modal">Cancelar</button>
							<asp:Button ID="Button1" class="btn btn-primary float-right" runat="server" Text="Modificar Proveedor" />

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