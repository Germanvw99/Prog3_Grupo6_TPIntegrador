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
	public partial class DetalleVenta : System.Web.UI.Page
	{
		private readonly NegocioDetalleVentas negocioDetalleVentas = new NegocioDetalleVentas();
		private readonly NegocioVentas negocioVentas = new NegocioVentas();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}
            else
            {
				string venta_codigo = negocioDetalleVentas.ObtenerSesionDetalleVenta();

				DataTable dt = negocioVentas.ObtenerTablaSesionVentas();
				foreach (DataRow dr in dt.Rows)
				{
					if (venta_codigo.Equals(dr["ven_codigo"].ToString()))
					{
						LblNumeroFactura.Text = dr["ven_codigo"].ToString();
						LblFecha.Text = dr["ven_fecha"].ToString();
						LblApellidoNombre.Text = dr["usu_apellido"].ToString() + ", " + dr["usu_nombre"].ToString();
						LblDni.Text = dr["ven_usuarios_dni"].ToString();
						LblDireccion.Text = dr["usu_direccion"].ToString();
						LblLocalidad.Text = dr["usu_ciudad"].ToString();
						LblTotalFacturado.Text = dr["ven_total_facturado"].ToString();
						break;
					}
				}
			}
			if (!Page.IsPostBack)
			{

				CargarGridView(LblNumeroFactura.Text);
			}
		}

		protected void GrdDetalleVentas_PreRender(object sender, EventArgs e)
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

		private void CargarGridView(string CodigoVenta)
		{
			GrdDetalleVentas.DataSource = negocioDetalleVentas.ObtenerDetalleVentas(CodigoVenta);
			GrdDetalleVentas.DataBind();
		}

		// LINK BUTTON REDIRECCIONAMIENTO
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
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}
		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}
		protected void IrReportes_Click(object sender, EventArgs e)
		{
			Response.Redirect("Reportes.aspx");
		}
	}
}