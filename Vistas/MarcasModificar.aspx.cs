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
	public partial class MarcasModificar : System.Web.UI.Page
	{
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private Marcas marca = new Marcas();
		private readonly Estados estado = new Estados();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}

			if (!Page.IsPostBack)
			{
				CargarEstados();
			}

			marca = negocioMarca.ObtenerSesionMarca();
			//
			ImgLogo.ImageUrl = marca.GetRutaImagen();
			TxtNombre.Text = marca.GetNombre();
			TxtDescripcion.Text = marca.GetDescripcion();
			TxtEstado.Text = marca.GetEstado().GetNombre();
		}
		private void CargarEstados()
		{
			DdlEstadoModificar.Items.Add(new ListItem("Elija un estado", "0"));
			DataTable dt = negocioEstado.ObtenerEstados();
			foreach (DataRow dr in dt.Rows)
			{
				DdlEstadoModificar.Items.Add(new ListItem(dr["est_nombre"].ToString(), dr["est_codigo"].ToString()));
			}
		}
		protected void BtnModificarMarca_Click(object sender, EventArgs e)
		{
			//AQUI SOLO SE SETEAN SOLO LOS CAMBIOS QUE SE HAYAN EFECTUADO
			if (!string.IsNullOrWhiteSpace(TxtNombreModificar.Text.Trim()))
			{
				marca.SetNombre(TxtNombreModificar.Text.Trim());
			}
			if (!string.IsNullOrWhiteSpace(TxtDescripcionModificar.Text.Trim()))
			{
				marca.SetDescripcion(TxtDescripcionModificar.Text.Trim());
			}
			if (Int32.Parse(DdlEstadoModificar.SelectedValue) != 0)
			{
				estado.SetCodigo(Int32.Parse(DdlEstadoModificar.SelectedValue));
				marca.SetEstado(estado);
			}
			if (FUMarca.HasFile)
			{
				// VALIDA QUE EL ARCHIVO SEA CORRECTO.
				if (NegocioImagenes.validarArchivo(FUMarca.PostedFile))
				{
					// SUBE ARCHIVO.
					string imagenNombre = NegocioImagenes.SubirImagenMarca(FUMarca.PostedFile);
					marca.SetRutaImagen(imagenNombre);
				}
			}
			int agrego = negocioMarca.modificarMarca(marca);

			if (agrego == 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo modificar la marca');", true);
			}
			if (agrego == 1)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se modificó la marca');", true);
			}
			if (agrego == 2)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El nombre de la marca ya existe');", true);
			}

			LimpiarCampos();
		}

		private void LimpiarCampos()
		{
			TxtNombreModificar.Text = string.Empty;
			TxtDescripcionModificar.Text = string.Empty;
			DdlEstadoModificar.SelectedValue = "0";
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

		protected void BtnCancelar_Click(object sender, EventArgs e)
		{
			LimpiarCampos();
		}
	}
}