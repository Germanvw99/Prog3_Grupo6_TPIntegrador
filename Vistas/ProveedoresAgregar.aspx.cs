using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class ProveedoresAgregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Checkeo si el usuario esta autorizado a entrar a el link
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }
        }
    }
}