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
    public partial class Formulario_web12 : System.Web.UI.Page


    {
        private NegocioVentas ng = new NegocioVentas();
        private NegocioDetalleVentas Neg = new NegocioDetalleVentas();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar sesion
            if (Session["User"] == null)
            {
                Response.Redirect("home.aspx");
            }
            else
            {
                DataTable dt = (DataTable)Session["User"];

                Usuarios objUsuario = NegocioUsuarios.getInstance().LeerTablaUsuario(dt);
                objUsuario.Dni.ToString();
                cargartabla(objUsuario.Dni.ToString());
            }            
        }

        public void cargartabla(String dni)
        {
            string[] columnas = null;
            DataTable dt = new DataTable();
            dt = ng.obtenertabladeventas2(dni);

            GvCompras.DataSource = dt;
            GvCompras.DataBind();
            
        }

        protected void GvCompras_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "eventodetalle")
            {

                int fila = Convert.ToInt32(e.CommandArgument);
                string factura;

                factura =( (Label)GvCompras.Rows[fila].FindControl("lblfactura")).Text;
                //Session["factura"] = factura;
                cargargridview(factura);
                //MOSTRAR MODAL
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ModalView", "<script>$('#myModalDetalles').modal('show');</script>", false);
            }
        }

        public void cargargridview(String factura)
        {
            DataTable dt = new DataTable();
            dt = Neg.obtenertabladetalledecompra();


            DataTable t = Neg.ObtenerDetalleVentas(factura);
            foreach (DataRow fila in t.Rows)
            {
                DataRow row = dt.NewRow();
                row["Factura"] = factura;
                row["Producto"] = fila["art_nombre"].ToString();
                row["Importe"] = fila["dt_precio_unitario"].ToString();
                row["Cantidad"] = fila["dt_cantidad_unidades"].ToString();
                row["Total"] = fila["dt_total"].ToString();
                dt.Rows.Add(row);
            }
            GvDetallesCompra.DataSource = dt;
            GvDetallesCompra.DataBind();
        }
    }
}