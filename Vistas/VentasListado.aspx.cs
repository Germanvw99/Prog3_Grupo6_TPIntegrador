using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Negocio;
using Entidades;
using System.Globalization;

namespace Vistas
{
	public partial class VentasListado : System.Web.UI.Page
	{

		private readonly NegocioVentas negocioVenta = new NegocioVentas();
		private readonly NegocioMarcas negocioMarca = new NegocioMarcas();
		private readonly NegocioCategorias negocioCategoria = new NegocioCategorias();
		private readonly Ventas venta = new Ventas();
		private readonly Usuarios usuario = new Usuarios();
		private readonly MediosPago medioPago = new MediosPago();
		private readonly Estados estado = new Estados();
		private readonly NegocioDetalleVentas negocioDetalleVentas = new NegocioDetalleVentas();
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
			GrdVentas.DataSource = negocioVenta.ObtenerVentas();
			GrdVentas.DataBind();
		}

		private void CargarMarcas()
		{
			DdlMarcas.Items.Add(new ListItem("-- Elija una marca --", "0"));
			DataTable dt = negocioMarca.ObtenerMarcas();
			foreach (DataRow dr in dt.Rows)
			{
				DdlMarcas.Items.Add(new ListItem(dr["mar_nombre"].ToString(), dr["mar_codigo"].ToString()));
			}
		}

		private void CargarCategorias()
		{
			DdlCategorias.Items.Add(new ListItem("-- Elija una categoría --", "0"));
			DataTable dt = negocioCategoria.ObtenerCategorias();
			foreach (DataRow dr in dt.Rows)
			{
				DdlCategorias.Items.Add(new ListItem(dr["cat_nombre"].ToString(), dr["cat_codigo"].ToString()));
			}
		}
		protected void GrdVentas_PreRender(object sender, EventArgs e)
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

		protected void GrdVentas_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			if (e.CommandName == "eventoVerDetalles")
			{
				int fila = Convert.ToInt32(e.CommandArgument);

				//
				string codigoVenta = ((Label)GrdVentas.Rows[fila].FindControl("ven_codigo")).Text;
				//
				venta.SetCodigo(Int32.Parse(codigoVenta));
				//
				usuario.Dni = ((Label)GrdVentas.Rows[fila].FindControl("ven_usuarios_dni")).Text;
				usuario.Apellido = ((Label)GrdVentas.Rows[fila].FindControl("usu_apellido")).Text;
				usuario.Nombre = ((Label)GrdVentas.Rows[fila].FindControl("usu_nombre")).Text;
				HiddenField direccion = (HiddenField)GrdVentas.Rows[fila].FindControl("usu_direccion");
				usuario.Direccion = direccion.Value;
				HiddenField ciudad = (HiddenField)GrdVentas.Rows[fila].FindControl("usu_ciudad");
				usuario.Ciudad = ciudad.Value;
				//
				HiddenField codigoMedioPago = (HiddenField)GrdVentas.Rows[fila].FindControl("ven_medio_pago_codigo");
				medioPago.SetCodigo(Int32.Parse(codigoMedioPago.Value));
				medioPago.SetNombre(((Label)GrdVentas.Rows[fila].FindControl("mp_nombre")).Text);
				//
				string fecha = ((Label)GrdVentas.Rows[fila].FindControl("ven_fecha")).Text;

				int dia = Convert.ToInt32(fecha.Substring(0, 2));
				int mes = Convert.ToInt32(fecha.Substring(3, 2));
				int anio = Convert.ToInt32(fecha.Substring(6, 4));

				DateTime miFecha = new DateTime(anio, mes, dia);
				venta.SetFecha(miFecha);
				//
				//HiddenField fechaRequerida = (HiddenField)GrdVentas.Rows[fila].FindControl("ven_fecha_requerida");
				//HiddenField fechaEnvio = (HiddenField)GrdVentas.Rows[fila].FindControl("ven_fecha_envio");
				//
				venta.SetTotalFacturado(Decimal.Parse(((Label)GrdVentas.Rows[fila].FindControl("ven_total_facturado")).Text));
				//
				HiddenField codigoEstado = (HiddenField)GrdVentas.Rows[fila].FindControl("ven_codigo_estado");
				estado.SetCodigo(Int32.Parse(codigoEstado.Value));
				estado.SetNombre(((Label)GrdVentas.Rows[fila].FindControl("est_nombre")).Text);
				//
				venta.SetUsuario(usuario);
				venta.SetMedioPago(medioPago);
				venta.SetEstado(estado);
				//
				negocioVenta.CrearSesion();

				negocioDetalleVentas.CrearSesionDetalleVenta(codigoVenta);
				negocioVenta.AgregarVentaEnLaSesion(venta);
				//
				Response.Redirect("DetalleVenta.aspx");
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

		#region FILTRADO DE VENTAS
		protected void BtnFiltrar_Click(object sender, EventArgs e)
		{
			GrdVentas.DataSource = negocioVenta.filtrarConsultaVenta(TxtCliente.Text, TxtArticulo.Text, DdlMarcas.SelectedValue, DdlCategorias.SelectedValue);
			GrdVentas.DataBind();
		}

		protected void BtnQuitarFiltro_Click(object sender, EventArgs e)
		{
			CargarGridView();
			limpiarCampos();
		}
		private void limpiarCampos()
		{
			TxtCliente.Text = string.Empty;
			TxtArticulo.Text = string.Empty;
			DdlMarcas.SelectedValue = "0";
			DdlCategorias.SelectedValue = "0";
		}
		#endregion
	}
}