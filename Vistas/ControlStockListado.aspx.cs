using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Data;
namespace Vistas
{
	public partial class ControlStockListado : System.Web.UI.Page
	{
		private readonly NegocioArticulosProveedores negocioArticuloProveedor = new NegocioArticulosProveedores();
		private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
		private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();

		private ArticulosProveedores articuloProveedor = new ArticulosProveedores();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}
			if (!Page.IsPostBack)
			{
				CargarGridView();
				CargarProveedores();
				CargarArticulos();
			}
		}
		private void CargarGridView()
		{
			GrdControlStock.DataSource = negocioArticuloProveedor.ObtenerArticulosProveedores();
			GrdControlStock.DataBind();
		}

		private void CargarProveedores()
		{
			DdlProveedores.Items.Add(new ListItem("-- Elija un Cuil de proveedor --", "0"));
			DataTable dt = negocioProveedor.ObtenerProveedores();
			foreach (DataRow dr in dt.Rows)
			{
				DdlProveedores.Items.Add(new ListItem(dr["pro_dni"].ToString() + "-" + dr["pro_razon_social"].ToString(), dr["pro_dni"].ToString()));
			}
		}

		private void CargarArticulos()
		{
			DdlArticulos.Items.Add(new ListItem("-- Elija un código de artículo --", "0"));
			DataTable dt = negocioArticulo.ObtenerArticulos();
			foreach (DataRow dr in dt.Rows)
			{
				DdlArticulos.Items.Add(new ListItem(dr["art_codigo"].ToString() + "-" + dr["art_nombre"].ToString(), dr["art_codigo"].ToString()));
			}
		}

		protected void GrdControlStock_PreRender(object sender, EventArgs e)
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

		protected void GrdControlStock_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM ARTICULOPROVEEDORLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//
				Proveedores proveedor = new Proveedores();
				proveedor.SetDni(((Label)GrdControlStock.Rows[fila].FindControl("axp_proveedor_dni")).Text);
				proveedor.SetRazonSocial(((Label)GrdControlStock.Rows[fila].FindControl("pro_razon_social")).Text);
				articuloProveedor.SetProveedor(proveedor);
				//
				Articulos articulo = new Articulos();
				articulo.SetCodigo(Int32.Parse(((Label)GrdControlStock.Rows[fila].FindControl("axp_articulo_codigo")).Text));
				articulo.SetNombre(((Label)GrdControlStock.Rows[fila].FindControl("art_nombre")).Text);
				articuloProveedor.SetArticulo(articulo);
				//
				articuloProveedor.SetPrecioUnitario(Decimal.Parse(((Label)GrdControlStock.Rows[fila].FindControl("axp_precio_unitario")).Text));
				articuloProveedor.SetStockActual(Int32.Parse(((Label)GrdControlStock.Rows[fila].FindControl("axp_stock_actual")).Text));

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioArticuloProveedor.AgregarArticuloProveedorEnLaSesion(articuloProveedor);

				Response.Redirect("ControlStockModificar.aspx");
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

		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}

		#region FILTRADO DE ARTICULOS
		protected void BtnFiltrar_Click(object sender, EventArgs e)
		{

			GrdControlStock.DataSource = negocioArticuloProveedor.filtrarConsultaControlStock(DdlProveedores.SelectedValue, TxtNombreProv.Text, DdlArticulos.SelectedValue, TxtNombreArt.Text);
			GrdControlStock.DataBind();
		}
		protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
		{
			CargarGridView();
			limpiarCampos();
		}

		private void limpiarCampos()
		{
			TxtNombreProv.Text = string.Empty;
			TxtNombreArt.Text = string.Empty;
			DdlProveedores.SelectedValue = "0";
			DdlArticulos.SelectedValue = "0";
		}
		#endregion

		protected void LnAgregarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockAgregar.aspx");
		}
	}
}