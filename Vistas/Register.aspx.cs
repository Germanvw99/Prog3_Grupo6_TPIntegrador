using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checkeo si el usuario esta autorizado a entrar a el link
            if (Session["User"] != null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            bool usernameDuplicado = NegocioUsuarios.getInstance().VerificarUsernameDuplicado(txtUsername.Text);
            bool dniDuplicado = NegocioUsuarios.getInstance().VerificarDniDuplicado(txtDni.Text);
            if(usernameDuplicado)
            {
                lblNotificacion.Text = "El Username ingresado ya fue registrado.";
            }
            if(dniDuplicado)
            {
                lblNotificacion.Text = "El Dni ingresado ya fue registrado.";
            }
            if(dniDuplicado == false && usernameDuplicado == false)
            {
                bool registered = NegocioUsuarios.getInstance().RegistUser(GetEntity());
                if (registered)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }

        private Usuarios GetEntity()
        {
            Usuarios objUsuario = new Usuarios();
            objUsuario.Dni = txtDni.Text;
            objUsuario.Username = txtUsername.Text;
            objUsuario.Password = txtPassword.Text;
            objUsuario.Nombre = txtName.Text;
            objUsuario.Apellido = txtLastname.Text;
            objUsuario.Telefono = txtTelefono.Text;
            objUsuario.Email = txtEmail.Text;
            objUsuario.Direccion = txtDireccion.Text;
            objUsuario.Ciudad = txtCiudad.Text;
            objUsuario.Provincia = txtProvincia.Text;
            objUsuario.Codigo_Postal = txtCodigoPostal.Text;
            objUsuario.Ruta_Img = "../Recursos/img/avatar.png";
            objUsuario.Estado = 1;
            objUsuario.Codigo_Perfil = 2;

            return objUsuario;
        }
    }
    
}