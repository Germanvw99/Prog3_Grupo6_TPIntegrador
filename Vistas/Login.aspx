<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vistas.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <title>Iniciar Sesión</title>

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
            <div><h2 class="mb-5 fw-bolder">INICIE SESION</h2></div>

            <form runat="server" class="px-3">                
                      <div class="mb-4 form-group d-flex p-0">
                         <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control border-1 py-3 rounded-3" style='border: 1px solid #E1E1E1'  placeholder="Nombre de Usuario"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RfvUsername" runat="server" ErrorMessage="Usuario invalido" ValidationGroup="VgLogin" Text="*" ControlToValidate="txtUsername" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                      <div class="mb-5 form-group d-flex p-0">
                         <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control py-3 rounded-3" placeholder="Contraseña"  style='border: 1px solid #E1E1E1'  TextMode="Password"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ErrorMessage="Contraseña invalida" ValidationGroup="VgLogin" Text="*" ControlToValidate="txtPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                      </div>
                      <div class="mb-3 row">
                          <asp:Button ID="btnLogin" runat="server" Text="Inicar Sesión" CssClass="btn btn-primary" OnClick="btnLogin_Click" ValidationGroup="VgLogin" />
                      </div>
                        <asp:ValidationSummary ID="VsummLogin" runat="server" ValidationGroup="VgLogin" ShowSummary="False" ShowMessageBox="True" />
            </form>

            <div class="mr-2 d-flex justify-content-center">
                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

            </div>
          <div class="mt-2 d-flex justify-content-center">
            <div>
                <asp:Label ID="lblHyperlink" runat="server" Text="No tenes una cuenta?    <a href='Register.aspx'>Registrarse</a>">
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