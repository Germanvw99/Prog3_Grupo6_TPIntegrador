using Entidades;
using Negocio;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vistas
{
	public partial class MarcasListado : System.Web.UI.Page
	{
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly Estados estado = new Estados();
		private Marcas marca = new Marcas();

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				CargarEstados();

			}
			CargarGridView();
		}
		private void CargarGridView()
		{
			GrdMarcas.DataSource = negocioMarca.ObtenerMarcas();
			GrdMarcas.DataBind();
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

		protected void GrdMarcas_PreRender(object sender, EventArgs e)
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

		protected void GrdMarcas_RowCommand(object sender, GridViewCommandEventArgs e)
		{

			if (e.CommandName == "eventoVerDetalle")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				TxtCodigoModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_codigo")).Text;
				TxtNombreModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text;
				TxtEsloganModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_descripcion")).Text;
				TxtEstadoModal.Text = ((Label)GrdMarcas.Rows[fila].FindControl("est_nombre")).Text;
				//
				string rutaImage = ((Image)GrdMarcas.Rows[fila].FindControl("mar_ruta_imagen")).ImageUrl;
				ImgLogo.ImageUrl = rutaImage;

				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModal').modal('show');</script>", false);
			}

			if (e.CommandName == "eventoEditar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//
				marca.SetCodigo(Int32.Parse(((Label)GrdMarcas.Rows[fila].FindControl("mar_codigo")).Text));
				marca.SetNombre(((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text);
				marca.SetDescripcion(((Label)GrdMarcas.Rows[fila].FindControl("mar_descripcion")).Text);
				//
				// AQUI RECUPERO LA RUTA DE LA IMAGEN
				string rutaImage = ((Image)GrdMarcas.Rows[fila].FindControl("mar_ruta_imagen")).ImageUrl;
				marca.SetRutaImagen(rutaImage);
				//
				// RECUPERO CAMPO OCULTO CODIGO DE ESTADO
				int codigo = Int32.Parse(((Label)GrdMarcas.Rows[fila].FindControl("est_codigo")).Text);
				estado.SetCodigo(codigo);
				estado.SetNombre(((Label)GrdMarcas.Rows[fila].FindControl("est_nombre")).Text);
				marca.SetEstado(estado);

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioMarca.AgregarMarcaEnLaSesion(marca);

				Response.Redirect("MarcasModificar.aspx");
			}

			if (e.CommandName == "eventoEliminar")
			{
				// RECUPERO EL CONTENIDO DEL WEBFORM MARCASLISTADO.ASPX
				int fila = Convert.ToInt32(e.CommandArgument);
				//SETEO EL CODIGO DE LA MARCA A ELIMINAR
				TxtCodigoModalEliminar.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_codigo")).Text;
				marca.SetCodigo(Int32.Parse(TxtCodigoModalEliminar.Text));
				//
				// MUESTRO EL NOMBRE Y EL LOGO DE LA MARCA A ELIMINAR EN UN MODAL
				TxtNombreModalEliminar.Text = ((Label)GrdMarcas.Rows[fila].FindControl("mar_nombre")).Text;
				string rutaImage = ((Image)GrdMarcas.Rows[fila].FindControl("mar_ruta_imagen")).ImageUrl;
				ImageModalEliminar.ImageUrl = rutaImage;

				// AGREGO LO SELECCIONADO EN LA SESION
				negocioMarca.AgregarMarcaEliminar(marca);

				//
				//MOSTRAR MODAL
				ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalEliminar').modal('show');</script>", false);
			}
		}

		protected void BtnEliminarMarca_Click(object sender, EventArgs e)
		{
			marca = negocioMarca.ObtenerMarcaEliminar();

			if (negocioMarca.eliminarMarca(marca))
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se eliminó la marca');", true);
				CargarGridView();
			}
			else
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso eliminar la marca');", true);
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

		protected void LnAgregarMarcas_Click(object sender, EventArgs e)
		{
			Response.Redirect("MarcasAgregar.aspx");
		}

		protected void IrListarVentas_Click(object sender, EventArgs e)
		{
			Response.Redirect("VentasListado.aspx");
		}

		//FILTRADO DE MARCAS
		protected void BtnFiltrar_Click(object sender, EventArgs e)
        {
			GrdMarcas.DataSource = negocioMarca.filtrarConsultaMarca(TxtNombre.Text, DdlEstados.SelectedValue);
			GrdMarcas.DataBind();
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