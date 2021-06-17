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
	public partial class ArticulosListado : System.Web.UI.Page
	{
		private readonly NegocioArticulos negocioArticulo = new NegocioArticulos();
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
		//
		private Articulos articulo = new Articulos();
		private readonly Categorias categoria = new Categorias();
		private readonly Estados estado = new Estados();
		private readonly Marcas marca = new Marcas();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarGridView();
				CargarMarcas();
				CargarCategorias();
			}
		}
		private void CargarGridView()
		{
			GrdArticulos.DataSource = negocioArticulo.ObtenerArticulos();
			GrdArticulos.DataBind();
		}

		private void CargarMarcas()
		{
			DdlMarcas.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioMarca.ObtenerMarcas();
			foreach (DataRow dr in dt.Rows)
			{
				DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
			}
		}

		private void CargarCategorias()
		{
			DdlCategorias.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioCategoria.ObtenerCategorias();
			foreach (DataRow dr in dt.Rows)
			{
				DdlCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
			}
		}
		protected void GrdArticulos_PreRender(object sender, EventArgs e)
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

		protected void GrdArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM ARTICULOSLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				TxtCodigoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text;
				TxtNombreModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;
				TxtDescripcionModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text;
				TxtPuntoPedidoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text;
				TxtPrecioListaModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text;
				TxtMarcaNombre.Text = ((Label)GrdArticulos.Rows[fila].FindControl("mar_nombre")).Text;
				TxtCategoriaNombre.Text = ((Label)GrdArticulos.Rows[fila].FindControl("cat_nombre")).Text;
				TxtEstadoModal.Text = ((Label)GrdArticulos.Rows[fila].FindControl("est_nombre")).Text;
				//
				string rutaImage = ((Image)GrdArticulos.Rows[fila].FindControl("art_ruta_imagen")).ImageUrl;
				ImgLogo.ImageUrl = rutaImage;

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
			}
			if (e.CommandName == "eventoEditar")
			{
				int fila = Convert.ToInt32(e.CommandArgument);
				//
				articulo.SetCodigo(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text));
				//
				marca.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("mar_nombre")).Text);
				int marCodigo = Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("mar_codigo")).Text);
				marca.SetCodigo(marCodigo);
				articulo.SetMarca(marca);
				//
				categoria.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("cat_nombre")).Text);
				int catCodigo = Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("cat_codigo")).Text);
				categoria.SetCodigo(catCodigo);
				articulo.SetCategoria(categoria);
				//
				articulo.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text);
				articulo.SetDescripcion(((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text);
				articulo.SetPuntoPedido(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text));
				articulo.SetPrecioLista(Decimal.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text));
				//
				string rutaImage = ((Image)GrdArticulos.Rows[fila].FindControl("art_ruta_imagen")).ImageUrl;
				articulo.SetRutaImagen(rutaImage);
				//
				estado.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("est_nombre")).Text);
				int estCodigo = Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("est_codigo")).Text);
				estado.SetCodigo(estCodigo);
				articulo.SetEstado(estado);
				// AGREGO LO SELECCIONADO EN LA SESION
				negocioArticulo.AgregarArticuloEnLaSesion(articulo);
				//
				Response.Redirect("ArticulosModificar.aspx");

			}
			if (e.CommandName == "eventoEliminar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM PROVEEDORESLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//SETEO EL CODIGO DEL ARTICULO A ELIMINAR
				int artCodigo = Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text);
				articulo.SetCodigo(artCodigo);
				//
				// MUESTRO EL NOMBRE Y EL LOGO DEL ARTICULO A ELIMINAR EN UN MODAL
				TxtNombreModalEliminar.Text = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;
				string rutaImage = ((Image)GrdArticulos.Rows[fila].FindControl("art_ruta_imagen")).ImageUrl;
				ImageModalEliminar.ImageUrl = rutaImage;

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioArticulo.AgregarArticuloEliminar(articulo);

				//
				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);
			}
			//if (e.CommandName == "eventoAgregarCarrito")
			//{
			//    int fila = Convert.ToInt32(e.CommandArgument);
			//    String id = ((Label)GrdArticulos.Rows[fila].FindControl("art_codigo")).Text;
			//    String nombre = ((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text;
			//    String descripcion = ((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text;
			//    String precio = ((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text;
			//    negocioArticulos.agregarfilacarrito(id,nombre,descripcion,precio);

			/*
                articulo.SetNombre(((Label)GrdArticulos.Rows[fila].FindControl("art_nombre")).Text);
                articulo.SetDescripcion(((Label)GrdArticulos.Rows[fila].FindControl("art_descripcion")).Text);
                articulo.SetPuntoPedido(Int32.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_punto_pedido")).Text));
                articulo.SetPrecioLista(Decimal.Parse(((Label)GrdArticulos.Rows[fila].FindControl("art_precio_lista")).Text));*/
			//}
		}

		protected void BtnEliminarArticulo_Click(object sender, EventArgs e)
		{
			articulo = negocioArticulo.ObtenerArticuloEliminar();
			if (negocioArticulo.eliminarArticulo(articulo))
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó el artículo " + TxtNombreModalEliminar.Text + "');", true);
				CargarGridView();
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar el artículo');", true);
			}
			//Response.Redirect("ArticulosListado.aspx");
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