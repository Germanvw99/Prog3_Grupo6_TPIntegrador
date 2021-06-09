<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Vistas.Register" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Registrar Usuario</title>
        <!-- BOOTSTRAP -->
        <link rel="stylesheet" href="Recursos/css/bootstrap.min.css" type="text/css" />
        <!-- FONTAWESOME -->
        <link rel="stylesheet" href="Recursos/css/all.css" type="text/css"" />
        <!-- ESTILOS -->
        <link href="Recursos/css/theme.css" rel="stylesheet" type="text/css" />
        <link href="Recursos/css/estilos.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="wrapper-login bg-primary">
        <div class="container-login">
            <div><h2 class="mb-3 fw-bolder">CREAR CUENTA</h2></div>
            <form runat="server" class="px-3">
              <div class="row">
                <div class="mb-3 form-group d-flex p-0">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Usuario"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfvUsername" runat="server" ControlToValidate="txtUsername" ErrorMessage="Usuario invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                </div>
              </div>
              <div class="row">
                  <div class="form-group col-md-6 pl-0 d-flex">
                      <asp:TextBox ID="txtName" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Nombre"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="Nombre invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>        
                  </div>
                  <div class="form-group col-md-6 pr-0 d-flex">
                      <asp:TextBox ID="txtLastname" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Apellido"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvLastname" runat="server" ControlToValidate="txtLastname" ErrorMessage="Apellido invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
              </div>
              <div class="mb-3 row">
                  <div class="d-flex p-0">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Email" TextMode="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
              </div>
              <div class="row">
                  <div class="form-group col-md-8 pl-0 d-flex">
                      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Contraseña" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ControlToValidate="txtPassword" ErrorMessage="Contraseña invalida" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group col-md-4 pr-0 d-flex">
                      <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Teléfono" TextMode="Phone"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="Telefono invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
              </div>
              <div class="row">
                  <div class="form-group col-md-8 pl-0 d-flex">
                      <asp:TextBox ID="txtRepeatPassword" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Repetir Contraseña" TextMode="Password"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvRepeastPassword" runat="server" ControlToValidate="txtRepeatPassword" ErrorMessage="Contraseña invalida" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                      <asp:CompareValidator ID="CvRepeatPassword" runat="server" ErrorMessage="Las contraseñas no son iguales" ControlToCompare="txtRepeatPassword" ControlToValidate="txtPassword" ForeColor="Red" ValidationGroup="VgRegister">*</asp:CompareValidator>
                  </div>
                  <div class="form-group col-md-4 pr-0 d-flex">
                      <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="Cod. Postal"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvCodigoPostal" runat="server" ControlToValidate="txtCodigoPostal" ErrorMessage="Codigo Postal invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
              </div>
             <div class="row">
                  <div class="form-group col-md-6 pl-0 d-flex">
                      <asp:TextBox ID="txtCiudad" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Ciudad"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvCiudad" runat="server" ControlToValidate="txtCiudad" ErrorMessage="Ciudad invalida" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group col-md-6 pr-0 d-flex">
                      <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Provincia"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvProvincia" runat="server" ControlToValidate="txtProvincia" ErrorMessage="Provincia invalida" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
              </div>
                <div class="row">
                  <div class="form-group col-md-6 pl-0 d-flex">
                      <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Direccion"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="Direccion invalida" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
                  <div class="form-group col-md-6 pr-0 d-flex">
                      <asp:TextBox ID="txtDni" runat="server" CssClass="form-control py-2 rounded-3" style='border: 1px solid #E1E1E1' placeholder="DNI"></asp:TextBox>
                      <asp:RequiredFieldValidator ID="RfvDni" runat="server" ControlToValidate="txtDni" ErrorMessage="Dni invalido" ForeColor="Red" ValidationGroup="VgRegister">*</asp:RequiredFieldValidator>
                  </div>
                    </div>
              <div class="mb-3 row">
                  <asp:Button ID="btnRegister" runat="server" Text="Registrar" CssClass="btn btn-primary" OnClick="btnRegister_Click" ValidationGroup="VgRegister"/>
              </div>
                <asp:ValidationSummary ID="VsRegister" runat="server" ForeColor="Red" ValidationGroup="VgRegister" style="" DisplayMode="BulletList" ShowMessageBox="True" ShowValidationErrors="True" ShowSummary="False" />


            </form>
          <div class="mt-5 d-flex justify-content-center">
            <div>
                <asp:Label ID="lblHyperlink" runat="server" Text="Ya tenes una cuenta?    <a href='Login.aspx'>Iniciar Sesión</a>">
                </asp:Label>
            </div>
          </div>
            <div class="mt-3 d-flex justify-content-center">
                <asp:HyperLink ID="hlHomepage" runat="server" CssClass="text-primary" NavigateUrl="~/Home.aspx">Volver al menu principal</asp:HyperLink>
            </div>
        </div>
      </div>     
</body>
</html>
