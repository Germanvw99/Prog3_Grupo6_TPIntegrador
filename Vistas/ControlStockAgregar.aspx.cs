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
	public partial class ControlStockAgregar : System.Web.UI.Page
	{
		private readonly NegocioArticulosProveedores negocioArticuloProveedor = new NegocioArticulosProveedores();
		private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
		private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();
		private ArticulosProveedores articuloProveedor = new ArticulosProveedores();
		protected void Page_Load(object sender, EventArgs e)
		{
			CargarProveedores();
			CargarArticulos();
		}

		private void CargarProveedores()
		{
			DdlProveedores.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioProveedor.ObtenerProveedores();
			foreach (DataRow dr in dt.Rows)
			{
				DdlProveedores.Items.Add(new ListItem(dr["pro_razon_social"].ToString() + " - [CUIL - " + dr["pro_dni"].ToString() + "]", dr["pro_dni"].ToString()));
			}
		}

		private void CargarArticulos()
		{
			DdlArticulos.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioArticulo.ObtenerArticulos();
			foreach (DataRow dr in dt.Rows)
			{
				DdlArticulos.Items.Add(new ListItem(dr["art_nombre"].ToString() + " - [Cod. - " + dr["art_codigo"].ToString() + "] - [Marca - " + dr["mar_nombre"].ToString() + "]", dr["art_codigo"].ToString()));
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
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}
		protected void IrListarStock_Click(object sender, EventArgs e)
		{
			Response.Redirect("ControlStockListado.aspx");
		}

		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			if (Int32.Parse(DdlProveedores.SelectedValue) != 0 && Int32.Parse(DdlArticulos.SelectedValue) != 0 && !string.IsNullOrEmpty(txtCantidad.Text) && !string.IsNullOrEmpty(txtPrecio.Text))
			{
				Proveedores proveedor = new Proveedores();
				proveedor.SetDni(DdlProveedores.SelectedValue);
				articuloProveedor.SetProveedor(proveedor);
				//
				Articulos articulo = new Articulos();
				articulo.SetCodigo(int.Parse(DdlArticulos.SelectedValue));
				articuloProveedor.SetArticulo(articulo);
				articuloProveedor.SetEntrada(int.Parse(txtCantidad.Text));
				articuloProveedor.SetPrecioUnitario(decimal.Parse(txtPrecio.Text));

				if (negocioArticuloProveedor.agregarStock(articuloProveedor))
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se actualizó el stock');", true);
				}

				else
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso actualizar el stock');", true);
				}
				LimpiarCampos();
			}
		}

		private void LimpiarCampos()
		{
			txtCantidad.Text = string.Empty;
			txtPrecio.Text = string.Empty;
			DdlProveedores.SelectedValue = "0";
			DdlArticulos.SelectedValue = "0";
		}

		protected void IrAgregarProveedor_Click(object sender, EventArgs e)
		{
			Response.Redirect("ProveedoresAgregar.aspx");
		}

		protected void IrAgregarArticulo_Click(object sender, EventArgs e)
		{
			Response.Redirect("ArticulosAgregar.aspx");
		}
	}
}