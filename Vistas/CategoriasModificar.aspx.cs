using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class CategoriasModificar : System.Web.UI.Page
    {
        private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }

            DataTable dt = negocioCategoria.ObtenerTablaSesion();
            foreach (DataRow dr in dt.Rows)

            {
                ImgLogo.ImageUrl = dr["cat_ruta_imagen"].ToString();

                TxtNombre.Text = dr["cat_nombre"].ToString();
                TxtDescripcion.Text = dr["cat_descripcion"].ToString();

                TxtEstado.Text = dr["cat_codigo_estado"].ToString();

            }

        }
    }
}
