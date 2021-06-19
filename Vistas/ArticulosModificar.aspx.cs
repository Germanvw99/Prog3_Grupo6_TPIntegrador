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
		private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();
		private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private Articulos articulo = new Articulos();
		private readonly Categorias categoria = new Categorias();
		private readonly Estados estado = new Estados();
		private readonly Marcas marca = new Marcas();
		protected void Page_Load(object sender, EventArgs e)
		{
			//if (NegocioUsuarios.getInstance().isAdmin() != true)
			//{
			//    Response.Redirect("home.aspx");
			//}
			if (!Page.IsPostBack)
			{
				CargarCategorias();
				CargarEstados();
				CargarMarcas();
			}

			articulo = negocioArticulo.ObtenerSesionArticulo();

			TxtNombre.Text = articulo.GetNombre();
			TxtDescripcion.Text = articulo.GetDescripcion();
			TxtMarca.Text = articulo.GetMarca().GetNombre();
			TxtCategoria.Text = articulo.GetCategoria().GetNombre();
			TxtEstado.Text = articulo.GetEstado().GetNombre();
			TxtPuntoPedido.Text = articulo.GetPuntoPedido().ToString();
			TxtPrecioLista.Text = articulo.GetPrecioLista().ToString();
			ImgLogo.ImageUrl = articulo.GetRutaImagen();
		}

		private void CargarCategorias()
		{
			DdlCategoriaModificar.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioCategoria.ObtenerCategorias();
			foreach (DataRow dr in dt.Rows)
			{
				DdlCategoriaModificar.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
			}
		}

		private void CargarEstados()
		{
			DdlEstadoModificar.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstadoModificar.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		private void CargarMarcas()
		{
			DdlMarcaModificar.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioMarca.ObtenerMarcas();
			foreach (DataRow dr in dt.Rows)
			{
				DdlMarcaModificar.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
			}
		}

		protected void BtnModificarArticulo_Click(object sender, EventArgs e)
		{
			//AQUI SOLO SE SETEAN SOLO LOS CAMBIOS QUE SE HAYAN EFECTUADO
			if (!string.IsNullOrWhiteSpace(TxtNombreModificar.Text.Trim()))
			{
				articulo.SetNombre(TxtNombreModificar.Text.Trim());
			}
			if (!string.IsNullOrWhiteSpace(TxtDescripcionModificar.Text.Trim()))
			{
				articulo.SetDescripcion(TxtDescripcionModificar.Text.Trim());
			}
			if (Int32.Parse(DdlMarcaModificar.SelectedValue) != 0)
			{
				marca.SetCodigo(Int32.Parse(DdlMarcaModificar.SelectedValue));
				articulo.SetMarca(marca);
			}
			if (Int32.Parse(DdlCategoriaModificar.SelectedValue) != 0)
			{
				categoria.SetCodigo(Int32.Parse(DdlCategoriaModificar.SelectedValue));
				articulo.SetCategoria(categoria);
			}
			if (Int32.Parse(DdlEstadoModificar.SelectedValue) != 0)
			{
				estado.SetCodigo(Int32.Parse(DdlEstadoModificar.SelectedValue));
				articulo.SetEstado(estado);
			}
			if (!string.IsNullOrWhiteSpace(TxtPuntoPedidoModificar.Text.Trim()))
			{
				articulo.SetPuntoPedido(Int32.Parse(TxtPuntoPedidoModificar.Text.Trim()));
			}
			if (!string.IsNullOrWhiteSpace(TxtPrecioListaModificar.Text.Trim()))
			{
				articulo.SetPrecioLista(Decimal.Parse(TxtPrecioListaModificar.Text.Trim()));
			}
			if (FUArticulo.HasFile)
			{
				string imagenNombre = FUArticulo.PostedFile.FileName;
				imagenNombre = "Imagenes/articulos/" + imagenNombre;
				articulo.SetRutaImagen(imagenNombre);
			}
			int agrego = negocioArticulo.modificarArticulo(articulo);

			if (agrego == 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo modificar el artículo');", true);
			}
			if (agrego == 1)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se modificó el artículo');", true);
			}
			if (agrego == 2)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El nombre del artículo ya existe');", true);
			}

			//LimpiarCampos();
		}

		//
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

		// AGREGAR MARCAS Y CATEGORIAS
		protected void IrAgregarMarca_Click(object sender, EventArgs e)
		{
			Response.Redirect("MarcasAgregar.aspx");
		}
		protected void IrAgregarCategoria_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoriasAgregar.aspx");
		}
	}
}