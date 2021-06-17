using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
	public partial class CategoriasListado : System.Web.UI.Page
	{
		private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly Estados estado = new Estados();
		private Categorias categoria = new Categorias();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarGridView();
				CargarEstados();
			}
		}
		private void CargarGridView()
		{
			GrdCategorias.DataSource = negocioCategoria.ObtenerCategorias();
			GrdCategorias.DataBind();
		}

		private void CargarEstados()
		{
			DdlEstados.Items.Add(new ListItem("", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		protected void GrdCategorias_PreRender(object sender, EventArgs e)
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
		protected void GrdCategorias_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM CATEGORIASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				TxtCodigoModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_codigo")).Text;
				TxtNombreModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text;
				TxtDescripcionModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_descripcion")).Text;
				TxtEstadoModal.Text = ((Label)GrdCategorias.Rows[fila].FindControl("est_nombre")).Text;
				//
				string rutaImage = ((Image)GrdCategorias.Rows[fila].FindControl("cat_ruta_imagen")).ImageUrl;
				ImgLogo.ImageUrl = rutaImage;

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
			}

			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//
				categoria.SetCodigo(Int32.Parse(((Label)GrdCategorias.Rows[fila].FindControl("cat_codigo")).Text));
				categoria.SetNombre(((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text);
				categoria.SetDescripcion(((Label)GrdCategorias.Rows[fila].FindControl("cat_descripcion")).Text);
				//
				// AQUI RECUPERO LA RUTA DE LA IMAGEN
				string rutaImage = ((Image)GrdCategorias.Rows[fila].FindControl("cat_ruta_imagen")).ImageUrl;
				categoria.SetRutaImagen(rutaImage);
				//
				// RECUPERO CAMPO OCULTO CODIGO DE ESTADO
				int codigo = Int32.Parse(((Label)GrdCategorias.Rows[fila].FindControl("est_codigo")).Text);
				estado.SetCodigo(codigo);
				estado.SetNombre(((Label)GrdCategorias.Rows[fila].FindControl("est_nombre")).Text);
				categoria.SetEstado(estado);

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioCategoria.AgregarCategoriaEnLaSesion(categoria);

				Response.Redirect("CategoriasModificar.aspx");
			}

			if (e.CommandName == "eventoEliminar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//SETEO EL CODIGO DE LA CATEGORIA A ELIMINAR
				TxtCodigoModalEliminar.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_codigo")).Text;
				categoria.SetCodigo(Int32.Parse(TxtCodigoModalEliminar.Text));
				//
				// MUESTRO EL NOMBRE Y EL LOGO DE LA MARCA A ELIMINAR EN UN MODAL
				TxtNombreModalEliminar.Text = ((Label)GrdCategorias.Rows[fila].FindControl("cat_nombre")).Text;
				string rutaImage = ((Image)GrdCategorias.Rows[fila].FindControl("cat_ruta_imagen")).ImageUrl;
				ImageModalEliminar.ImageUrl = rutaImage;

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioCategoria.AgregarCategoriaEliminar(categoria);

				//
				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);
			}
		}
		protected void BtnEliminarCategoria_Click(object sender, EventArgs e)
		{
			categoria = negocioCategoria.ObtenerCategoriaEliminar();
			if (negocioCategoria.eliminarCategoria(categoria))
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó la categoría');", true);
				CargarGridView();
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar la categoría');", true);
			}

			//Response.Redirect("CategoriasListado.aspx");
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
		protected void LnAgregarCategorias_Click(object sender, EventArgs e)
		{
			Response.Redirect("CategoriasAgregar.aspx");
		}
		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}

		//FILTRADO DE ARTICULOS

		protected void BtnFiltrar_Click(object sender, EventArgs e)
		{
			GrdCategorias.DataSource = negocioCategoria.filtrarConsultaCategoria(TxtNombre.Text, DdlEstados.SelectedValue);
			GrdCategorias.DataBind();
		}

		protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
		{
			CargarGridView();
			limpiarCampos();
		}

		private void limpiarCampos()
		{
			TxtNombre.Text = string.Empty;
			DdlEstados.SelectedValue = "0";
		}
	}
}