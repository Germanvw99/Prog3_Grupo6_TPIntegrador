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
			TextNombreArticulo.Text = articuloProveedor.GetArticulo().GetNombre();
			TextCodigoArticulo.Text = articuloProveedor.GetArticulo().GetCodigo().ToString();
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

		protected void BtnModificarArticuloProveedor_Click(object sender, EventArgs e)
		{
			//AQUI SOLO SE SETEAN SOLO LOS CAMBIOS QUE SE HAYAN EFECTUADO
			if (!string.IsNullOrWhiteSpace(TxtStockActualModificar.Text.Trim()))
            {
                articuloProveedor.SetStockActual(Int32.Parse(TxtStockActualModificar.Text.Trim()));
            }
            if (!string.IsNullOrWhiteSpace(TxtPrecioUnitarioModificar.Text.Trim()))
            {
				articuloProveedor.SetPrecioUnitario(Decimal.Parse(TxtPrecioUnitarioModificar.Text.Trim()));
            }          

            if (negocioArticuloProveedor.modificarArticuloProveedor(articuloProveedor))
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Se modificó el stock');", true);
			}
            else
            {
				ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se pudo modificar el stock');", true);
            }

            LimpiarCampos();
		}

		private void LimpiarCampos()
		{
			TxtStockActualModificar.Text = string.Empty;
			TxtPrecioUnitarioModificar.Text = string.Empty;
		}

		protected void BtnCancelar_Click(object sender, EventArgs e)
		{
			LimpiarCampos();
		}
	}
}