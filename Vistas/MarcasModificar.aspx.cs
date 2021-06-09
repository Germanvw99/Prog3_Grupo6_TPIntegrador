using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;

namespace Vistas
{
    public partial class MarcasModificar : System.Web.UI.Page
    {
        private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }

            DataTable dt = negocioMarca.ObtenerTablaSesion();
            foreach (DataRow dr in dt.Rows)
            {
                ImgLogo.ImageUrl = dr["mar_ruta_imagen"].ToString();

                TxtNombre.Text = dr["mar_nombre"].ToString();
                TxtDescripcion.Text = dr["mar_descripcion"].ToString();

                TxtEstado.Text = dr["mar_codigo_estado"].ToString();
            }

        }
    }
}