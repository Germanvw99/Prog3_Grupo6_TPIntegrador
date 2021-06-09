<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Vistas.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" type="text/css" href="Recursos/css/jquery.dataTables.min.css" />
	<link rel="stylesheet" type="text/css" href="Recursos/css/dataTables.bootstrap5.min.css" />

	<main class="content">

		<div class="container">
	<div class="main-body">
	
		  <div class="row gutters-sm">
			<div class="col-md-4 mb-3">
			  <div class="card">
				<div class="card-body">
				  <div class="d-flex flex-column align-items-center text-center">
								<img src="Recursos/img/avatar.png" class="img-fluid rounded-circle mb-2" alt="imagen del usuario" id="img_user0" />
								<div class="mt-3">
					  <h4>Nombre Usuario</h4>
					</div>
				  </div>
				</div>
			  </div>
			  <div class="card mt-3">
	 
			  </div>
			</div>
			<div class="col-md-8">
			  <div class="card mb-3">
				<div class="card-body">
				  <div class="row">
					<div class="col-sm-3">
					  <h6 class="mb-0">Nombre y Apellido</h6>
					</div>
					<div class="col-sm-9 text-secondary">
					  Usuario 2
					</div>
				  </div>
				  <hr>
				  <div class="row">
					<div class="col-sm-3">
					  <h6 class="mb-0">Email</h6>
					</div>
					<div class="col-sm-9 text-secondary">
					  mail@gmail.com
					</div>
				  </div>
				  <hr>
				  <div class="row">
					<div class="col-sm-3">
					  <h6 class="mb-0">Telefono</h6>
					</div>
					<div class="col-sm-9 text-secondary">
					  (011) 32938109
					</div>
				  </div>
				  <hr>
				  <hr>
				  <div class="row">
					<div class="col-sm-3">
					  <h6 class="mb-0">Direccion</h6>
					</div>
					<div class="col-sm-9 text-secondary">
					  Los Aromos 769
					</div>
				  </div>
				  <hr>
				  <div class="row">
					<div class="col-sm-12">
					  <a class="btn btn-info " target="__blank" href="btn_editar_user">Editar</a>
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