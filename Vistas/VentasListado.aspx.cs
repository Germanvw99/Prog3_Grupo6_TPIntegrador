﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
using System.Globalization;

namespace Vistas
{
    public partial class VentasListado : System.Web.UI.Page
    {

        private readonly NegocioVentas negocioVentas = new NegocioVentas();
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
            }
        }
        private void CargarGridView()
        {
            GrdVentas.DataSource = negocioVentas.ObtenerVentas();
            GrdVentas.DataBind();
        }
        protected void GrdVentas_PreRender(object sender, EventArgs e)
        {
            GridView gv = (GridView)sender;

            if ((gv.ShowHeader == true && gv.Rows.Count > 0) ||
                (gv.ShowHeaderWhenEmpty == true))
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
                string codigoVenta= ((Label)GrdVentas.Rows[fila].FindControl("ven_codigo")).Text;
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
                negocioVentas.CrearSesion();

                negocioDetalleVentas.CrearSesionDetalleVenta(codigoVenta);
                negocioVentas.AgregarVentaEnLaSesion(venta);
                //
                Response.Redirect("DetalleVenta.aspx");
            }

        }
    }
}