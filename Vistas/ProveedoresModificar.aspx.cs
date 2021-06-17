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
	public partial class ProveedoresModificar : System.Web.UI.Page
	{
		private Proveedores proveedor = new Proveedores();
		private readonly NegocioProveedores negocioProveedor = new NegocioProveedores();
		private readonly NegocioEstados negocioEstado = new NegocioEstados();
		private readonly Estados estado = new Estados();
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

			// OBTENGO LA SESION DE CATEGORIAS
			proveedor = negocioProveedor.ObtenerSesionProveedor();
			//
			ImgLogo.ImageUrl = proveedor.GetRutaImagen();
			TxtRazonSocial.Text = proveedor.GetRazonSocial();
			TxtDni.Text = proveedor.GetDni();
			TxtDireccion.Text = proveedor.GetDireccion();
			TxtEmail.Text = proveedor.GetEmail();
			TxtTelefono.Text = proveedor.GetTelefono();
			TxtContacto.Text = proveedor.GetNombreContacto();
			TxtEstado.Text = proveedor.GetEstado().GetNombre();
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

		protected void BtnModificarProveedor_Click(object sender, EventArgs e)
		{
			//AQUI SOLO SE SETEAN SOLO LOS CAMBIOS QUE SE HAYAN EFECTUADO
			if (!string.IsNullOrWhiteSpace(TxtRazonSocialModificar.Text.Trim()))
			{
				proveedor.SetRazonSocial(TxtRazonSocialModificar.Text.Trim());
			}
			if (!string.IsNullOrWhiteSpace(TxtDireccionModificar.Text.Trim()))
			{
				proveedor.SetDireccion(TxtDireccionModificar.Text.Trim());
			}

			if (!string.IsNullOrWhiteSpace(TxtEmailModificar.Text.Trim()))
			{
				proveedor.SetEmail(TxtEmailModificar.Text.Trim());
			}
			if (!string.IsNullOrWhiteSpace(TxtTelefonoModificar.Text.Trim()))
			{
				proveedor.SetTelefono(TxtTelefonoModificar.Text.Trim());
			}

			if (!string.IsNullOrWhiteSpace(TxtContactoModificar.Text.Trim()))
			{
				proveedor.SetNombreContacto(TxtContactoModificar.Text.Trim());
			}

			if (Int32.Parse(DdlEstadoModificar.SelectedValue) != 0)
			{
				estado.SetCodigo(Int32.Parse(DdlEstadoModificar.SelectedValue));
				proveedor.SetEstado(estado);
			}
			if (FUProveedor.HasFile)
			{
				string imagenNombre = FUProveedor.PostedFile.FileName;
				imagenNombre = "Imagenes/proveedores/" + imagenNombre;
				proveedor.SetRutaImagen(imagenNombre);
			}
			int agrego = negocioProveedor.modificarProveedor(proveedor);

			if (agrego == 0)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se puso modificar el proveedor');", true);
			}
			if (agrego == 1)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se modificó el proveedor');", true);
			}
			if (agrego == 2)
			{
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('El nombre del proveedor ya existe');", true);
			}

			//LimpiarCampos();
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
	}
}