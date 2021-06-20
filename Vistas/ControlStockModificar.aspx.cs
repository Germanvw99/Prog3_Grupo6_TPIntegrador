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
    public partial class ControlStockModificar : System.Web.UI.Page
    {
		private ArticulosProveedores articuloProveedor = new ArticulosProveedores();
		private readonly NegocioArticulosProveedores negocioArticuloProveedor = new NegocioArticulosProveedores();
        protected void Page_Load(object sender, EventArgs e)
        {
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}

			if (!Page.IsPostBack) { }

			// OBTENGO LA SESION DE ARTICULOPROVEEDOR
			articuloProveedor = negocioArticuloProveedor.ObtenerSesionArticuloProveedor();
			//
			TxtNombreProveedor.Text = articuloProveedor.GetProveedor().GetRazonSocial();
			TxtCuilProveedor.Text = articuloProveedor.GetProveedor().GetDni();
			TextNombreArticulo.Text = articuloProveedor.GetArticulo().GetCodigo().ToString();
			TextCodigoArticulo.Text = articuloProveedor.GetArticulo().GetNombre();
			TxtStockActual.Text = articuloProveedor.GetStockActual().ToString();
			TxtPrecioUnitario.Text = articuloProveedor.GetPreciounitario().ToString();
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

		protected void BtnModificarCategoria_Click(object sender, EventArgs e)
		{
			////AQUI SOLO SE SETEAN SOLO LOS CAMBIOS QUE SE HAYAN EFECTUADO
			//if (!string.IsNullOrWhiteSpace(TxtNombreModificar.Text.Trim()))
			//{
			//	categoria.SetNombre(TxtNombreModificar.Text.Trim());
			//}
			//if (!string.IsNullOrWhiteSpace(TxtDescripcionModificar.Text.Trim()))
			//{
			//	categoria.SetDescripcion(TxtDescripcionModificar.Text.Trim());
			//}
			//if (Int32.Parse(DdlEstadoModificar.SelectedValue) != 0)
			//{
			//	estado.SetCodigo(Int32.Parse(DdlEstadoModificar.SelectedValue));
			//	categoria.SetEstado(estado);
			//}

			//if (FUCategoria.HasFile)
			//{
			//	// VALIDA QUE EL ARCHIVO SEA CORRECTO.
			//	if (NegocioImagenes.validarArchivo(FUCategoria.PostedFile))
			//	{
			//		// SUBE ARCHIVO.
			//		string imagenNombre = NegocioImagenes.SubirImagenCategoria(FUCategoria.PostedFile);
			//		categoria.SetRutaImagen(imagenNombre);
			//	}
			//}
			//int agrego = negocioCategoria.modificarMarca(categoria);

			//if (agrego == 0)
			//{
			//	ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo modificar la categoría');", true);
			//}
			//if (agrego == 1)
			//{
			//	ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se modificó la categoría');", true);
			//}
			//if (agrego == 2)
			//{
			//	ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El nombre de la categoría ya existe');", true);
			//}

			LimpiarCampos();
		}

		private void LimpiarCampos()
		{
			TxtNombreModificar.Text = string.Empty;
			TxtDescripcionModificar.Text = string.Empty;
			DdlEstadoModificar.SelectedValue = "0";
		}

		protected void BtnCancelar_Click(object sender, EventArgs e)
		{
			//LimpiarCampos();
		}
	}
}