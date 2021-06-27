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
    public partial class Reportes : System.Web.UI.Page
	{

		private readonly NegocioVentas negocioVenta = new NegocioVentas();
		//
		protected void Page_Load(object sender, EventArgs e)
		{
			if (NegocioUsuarios.getInstance().isAdmin() != true)
			{
				Response.Redirect("home.aspx");
			}
			if (!Page.IsPostBack)
			{
				CalendarInicio.Visible = false;
				CalendarFinal.Visible = false;
			}
		}

		private void CargarGridViewFechas(DateTime desdeFecha, DateTime hastaFecha)
		{
			GrdReportes.DataSource = negocioVenta.ObtenerVentas(desdeFecha, hastaFecha);
			GrdReportes.DataBind();
		}

		protected void GrdReportes_PreRender(object sender, EventArgs e)
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

		protected void ImageButtonInicio_Click(object sender, ImageClickEventArgs e)
		{
			if (CalendarInicio.Visible)
			{
				CalendarInicio.Visible = false;
			}
			else
			{
				CalendarInicio.Visible = true;
			}
		}

		protected void CalendarInicio_SelectionChanged(object sender, EventArgs e)
		{
			TxtFechaInicio.Text = CalendarInicio.SelectedDate.ToString("dd/MM/yyyy");
			CalendarInicio.Visible = false;
		}

		protected void ImageButtonFinal_Click(object sender, ImageClickEventArgs e)
		{
			if (CalendarFinal.Visible)
			{
				CalendarFinal.Visible = false;
			}
			else
			{
				CalendarFinal.Visible = true;
			}
		}

		protected void CalendarFinal_SelectionChanged(object sender, EventArgs e)
		{
			TxtFechaFinal.Text = CalendarFinal.SelectedDate.ToString("dd/MM/yyyy");
			CalendarFinal.Visible = false;
		}

		protected void BtnHoy_Click(object sender, EventArgs e)
		{
			DateTime desdeFecha = DateTime.Today;
			DateTime hastaFecha = DateTime.Now;

			LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
			CargarGridViewFechas(desdeFecha, hastaFecha);
			LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
			LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);
		}

		protected void BtnUltimaSemana_Click(object sender, EventArgs e)
		{
			DateTime desdeFecha = DateTime.Today.AddDays(-7);
			DateTime hastaFecha = DateTime.Now;

			LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
			CargarGridViewFechas(desdeFecha, hastaFecha);
			LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
			LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);
		}

		protected void BtnEsteMes_Click(object sender, EventArgs e)
		{
			DateTime desdeFecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			DateTime hastaFecha = DateTime.Now;

			LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
			CargarGridViewFechas(desdeFecha, hastaFecha);
			LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
			LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);
		}

		protected void BtnUltimoMes_Click(object sender, EventArgs e)
		{
			DateTime desdeFecha = DateTime.Today.AddDays(-30);
			DateTime hastaFecha = DateTime.Now;

			LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
			CargarGridViewFechas(desdeFecha, hastaFecha);
			LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
			LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);
		}

		protected void BtnEsteAnio_Click(object sender, EventArgs e)
		{
			DateTime desdeFecha = new DateTime(DateTime.Now.Year, 1, 1);
			DateTime hastaFecha = DateTime.Now;

			LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
			CargarGridViewFechas(desdeFecha, hastaFecha);
			LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
			LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);
		}

		protected void BtnSolicitud_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrWhiteSpace(TxtFechaInicio.Text) && (!string.IsNullOrWhiteSpace(TxtFechaFinal.Text)))
			{
				DateTime desdeFecha = CalendarInicio.SelectedDate;
				DateTime hastaFecha = CalendarFinal.SelectedDate;

				LblMensaje.Text = "Desde: " + desdeFecha + " - Hasta: " + hastaFecha;
				CargarGridViewFechas(desdeFecha, hastaFecha);
				LblIngresos.Text = negocioVenta.ObtenerVentasIngresos(desdeFecha, hastaFecha);
				LblVentas.Text = negocioVenta.ObtenerVentasCantidad(desdeFecha, hastaFecha);

				TxtFechaInicio.Text = "";
				TxtFechaFinal.Text = "";
			}
		}
	}
}