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
    public partial class CategoriasAgregar : System.Web.UI.Page
    {
        private readonly NegocioEstados negocioEstados = new NegocioEstados();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CargarEstados();
            }
        }
        private void CargarEstados()
        {
            DataTable dt = negocioEstados.ObtenerEstados();
            foreach (DataRow dr in dt.Rows)
            {
                DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
            }
        }
        protected void IrListarArticulos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ArticulosListado.aspx");
        }

        protected void IrListarMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("MarcasListado.aspx");
        }

        protected void IrListarCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriasListado.aspx");
        }
    }
}