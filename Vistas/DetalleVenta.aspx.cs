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
    public partial class DetalleVenta : System.Web.UI.Page
    {
        private readonly NegocioDetalleVentas negocioDetalleVentas = new NegocioDetalleVentas();
        private readonly NegocioVentas negocioVentas = new NegocioVentas();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (NegocioUsuarios.getInstance().isAdmin() != true)
            //{
            //    Response.Redirect("home.aspx");
            //}

            string venta_codigo = negocioDetalleVentas.ObtenerSesionDetalleVenta();

            DataTable dt = negocioVentas.ObtenerTablaSesionVentas();
            foreach (DataRow dr in dt.Rows)
            {
                if (venta_codigo.Equals(dr["ven_codigo"].ToString()))
                {
                    LblNumeroFactura.Text = dr["ven_codigo"].ToString();
                    LblFecha.Text = dr["ven_fecha"].ToString();
                    LblApellidoNombre.Text = dr["usu_apellido"].ToString() + ", " + dr["usu_nombre"].ToString();
                    LblDni.Text = dr["ven_usuarios_dni"].ToString();
                    LblDireccion.Text = dr["usu_direccion"].ToString();
                    LblLocalidad.Text = dr["usu_ciudad"].ToString();
                    LblTotalFacturado.Text = dr["ven_total_facturado"].ToString();
                    break;
                }
            }

            if (!Page.IsPostBack)
            {

                CargarGridView(LblNumeroFactura.Text);
            }
        }
        private void CargarGridView(string CodigoVenta)
        {
            GrdDetalleVentas.DataSource = negocioDetalleVentas.ObtenerDetalleVentas(CodigoVenta);
            GrdDetalleVentas.DataBind();
        }
    }
}
