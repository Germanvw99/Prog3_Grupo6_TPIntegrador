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
	public partial class CategoriasAgregar : System.Web.UI.Page
	{
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
		private readonly Categorias categoria = new Categorias();
		private readonly Estados estado = new Estados();

		private string imagenURL = "Imagenes/categorias/__default.png";
		protected void Page_Load(object sender, EventArgs e)
		{
			//if (NegocioUsuarios.getInstance().isAdmin() != true)
			//{
			//    Response.Redirect("home.aspx");
			//}

			if (!Page.IsPostBack)
			{
				CargarEstados();
			}
		}

		private void LimpiarCampos()
		{
			TxtNombre.Text = string.Empty;
			TxtDescripcion.Text = string.Empty;
			imagenURL = "Imagenes/categorias/__default.png";
			DdlEstados.SelectedValue = "0";
		}

		private void CargarEstados()
		{
			DdlEstados.Items.Add(new ListItem("-- Elija un estado --", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstados.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}

		protected void BtnAgregar_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(TxtNombre.Text) && !string.IsNullOrEmpty(TxtDescripcion.Text) && Int32.Parse(DdlEstados.SelectedValue) != 0)
			{
				if (FUCategoria.HasFile)
				{
					// VALIDA QUE EL ARCHIVO SEA CORRECTO.
					if (NegocioImagenes.validarArchivo(FUCategoria.PostedFile))
					{
						// SUBE ARCHIVO.
						imagenURL = NegocioImagenes.SubirImagenCategoria(FUCategoria.PostedFile);
					}
				}
				categoria.SetNombre(TxtNombre.Text.Trim());
				categoria.SetDescripcion(TxtDescripcion.Text.Trim());
				estado.SetCodigo(Int32.Parse(DdlEstados.SelectedValue));
				categoria.SetEstado(estado);
				categoria.SetRutaImagen(imagenURL);

				int agrego = negocioCategoria.agregarCategoria(categoria);

				if (agrego == 0)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo agregar la categoria');", true);
				}
				if (agrego == 1)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se agregó la categoria');", true);
				}
				if (agrego == 2)
				{
					ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('La categoria ya existe');", true);
				}
				LimpiarCampos();
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
	}
}