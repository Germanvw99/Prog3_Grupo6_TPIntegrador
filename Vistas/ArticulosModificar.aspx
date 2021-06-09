<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ArticulosModificar.aspx.cs" Inherits="Vistas.ArticulosModificar" %>
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
							<h5 class="card-title mb-0">Modificar Articulos</h5>
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
								<asp:TextBox ID="TxtNombre" type="text" runat="server" class="form-control" placeholder="Nombre"></asp:TextBox>
							</div>
							<div class="form-group">
								<label class="form-label">Descripción</label>
								<asp:TextBox ID="TxtDescripcion" type="text" runat="server" class="form-control" placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
							</div>
							<div class="form-group">
								<div class="mb-3">
									<label class="form-label">Marca</label>

								</div>
								<asp:TextBox ID="TxtMarca"  class="form-control" runat="server" > </asp:TextBox>
							</div>
							<div class="form-group">
								<div class="mb-3">
									<label class="form-label">Categoría</label>

								</div>
								<asp:TextBox ID="TxtCategoria"  class="form-control" runat="server" > </asp:TextBox>
							</div>
							<div class="form-group">
								<label class="form-label">Estado</label>
								<br />
								<asp:TextBox ID="TxtEstado"  class="form-control" runat="server" > </asp:TextBox>
							</div>
							<div class="form-group">
								<label class="form-label">Punto de pedido</label>
								<asp:TextBox ID="TxtPuntoPedido" type="text" runat="server" class="form-control" placeholder="Punto de pedido"></asp:TextBox>
							</div>
							<div class="form-group">
								<label class="form-label">Precio de Lista</label>
								<asp:TextBox ID="TxtPrecioLista" type="text" runat="server" class="form-control" placeholder="Precio de Lista"></asp:TextBox>
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
								<label class="form-label">Descripción</label>
								<asp:TextBox ID="TextBox2" type="text" runat="server" class="form-control" placeholder="Descripción" TextMode="MultiLine"></asp:TextBox>
							</div>
							<div class="form-group">
								<div class="mb-3">
									<label class="form-label">Marca</label>

								</div>
								<asp:DropDownList ID="DropDownList1"  class="form-control" runat="server" > </asp:DropDownList>
							</div>
							<div class="form-group">
								<div class="mb-3">
									<label class="form-label">Categoría</label>

								</div>
								<asp:DropDownList ID="DropDownList2" class="custom-select form-control"  runat="server" > </asp:DropDownList>
							</div>
							<div class="form-group">
								<label class="form-label">Estado</label>
								<br />
								<asp:DropDownList ID="DropDownList3"  class="form-control" runat="server" > </asp:DropDownList>
							</div>
							<div class="form-group">
								<label class="form-label">Punto de pedido</label>
								<asp:TextBox ID="TextBox3" type="text" runat="server" class="form-control" placeholder="Punto de pedido"></asp:TextBox>
							</div>
							<div class="form-group">
								<label class="form-label">Precio de Lista</label>
								<asp:TextBox ID="TextBox4" type="text" runat="server" class="form-control" placeholder="Precio de Lista"></asp:TextBox>
							</div>
										<div class="form-group">
											<label class="form-label">Imágen</label>
											<div>
												<input type="file" class="validation-file" name="validation-file">
											</div>
											<br />
										<div class="form-group float-right">
																	<button type="button" class="btn btn-secondary" data-mdb-dismiss="modal">Cancelar</button>
										<asp:Button ID="BtnAgregar" class="btn btn-primary float-right" runat="server" Text="Modificar artículo" />
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