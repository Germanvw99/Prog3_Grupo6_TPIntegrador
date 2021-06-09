using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;
using System.Data;

namespace Vistas
{
    public partial class ArticulosModificar : System.Web.UI.Page
    {
        private readonly NegocioArticulos NegocioArticulo = new NegocioArticulos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (NegocioUsuarios.getInstance().isAdmin() != true)
            {
                Response.Redirect("home.aspx");
            }

            DataTable dt = NegocioArticulo.ObtenerTablaSesion();

            foreach (DataRow dr in dt.Rows)

            {
                ImgLogo.ImageUrl = dr["art_ruta_imagen"].ToString();
                TxtDescripcion.Text = dr["art_descripcion"].ToString();
                TxtNombre.Text = dr["art_nombre"].ToString();
                TxtMarca.Text = dr["art_marca_codigo"].ToString();
                TxtCategoria.Text = dr["art_categoria_codigo"].ToString();
                TxtEstado.Text = dr["art_codigo_estado"].ToString();
                TxtPuntoPedido.Text = dr["art_punto_pedido"].ToString();
                TxtPrecioLista.Text = dr["art_precio_lista"].ToString();

            }

        }
    }
}