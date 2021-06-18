using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Vistas
{
    public partial class UsuariosAdministrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			//if (NegocioUsuarios.getInstance().isAdmin() != true)
			//{
			//   Response.Redirect("home.aspx");
			// }
			if (!Page.IsPostBack)
			{
				CargarGridView();
			}
		}
		private void CargarGridView()
		{
			GrdUsuarios.DataSource = NegocioUsuarios.getInstance().ObtenerUsuarios();
			GrdUsuarios.DataBind();

		}
		protected void GrdUsuarios_PreRender(object sender, EventArgs e)
		{
			GridView gv = (GridView)sender;

			if ((gv.ShowHeader == true && gv.Rows.Count > 0) || (gv.ShowHeaderWhenEmpty == true))
			{
				// OBLIGAR A GRIDVIEW A USAR <THEAD> EN LUGAR DE <TBODY>
				gv.HeaderRow.TableSection = TableRowSection.TableHeader;
			}
			if (gv.ShowFooter == true && gv.Rows.Count > 0)
			{
				// OBLIGA A GRIDVIEW A USAR <TFOOT> EN LUGAR DE <TBODY>
				gv.FooterRow.TableSection = TableRowSection.TableFooter;
			}
		}
		protected void GrdUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM CATEGORIASLISTADO.ASPX
				
			}
			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				
			}
			if (e.CommandName == "eventoEliminar")
			{

				// RECUPERO EL CONTENIDO DEL WEBFORM PROVEEDORESLISTADO.ASPX
				
			}
		}

		protected void IrListarUsuarios_Click(object sender, EventArgs e)
		{
			Response.Redirect("UsuariosListado.aspx");
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
		protected void IrListarProveedores_Click(object sender, EventArgs e)
		{
			Response.Redirect("ProveedoresListado.aspx");
		}

		protected void LnAgregarArticulos_Click(object sender, EventArgs e)
		{
			Response.Redirect("ArticulosAgregar.aspx");
		}
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}

	}
}