using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checkeo si el usuario esta autorizado a entrar a el link
            if(Session["User"] != null)
            {
                Response.Redirect("home.aspx");
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuarios objUsuario = NegocioUsuarios.getInstance().Login(txtUsername.Text, txtPassword.Text);

            if (objUsuario == null)
            {
                lblError.Text = "Información inválida.";
            }
            else
            {
                Response.Redirect("home.aspx");

            }
        }
    }
}